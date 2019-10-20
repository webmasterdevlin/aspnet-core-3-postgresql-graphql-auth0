using System;
using AspNetGraphQL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetGraphQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public StudentsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students = _context.Students;
            return Ok(students);
        }

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult GetById(string id)
        {
            var student = _context.Find<Student>(Guid.Parse(id));

            return Ok(student);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Student student)
        {
            _context.Add(student);

            _context.SaveChanges();

            return CreatedAtRoute(nameof(GetById), new { id = student.Id }, student);
        }
    }
}