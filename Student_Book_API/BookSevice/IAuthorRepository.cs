using Student_Book_API.Models.Domain;
using Student_Book_API.Models.DTO;

namespace Student_Book_API.BookSevice
{
    public interface IAuthorRepository
    {
        List<AuthorDTO> GetAll();
        AuthorDTO GetById(int id);
        AddAuthorDTO AddAuthor(AddAuthorDTO addBookDTO);
        AddAuthorDTO? Put(int id, AddAuthorDTO addBookDTO);
        Authors? Delete(int id);
    }
}
