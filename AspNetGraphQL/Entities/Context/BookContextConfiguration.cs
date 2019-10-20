using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetGraphQL.Entities.Context
{
    public class BookContextConfiguration : IEntityTypeConfiguration<Book>
    {
        private Guid[] _ids;

        public BookContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Book> builder)
        {
//            builder.HasData(new Book{}, new Book{}, new Book{});
        }
    }
}