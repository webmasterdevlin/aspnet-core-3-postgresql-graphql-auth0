using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetGraphQL.Entities.Context
{
    public class StudentContextConfiguration : IEntityTypeConfiguration<Student>
    {
        private Guid[] _ids;

        public StudentContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(new Student {Id = _ids[0], Name = "Devlin Duldulao", Age = 34},
                new Student {Id = _ids[1], Name = "Jef Bezos", Age = 50},
                new Student {Id = _ids[2], Name = "Elon Musk", Age = 45});
        }
    }
}