using Student_Book_API.Models.Domain;
using Student_Book_API.Models.DTO;
using Microsoft.EntityFrameworkCore;
namespace Student_Book_API.BookSevice
{
    public interface IBookReposi
    {
        List<BookWithAuthorPublisherDTO> GetallBook(string? filterOn = null, string?
filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000);
        BookWithAuthorPublisherDTO GetBookById(int id);
        AddBookRequestDTO AddBook(AddBookRequestDTO bookDTO);
        AddBookRequestDTO UpdateBookById(int id, AddBookRequestDTO bookDTO);
        Books? DeteleBookById(int id);
    }
}
