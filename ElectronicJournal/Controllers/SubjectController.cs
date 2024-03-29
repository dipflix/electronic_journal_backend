﻿using System;
using ElectronicJournal.Data.Repositorie.Interfaces;
using ElectronicJournal.Domain;
using ElectronicJournal.Services.StudentsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using ElectronicJournal.DTO.ModelsDTO;

namespace ElectronicJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private IFullRepository<Subject> _subjects;
        private IRepository<User> _users;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public SubjectController(IFullRepository<Subject> subjects, IRepository<User> users, IStudentService studentService, IMapper mapper)
        {
            _subjects = subjects;
            _users = users;
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<SubjectsDTO> GetAll()
        {
            var subjects = _subjects.GetAllWithObjects();
            return subjects.Select(h => _mapper.Map<SubjectsDTO>(h));
        }

        [HttpGet]
        [Authorize]
        [Route("student")]
        public IEnumerable<Subject> GetSubjectForStudent()
        {
            var student = _studentService.GetStudentByUserId(UserId);
            return _subjects.GetSome(s => s.SubjectsInJournal.Any(sj => sj.Journal.Class.Id == student.ClassId));
        }

        [HttpGet]
        [Authorize(Roles = "teacher")]
        [Route("teacher")]
        public IEnumerable<Subject> GetSubjectForTeacher()
        {
            return _subjects.GetAll();
        }

        [HttpGet]
        [Route("getOne")]
        public Subject GetOne([FromQuery] string subjectName)
        {
            return _subjects.GetOneOrDefault(s => s.Name == subjectName);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateSubject(CreateDto command)
        {
            if (command.Name == null)
            {
                return BadRequest(new {message = "Subject name is null"});
            }
            
            var subject = new Subject()
            {
                Name = command.Name
            };

            _subjects.Add(subject);
            _subjects.SaveChanges();

            return Ok(new {Message = "Subject was created"});
        }
    }
}