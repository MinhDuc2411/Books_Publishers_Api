using Student_Book_API.Models.Domain;
using Student_Book_API.Models.DTO;
using Microsoft.EntityFrameworkCore;
namespace Student_Book_API.BookSevice
{
    public interface IBookReposi
    {
        List<BookWithAuthorPublisherDTO> GetallBook();
        BookWithAuthorPublisherDTO GetBookById(int id);
        AddBookRequestDTO AddBook(AddBookRequestDTO bookDTO);
        AddBookRequestDTO UpdateBookById(int id, AddBookRequestDTO bookDTO);
        Books? DeteleBookById(int id);
    }
}
