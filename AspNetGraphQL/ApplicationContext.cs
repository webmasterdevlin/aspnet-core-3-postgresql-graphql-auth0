using AspNetGraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetGraphQL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}