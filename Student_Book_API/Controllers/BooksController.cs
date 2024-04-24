using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Book_API.Data;
using Student_Book_API.Models.Domain;
using Student_Book_API.Models.DTO;

namespace Student_Book_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DataDbContext _context;

        public BooksController(DataDbContext context)
        {
            _context = context;
        }       
        //Get http://localhost:port/api/get-all-books
        [HttpGet("get-all-book")]
        public IActionResult GetAll()
        {
            var allBookDomain = _context.Books.ToList();
            var allBooksDTO = allBookDomain.Select(Books => new BookWithAuthorPublisherDTO()
            {
                Id = Books.Id,
                Title = Books.Title,
                Description = Books.Description,
                isRead = Books.IsRead,
                DateRead = Books.DateRead,
                Rate = Books.Rate,
                Genre = Books.Genre,
                Url = Books.ConverUrl,
                PublisherName = Books.Publisher.Name,
                AuthorName= Books.Books_Authors.Select(n=>n.Authors.FullName).ToList()
            }).ToList();
            return Ok(allBooksDTO);
        }
        [HttpGet]
        [Route("get-book-by-id/{id}")]
        public IActionResult GetBookById([FromRoute]int id)
        {
            var BookWithDomain = _context.Books.Where(n=>n.Id == id);
            if (BookWithDomain == null)
            {
                return NotFound();
            }
            var bookwithIdDTO = BookWithDomain.Select(Books=>new BookWithAuthorPublisherDTO()
            {
                Id = Books.Id,
                Title = Books.Title,
                Description = Books.Description,
                isRead = Books.IsRead,
                DateRead = Books.DateRead,
                Rate = Books.Rate,
                Genre = Books.Genre,
                Url = Books.ConverUrl,
                PublisherName = Books.Publisher.Name,
                AuthorName = Books.Books_Authors.Select(n => n.Authors.FullName).ToList()
            }).ToList();
            return Ok(bookwithIdDTO);
        }
        
        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> GetBooks(int id)
        {
            var books = await _context.Books.FindAsync(id);

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        [HttpPut]
        public IActionResult UpdateBookBBbyId(int id, [FromBody]AddBookRequestDTO bookDTO)
        {
            var bookdomain = _context.Books.FirstOrDefault(x => x.Id == id);
            if (bookdomain == null)
            {
                bookdomain.Title= bookDTO.Title;
                bookdomain.Description= bookDTO.Description;
                bookdomain .IsRead = bookDTO.IsRead;
                bookdomain.DateRead = bookDTO.DateRead;
                bookdomain.Rate =   bookDTO.Rate;
                bookdomain.Genre = bookDTO.Geren;
                bookdomain.ConverUrl = bookDTO.CoverUrl;
                bookdomain.DateAdded = bookDTO.DataAdded;
                bookdomain.PublisherlId = bookDTO.PubshersId;
                _context.SaveChanges();
            }
            var authorDomain =_context.Books_Authors.Where(k=>k.BookID==id).ToList();
            if (authorDomain != null)
            {
                _context.Books_Authors.RemoveRange(authorDomain);
                _context.SaveChanges();
            }
            foreach(var authorid in bookDTO.AuthorIds)
            {
                var _book_author = new Books_Authors()
                {
                    BookID = id,
                    AuthorID = authorid
                };
                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();                
            }
            return Ok(bookDTO);
        }
        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooks(int id, Books books)
        {
            if (id != books.Id)
            {
                return BadRequest();
            }

            _context.Entry(books).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
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
        [HttpPost]
        public IActionResult AddBook([FromBody] AddBookRequestDTO addBookRequestDTO)
        {
            var bookDomainModel = new Books
            {
                Title = addBookRequestDTO.Title,
                Description = addBookRequestDTO.Description,
                IsRead = addBookRequestDTO.IsRead,
                DateRead = addBookRequestDTO.DateRead,
                Rate = addBookRequestDTO.Rate,
                Genre = addBookRequestDTO.Geren,
                ConverUrl = addBookRequestDTO.CoverUrl,
                DateAdded = addBookRequestDTO.DataAdded,
                PublisherlId = addBookRequestDTO.PubshersId
            };
            _context.Books.Add(bookDomainModel);
            _context.SaveChanges();
            foreach (var id in addBookRequestDTO.AuthorIds)
            {
                var _book_author = new Books_Authors()
                {
                    BookID = bookDomainModel.Id,
                    AuthorID = id
                };
                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
            return Ok();
        }
        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Books>> PostBooks(Books books)
        {
            _context.Books.Add(books);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooks", new { id = books.Id }, books);
        }
        [HttpDelete]
        public IActionResult DeleteBookById(int id) 
        {
            var bookDomain = _context.Books.FirstOrDefault(l=>l.Id == id);
            if(bookDomain != null)
            {
                _context.Books.Remove(bookDomain);
                _context.SaveChanges();
            }
            return Ok();
        }
        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooks(int id)
        {
            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }

            _context.Books.Remove(books);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BooksExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
