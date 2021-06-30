using GraphQL;
using GraphQL.Types;
using GraphQLCoffe.API.Graph.Types.Mutations;
using GraphQLCoffe.API.Graph.Types.Queries;
using GraphQLCoffe.API.Models;
using GraphQLCoffe.API.Services.Interfaces;

namespace GraphQLCoffe.API.Graph.Mutations
{
    public class MenuMutation : ObjectGraphType
    {
        public MenuMutation(IMenuService menuService)
        {
            Field<MenuType>(name: "createMenu",
                               arguments: new QueryArguments { new QueryArgument<MenuInputType> { Name = "menu" } },
                               resolve: ctx =>
                               {
                                   return menuService.Add(ctx.GetArgument<Menu>("menu"));
                               });
        }
    }
}
