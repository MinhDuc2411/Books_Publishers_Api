namespace Template_mvc.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int Rate { get; set; }
        public string? Genre { get; set; }
        public string? ConverUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublisherName { get; set; }
        public string AuthorName { get; set; }

    }
}
