using System.ComponentModel.DataAnnotations;

namespace Student_Book_API.Models.Domain
{
    public class Books_Authors
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BookID { get; set; }
        public int AuthorID { get; set; }
        public Books Books { get; set; }
        public Authors  Authors { get; set; }
    }
}
