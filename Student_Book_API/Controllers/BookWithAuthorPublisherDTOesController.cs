using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Book_API.DTO;
using Student_Book_API.Data;

namespace Student_Book_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookWithAuthorPublisherDTOesController : ControllerBase
    {
        private readonly DataDbContext _context;

        public BookWithAuthorPublisherDTOesController(DataDbContext context)
        {
            _context = context;
        }
        //Get http://localhost:port/api/get-all-books
        [HttpGet("get-all-book")]
        public IActionResult GetAll()
        {

            return Ok();
        }
        // GET: api/BookWithAuthorPublisherDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookWithAuthorPublisherDTO>>> GetBookWithAuthorPublisherDTO()
        {
            return await _context.BookWithAuthorPublisherDTO.ToListAsync();
        }

        // GET: api/BookWithAuthorPublisherDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookWithAuthorPublisherDTO>> GetBookWithAuthorPublisherDTO(int id)
        {
            var bookWithAuthorPublisherDTO = await _context.BookWithAuthorPublisherDTO.FindAsync(id);

            if (bookWithAuthorPublisherDTO == null)
            {
                return NotFound();
            }

            return bookWithAuthorPublisherDTO;
        }

        // PUT: api/BookWithAuthorPublisherDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookWithAuthorPublisherDTO(int id, BookWithAuthorPublisherDTO bookWithAuthorPublisherDTO)
        {
            if (id != bookWithAuthorPublisherDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookWithAuthorPublisherDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookWithAuthorPublisherDTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookWithAuthorPublisherDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookWithAuthorPublisherDTO>> PostBookWithAuthorPublisherDTO(BookWithAuthorPublisherDTO bookWithAuthorPublisherDTO)
        {
            _context.BookWithAuthorPublisherDTO.Add(bookWithAuthorPublisherDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookWithAuthorPublisherDTO", new { id = bookWithAuthorPublisherDTO.Id }, bookWithAuthorPublisherDTO);
        }

        // DELETE: api/BookWithAuthorPublisherDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookWithAuthorPublisherDTO(int id)
        {
            var bookWithAuthorPublisherDTO = await _context.BookWithAuthorPublisherDTO.FindAsync(id);
            if (bookWithAuthorPublisherDTO == null)
            {
                return NotFound();
            }

            _context.BookWithAuthorPublisherDTO.Remove(bookWithAuthorPublisherDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookWithAuthorPublisherDTOExists(int id)
        {
            return _context.BookWithAuthorPublisherDTO.Any(e => e.Id == id);
        }
    }
}
