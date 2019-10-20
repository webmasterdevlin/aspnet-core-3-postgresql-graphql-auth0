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
    public class BooksController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public BooksController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = _context.Books;
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            return Ok(book);
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody] Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return CreatedAtRoute(nameof(GetById), new {id = book.Id}, book);
        }

        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _context.Remove(_context.Books.Find(id));
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        //[Authorize]
        public IActionResult Put([FromRoute] Guid id, [FromBody] Book book)
        {
            if (!_context.Books.Any(b => b.Id == id)) return BadRequest();
            _context.Update(book);
            _context.SaveChanges();
            return Ok(book);
        }
    }
}