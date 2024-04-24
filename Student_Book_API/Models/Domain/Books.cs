using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Student_Book_API.Models.Domain
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int Rate { get; set; }
        public string? Genre { get; set; }
        public string? ConverUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public int PublisherlId { get; set; }
        public Publishers? Publisher { get; set; }
        public List<Books_Authors>?  Books_Authors { get; set; }
    }
}
