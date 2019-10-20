using System.Threading.Tasks;
using AspNetGraphQL.Entities.Context;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetGraphQL.GraphQL
{
    [Route("graphql")]
    [ApiController]
    // [Authorize] // protect
    public class GraphQLController : Controller
    {
        private readonly ApplicationContext _db;

        public GraphQLController(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            Inputs inputs = query.Variables.ToInputs();
            var schema = new Schema
            {
                Query = new AuthorQuery(_db)
            };
            ExecutionResult result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });
            if (result.Errors?.Count > 0) return BadRequest();

            return Ok(result);
        }
    }
}