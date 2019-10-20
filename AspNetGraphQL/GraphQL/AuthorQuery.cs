using System;
using System.Collections.Generic;
using System.Linq;
using AspNetGraphQL.Entities;
using AspNetGraphQL.Entities.Context;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace AspNetGraphQL.GraphQL
{
    public class AuthorQuery : ObjectGraphType
    {
        public AuthorQuery(ApplicationContext db)
        {
            Field<AuthorType>("Author",
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                    {Name = "id", Description = "The ID of the Author."}), resolve:
                context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    Author author = db
                        .Authors
                        .Include(a => a.Books)
                        .FirstOrDefault(a => a.Id == id);
                    return author;
                });
            
            Field<ListGraphType<AuthorType>>("Authors", resolve: context =>
            {
                IIncludableQueryable<Author, List<Book>> authors = db.Authors.Include(a => a.Books);
                return authors;
            });
        }
    }
}