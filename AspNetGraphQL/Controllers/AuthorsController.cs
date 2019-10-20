using System;
using System.Linq;
using AspNetGraphQL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetGraphQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AuthorsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var authors = _context.Authors;
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var author = _context.Authors
                .Where(a => a.Id == id)
                .Include(b => b.Books)
                .FirstOrDefault();

            return Ok(author);
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody] Author author)
        {
            _context.Add(author);
            _context.SaveChanges();
            return CreatedAtRoute(nameof(GetById), new {id = author.Id}, author);
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _context.Remove(_context.Authors.Find(id));
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Put([FromRoute] Guid id, [FromBody] Author author)
        {
            if (!_context.Authors.Any(a => a.Id == id)) return BadRequest();
            _context.Update(author);
            _context.SaveChanges();
            return Ok(author);
        }
    }
}