using System.ComponentModel.DataAnnotations;

namespace REST_API_TEMPLATE.Models
{
    public class addBookDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool isRead {  get; set; }
        public DateTime? dateRead {  get; set; }
        [Range( 0, 5, ErrorMessage="From 0 to 5")]
        public int? rata { get; set; }
        public string genre { get; set; }
        public string ConverUrl { get; set; }
        public DateTime dateAdded { get; set; }
        public int publisherID { get; set; }
       
    }
}
