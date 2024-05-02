using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Book_API.BookSevice;
using Student_Book_API.Data;
using Student_Book_API.Models.DTO;

namespace Student_Book_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorDTOesController : ControllerBase
    {
        private readonly DataDbContext _context;
        private readonly IAuthorRepository _authorRepository;
        public AuthorDTOesController(DataDbContext context,IAuthorRepository authorRepository)
        {
            _context = context;
            _authorRepository = authorRepository;
        }

        // GET: api/AuthorDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthorDTO()
        {
            var allauthor = _authorRepository.GetAll();
            return Ok(allauthor);
        }

        // GET: api/AuthorDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthorDTO(int Id)
        {
            var getId = _authorRepository.GetById(Id);
            return Ok(getId);
        }

        // PUT: api/AuthorDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AddAuthorDTO addAuthorDTO)
        {
            var PutAuthor = _authorRepository.Put(id, addAuthorDTO);
            return Ok(PutAuthor);
        }

        // POST: api/AuthorDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Push([FromBody] AddAuthorDTO addAuthor)
        {
            var PushAuthor = _authorRepository.AddAuthor(addAuthor);
            return Ok(PushAuthor);
        }

        // DELETE: api/AuthorDTOes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Delt = _authorRepository.Delete(id);
            return Ok(Delt);
        }       
    }
}
