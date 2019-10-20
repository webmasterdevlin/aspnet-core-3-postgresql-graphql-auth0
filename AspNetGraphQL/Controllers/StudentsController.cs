using System;
using System.Linq;
using AspNetGraphQL.Entities;
using AspNetGraphQL.Entities.Context;
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
        //[Authorize]
        public IActionResult Post([FromBody] Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
            return CreatedAtRoute(nameof(GetById), new { id = student.Id }, student);
        }
        
        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _context.Remove(_context.Students.Find(id));
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Put([FromRoute] Guid id, [FromBody] Student student)
        {
            if (!_context.Students.Any(b => b.Id == id)) return BadRequest();
            _context.Update(student);
            _context.SaveChanges();
            return Ok(student);
        }
    }
}