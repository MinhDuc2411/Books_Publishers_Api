using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Book_API.BookSevice;
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
        private readonly IBookReposi _iReposi;
        public BooksController(DataDbContext context,IBookReposi bookReposi)
        {
            _context = context;
            _iReposi = bookReposi;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            //sử dụng bookReposi 
            var allbook=_iReposi.GetallBook();
            return Ok(allbook);
        }
        [HttpGet]
        [Route("id")]
        public IActionResult GetBookById([FromRoute]int id)
        {
            var bookWithIdDTO = _iReposi.GetBookById(id);
            return Ok(bookWithIdDTO);
        }
        [HttpPost]
        public IActionResult AddBooks([FromBody]AddBookRequestDTO addBookRequestDTO)
        {
            var bookAdd = _iReposi.AddBook(addBookRequestDTO);
            return Ok(bookAdd);
        }
        [HttpPut]
        public IActionResult UpdateBookById(int id, [FromBody]AddBookRequestDTO bookDTO)
        {
            var updateBook=_iReposi.UpdateBookById(id, bookDTO);
            return Ok(updateBook);
        }
        [HttpDelete]
        public IActionResult DeleteBookById(int id)
        {
            var deteleBook= _iReposi.DeteleBookById(id);
            return Ok(deteleBook);
        }
    }
}
