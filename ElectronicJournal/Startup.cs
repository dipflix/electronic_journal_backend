using AutoMapper;
using ElectronicJournal.Common;
using ElectronicJournal.Data;
using ElectronicJournal.Data.Repositorie;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using ElectronicJournal.DTO;
using ElectronicJournal.Services.JwtService;
using ElectronicJournal.Services.JwtService.Interfaces;
using ElectronicJournal.Services.StudentsService;
using ElectronicJournal.Services.TeacherService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ElectronicJournal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContext, ElectronicJournalContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IRepository<User>, BaseRepository<User>>();
            services.AddTransient<IRepository<Subject>, BaseRepository<Subject>>();
            services.AddTransient<IRepository<Student>, BaseRepository<Student>>();
            services.AddTransient<IRepository<Teacher>, BaseRepository<Teacher>>();
            services.AddTransient<IRepository<Journal>, BaseRepository<Journal>>();
            services.AddTransient<IRepository<Human>, BaseRepository<Human>>();
            services.AddTransient<IRepository<Class>, BaseRepository<Class>>();
            services.AddTransient<IFullRepository<Human>, HumanRepository>();
            services.AddTransient<IFullRepository<Lesson>, LessonsRepository>();
            services.AddTransient<IFullRepository<Teacher>, TeacherRepository>();
            services.AddTransient<IFullRepository<Student>, StudentsRepository>();
            services.AddTransient<IFullRepository<Class>, ClassRepository>();
            services.AddTransient<IFullRepository<Subject>, SubjectsRepository>();
            services.AddTransient<IFullRepository<SubjectInJournal>, SubjectInJournalRepository>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddCors();

            services.Configure<AuthOptions>(Configuration.GetSection("Auth"));
            services.AddAutoMapper(typeof(MappingEntities));

            var authOptions = Configuration.GetSection("Auth").Get<AuthOptions>();
           
            services.AddAuthentication((options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }))
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = authOptions.Issuer,
                            ValidateAudience = true,
                            ValidAudience = authOptions.Audience,

                            ValidateLifetime = true,
                            IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                            ValidateIssuerSigningKey = true,
                        };
                    });

          
            services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ElectronicJournal", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ElectronicJournal v1"));
            }
            app.UseDeveloperExceptionPage();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
           

            app.UseCors(x => x.AllowAnyOrigin()
                             .AllowAnyMethod()
                             .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}