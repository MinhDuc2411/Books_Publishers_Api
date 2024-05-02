using Microsoft.EntityFrameworkCore;
using Student_Book_API.Data;
using Student_Book_API.Models.Domain;
using Student_Book_API.Models.DTO;

namespace Student_Book_API.BookSevice
{
    public class AuthorRepository: IAuthorRepository
    {
        private readonly DataDbContext _dbContext;
        public AuthorRepository(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AddAuthorDTO AddAuthor(AddAuthorDTO addBookDTO)
        {
            var addAuthor = new Authors
            {
                Id = addBookDTO.Id,
                FullName = addBookDTO.Name,
            };
            _dbContext.Authors.Add(addAuthor);
            _dbContext.SaveChanges();

            return addBookDTO;
        }

        public Authors? Delete(int id)
        {
            var authorDomain = _dbContext.Authors.FirstOrDefault(n => n.Id == id);
            if (authorDomain != null)
            {
                _dbContext.Authors.Remove(authorDomain);
                _dbContext.SaveChanges();
            }
            return authorDomain;
        }

        public List<AuthorDTO> GetAll()
        {

            var allauthorDTO = _dbContext.Authors.Select(author => new AuthorDTO()
            {
                Id = author.Id,
                Name = author.FullName,
            }).ToList();
            return allauthorDTO;
        }

        public AuthorDTO GetById(int id)
        {
            var GetIdAuthor = _dbContext.Authors.Where(a => a.Id == id);
            var GetIdDTO = GetIdAuthor.Select(author => new AuthorDTO()
            {
                Id = author.Id,
                Name = author.FullName,
            }).FirstOrDefault();
            return GetIdDTO;
        }

        public AddAuthorDTO? Put(int id, AddAuthorDTO addBookDTO)
        {
            var authormainDomain = _dbContext.Authors.FirstOrDefault(n => n.Id == id);
            if (authormainDomain != null)
            {
                authormainDomain.Id = id;
                authormainDomain.FullName = addBookDTO.Name;
                _dbContext.SaveChanges();
            }
            var authorDomain = _dbContext.Books_Authors.Where(a => a.AuthorID == id).ToList();
            if (authorDomain != null)
            {
                _dbContext.Books_Authors.RemoveRange(authorDomain);
                _dbContext.SaveChanges();
            }
            return addBookDTO;
        }
    }

}
