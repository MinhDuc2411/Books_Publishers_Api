
using Microsoft.EntityFrameworkCore;
using Student_Book_API.Data;
using Student_Book_API.Models.Domain;
using Student_Book_API.Models.DTO;
namespace Student_Book_API.BookSevice
{
    public class BookReposi : IBookReposi
    {
        private readonly DataDbContext _context;
        public BookReposi(DataDbContext context)
        {
            _context = context;
        }

        public BookWithAuthorPublisherDTO GetBookById(int id)
        {
            var bookWithDomain = _context.Books.Where(n => n.Id == id);
            var bookwithIdDTO = bookWithDomain.Select(Books => new BookWithAuthorPublisherDTO()
            {
                Id = Books.Id,
                Title = Books.Title,
                Description = Books.Description,
                isRead = Books.IsRead,
                DateRead = Books.DateRead,
                Rate = Books.Rate,
                Genre = Books.Genre,
                Url = Books.ConverUrl,
                PublisherId = Books.Publisher.Name,
                AuthorName = Books.Books_Authors.Select(n => n.Authors.FullName).ToList()
            }).FirstOrDefault();
            return bookwithIdDTO;
        }

        public List<BookWithAuthorPublisherDTO> GetallBook()
        {
            var allBooksDTO = _context.Books.Select(Books => new BookWithAuthorPublisherDTO()
            {
                Id = Books.Id,
                Title = Books.Title,
                Description = Books.Description,
                isRead = Books.IsRead,
                DateRead = Books.DateRead,
                Rate = Books.Rate,
                Genre = Books.Genre,
                Url = Books.ConverUrl,
                PublisherId = Books.Publisher.Name,
                AuthorName = Books.Books_Authors.Select(n => n.Authors.FullName).ToList()
            }).ToList();
            return allBooksDTO;
        }

        public AddBookRequestDTO AddBook(AddBookRequestDTO addBookRequestDTO)
        {
            var bookdomainModel = new Books
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
            _context.Books.Add(bookdomainModel);
            _context.SaveChanges();
            foreach (var Id in addBookRequestDTO.AuthorIds)
            {
                var _book_author = new Books_Authors()
                {
                    BookID = bookdomainModel.Id,
                    AuthorID = Id
                };

                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
            return addBookRequestDTO;
        }

        public AddBookRequestDTO UpdateBookById(int id, AddBookRequestDTO bookDTO)
        {
            var bookdomain = _context.Books.FirstOrDefault(n => n.Id == id);
            if (bookdomain != null)
            {
                bookdomain.Title = bookDTO.Title;
                bookdomain.Description = bookDTO.Description;
                bookdomain.IsRead = bookDTO.IsRead;
                bookdomain.DateRead = bookDTO.DateRead;
                bookdomain.Rate = bookDTO.Rate;
                bookdomain.Genre = bookDTO.Geren;
                bookdomain.ConverUrl = bookDTO.CoverUrl;
                bookdomain.DateAdded = bookDTO.DataAdded;
                bookdomain.PublisherlId = bookDTO.PubshersId;
                _context.SaveChanges();
            }
            var authorDomain = _context.Books_Authors.Where(k => k.BookID == id).ToList();
            if (authorDomain != null)
            {
                _context.Books_Authors.RemoveRange(authorDomain);
                _context.SaveChanges();
            }
            foreach (var authorid in bookDTO.AuthorIds)
            {
                var _book_author = new Books_Authors()
                {
                    BookID = id,
                    AuthorID = authorid
                };
                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
            return bookDTO;
        }

        Books? IBookReposi.DeteleBookById(int id)
        {
            var bookDomain = _context.Books.FirstOrDefault(l => l.Id == id);
            if (bookDomain != null)
            {
                _context.Books.Remove(bookDomain);
                _context.SaveChanges();
            }
            return bookDomain;
        }
    }
}
