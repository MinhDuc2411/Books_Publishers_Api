using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Student_Book_API.Models.Domain;
using Student_Book_API.Models.DTO;

namespace Student_Book_API.Data

{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Books_Authors> Books_Authors { get;set; }
        public DbSet<Publishers> Publishers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Books_Authors>()
            .HasOne(a => a.Books)
            .WithMany(ab => ab.Books_Authors)
            .HasForeignKey(ai => ai.BookID);
            modelBuilder.Entity<Books_Authors>()
                .HasOne(a => a.Authors)
                .WithMany(ab=>ab.Books_Authors)
                .HasForeignKey(ai=>ai.AuthorID);
        }

        internal object Select(Func<object, BookWithAuthorPublisherDTO> value)
        {
            throw new NotImplementedException();
        }

        public DbSet<BookWithAuthorPublisherDTO> BookWithAuthorPublisherDTO { get; set; } = default!;
        public DbSet<Student_Book_API.Models.DTO.AuthorDTO> AuthorDTO { get; set; } = default!;
    }
}
