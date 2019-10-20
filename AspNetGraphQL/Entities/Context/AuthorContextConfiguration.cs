using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetGraphQL.Entities.Context
{
    public class AuthorContextConfiguration : IEntityTypeConfiguration<Author>
    {
        private Guid[] _ids;

        public AuthorContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }
        
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(new Author{Id = _ids[0], Name = "Leo Tolstoy"}, new Author{Id = _ids[1], Name = "William Shakespeare"}, new Author{Id = _ids[2], Name = "Mark Twain"});
        }
    }
}