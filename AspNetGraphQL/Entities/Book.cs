using System;
namespace AspNetGraphQL.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Published { get; set; }
        public string Genre { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
