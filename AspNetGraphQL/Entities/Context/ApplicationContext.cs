using System;
using Microsoft.EntityFrameworkCore;

namespace AspNetGraphQL.Entities.Context
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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             Guid[] ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()};
             
             modelBuilder.ApplyConfiguration(new AuthorContextConfiguration(ids));
             modelBuilder.ApplyConfiguration(new BookContextConfiguration(ids));
             modelBuilder.ApplyConfiguration(new StudentContextConfiguration(ids));
        }
    }
}