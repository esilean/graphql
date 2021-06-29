using GraphQL.API.Graph.Types;
using GraphQL.API.Interfaces;
using GraphQL.API.Models;
using GraphQL.Types;

namespace GraphQL.API.Graph.Mutations
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProductService productService)
        {
            Field<ProductType>(name: "createProduct",
                               arguments: new QueryArguments { new QueryArgument<ProductInputType> { Name = "product" } },
                               resolve: ctx =>
                               {
                                   return productService.Add(ctx.GetArgument<Product>("product"));
                               });

            Field<ProductType>(name: "updateProduct",
                               arguments: new QueryArguments
                               {
                                   new QueryArgument<IntGraphType> { Name = "id" },
                                   new QueryArgument<ProductInputType> { Name = "product" }
                               },
                               resolve: ctx =>
                               {
                                   return productService.Update(id: ctx.GetArgument<int>("id"),
                                                                p: ctx.GetArgument<Product>("product"));
                               });

            Field<StringGraphType>(name: "deleteProduct",
                               arguments: new QueryArguments
                               {
                                   new QueryArgument<IntGraphType> { Name = "id" },
                               },
                               resolve: ctx =>
                               {
                                   var id = ctx.GetArgument<int>("id");
                                   productService.Delete(id);
                                   return $"Deleted {id}";
                               });

        }
    }
}
