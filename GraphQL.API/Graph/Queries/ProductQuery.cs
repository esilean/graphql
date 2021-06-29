using GraphQL.API.Graph.Types;
using GraphQL.API.Interfaces;
using GraphQL.Types;

namespace GraphQL.API.Graph.Queries
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProductService productService)
        {
            Field<ListGraphType<ProductType>>(name: "products",
                                              resolve: (context) =>
                                                {
                                                    return productService.GetAll();
                                                });

            Field<ProductType>(name: "product",
                               arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                               resolve: (ctx) =>
                                {
                                    return productService.GetById(ctx.GetArgument<int>("id"));
                                });
        }
    }
}
