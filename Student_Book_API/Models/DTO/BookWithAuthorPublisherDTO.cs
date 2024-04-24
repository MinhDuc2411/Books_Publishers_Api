using Student_Book_API.Models.Domain;
namespace Student_Book_API.Models.DTO
{
    public class BookWithAuthorPublisherDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? isRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string? Genre { get; set; }
        public string? Url { get; set; }
        public DateTime DateAdd { get; set; }
        public string? PublisherName { get; set; }
        public List<string>? AuthorName { get; set; }
    }
}
