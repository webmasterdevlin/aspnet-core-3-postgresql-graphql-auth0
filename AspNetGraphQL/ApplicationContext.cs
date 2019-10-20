using AspNetGraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetGraphQL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}