﻿// <auto-generated />
using System;
using ElectronicJournal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElectronicJournal.Data.Migrations
{
    [DbContext(typeof(ElectronicJournalContext))]
    [Migration("20211120220643_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElectronicJournal.Domain.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassroomTeacherId")
                        .HasColumnType("int");

                    b.Property<int>("CurrentJournalId")
                        .HasColumnType("int");

                    b.Property<int>("HeadmanId")
                        .HasColumnType("int");

                    b.Property<int?>("HeadmanId1")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomTeacherId");

                    b.HasIndex("CurrentJournalId")
                        .IsUnique();

                    b.HasIndex("HeadmanId1");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Human", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Humans");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Journal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("HomeTask")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubjectInJournalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectInJournalId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.LessonScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("LessonScores");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("HumanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("HumanId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.SubjectInJournal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JournalId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JournalId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SubjectsInJournals");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentClassId")
                        .HasColumnType("int");

                    b.Property<int>("HumanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrentClassId")
                        .IsUnique();

                    b.HasIndex("HumanId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Class", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Teacher", "ClassroomTeacher")
                        .WithMany()
                        .HasForeignKey("ClassroomTeacherId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Domain.Journal", "CurrentJournal")
                        .WithOne()
                        .HasForeignKey("ElectronicJournal.Domain.Class", "CurrentJournalId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Domain.Student", "Headman")
                        .WithMany()
                        .HasForeignKey("HeadmanId1");

                    b.Navigation("ClassroomTeacher");

                    b.Navigation("CurrentJournal");

                    b.Navigation("Headman");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Human", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.User", "User")
                        .WithOne("Human")
                        .HasForeignKey("ElectronicJournal.Domain.Human", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Journal", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Class", "Class")
                        .WithMany("Journals")
                        .HasForeignKey("ClassId");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Lesson", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.SubjectInJournal", "SubjectInJournal")
                        .WithMany("Lessons")
                        .HasForeignKey("SubjectInJournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubjectInJournal");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.LessonScore", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Lesson", "Lesson")
                        .WithMany("LessonScores")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Domain.Student", "Student")
                        .WithMany("LessonsScores")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Student", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Domain.Human", "Human")
                        .WithMany()
                        .HasForeignKey("HumanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Human");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.SubjectInJournal", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Journal", "Journal")
                        .WithMany("SubjectsInJournal")
                        .HasForeignKey("JournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Domain.Subject", "Subject")
                        .WithMany("SubjectsInJournal")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Domain.Teacher", "Teacher")
                        .WithMany("SubjectsInJournal")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Journal");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Teacher", b =>
                {
                    b.HasOne("ElectronicJournal.Domain.Class", "CurrentClass")
                        .WithOne()
                        .HasForeignKey("ElectronicJournal.Domain.Teacher", "CurrentClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournal.Domain.Human", "Human")
                        .WithMany()
                        .HasForeignKey("HumanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentClass");

                    b.Navigation("Human");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Class", b =>
                {
                    b.Navigation("Journals");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Journal", b =>
                {
                    b.Navigation("SubjectsInJournal");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Lesson", b =>
                {
                    b.Navigation("LessonScores");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Student", b =>
                {
                    b.Navigation("LessonsScores");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Subject", b =>
                {
                    b.Navigation("SubjectsInJournal");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.SubjectInJournal", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.Teacher", b =>
                {
                    b.Navigation("SubjectsInJournal");
                });

            modelBuilder.Entity("ElectronicJournal.Domain.User", b =>
                {
                    b.Navigation("Human");
                });
#pragma warning restore 612, 618
        }
    }
}
