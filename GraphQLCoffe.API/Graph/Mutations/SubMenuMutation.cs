using GraphQL;
using GraphQL.Types;
using GraphQLCoffe.API.Graph.Types.Mutations;
using GraphQLCoffe.API.Graph.Types.Queries;
using GraphQLCoffe.API.Models;
using GraphQLCoffe.API.Services.Interfaces;

namespace GraphQLCoffe.API.Graph.Mutations
{
    public class SubMenuMutation : ObjectGraphType
    {
        public SubMenuMutation(ISubMenuService subMenuService)
        {
            Field<SubMenuType>(name: "createSubMenu",
                               arguments: new QueryArguments { new QueryArgument<SubMenuInputType> { Name = "subMenu" } },
                               resolve: ctx =>
                               {
                                   return subMenuService.Add(ctx.GetArgument<SubMenu>("subMenu"));
                               });
        }
    }
}
