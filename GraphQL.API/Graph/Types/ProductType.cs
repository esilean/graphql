using GraphQL.API.Models;
using GraphQL.Types;

namespace GraphQL.API.Graph.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Price);
        }
    }
}
