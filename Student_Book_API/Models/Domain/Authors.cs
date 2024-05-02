using System.ComponentModel.DataAnnotations;

namespace Student_Book_API.Models.Domain
{
    public class Authors
    {
        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public List<Books_Authors>? Books_Authors { get; set; }
    }
}
