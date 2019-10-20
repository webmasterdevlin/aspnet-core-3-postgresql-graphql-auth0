using System.Collections.Generic;

namespace AspNetGraphQL.Entities
{
    public class Author
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}