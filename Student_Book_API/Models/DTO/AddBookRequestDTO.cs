using Student_Book_API.Models.Domain;
namespace Student_Book_API.Models.DTO
{
    public class AddBookRequestDTO
    {
        public string ?Title { get; set; }
        public string? Description { get; set; }
        public bool  IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int   Rate { get; set; }
        public string? Geren {  get; set; }
        public string ?CoverUrl {  get; set; }
        public DateTime DataAdded {  get; set; }
        public int PubshersId{ get; set; }
        public List<int>? AuthorIds { get; set; }
    }
}
