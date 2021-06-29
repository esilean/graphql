using GraphQL.API.Graph.Mutations;
using GraphQL.API.Graph.Queries;
using GraphQL.Types;

namespace GraphQL.API.Graph.Schemas
{
    public class ProductSchema : Schema
    {
        public ProductSchema(ProductQuery productQuery,
                             ProductMutation productMutation)
        {
            Query = productQuery;
            Mutation = productMutation;
        }
    }
}
