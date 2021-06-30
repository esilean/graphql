using GraphQL;
using GraphQL.Types;
using GraphQLCoffe.API.Graph.Types.Queries;
using GraphQLCoffe.API.Services.Interfaces;

namespace GraphQLCoffe.API.Graph.Queries
{
    public class SubMenuQuery : ObjectGraphType
    {
        public SubMenuQuery(ISubMenuService subMenuService)
        {
            Field<ListGraphType<SubMenuType>>(name: "submenus",
                                              resolve: (context) =>
                                              {
                                                  return subMenuService.GetAll();
                                              });

            Field<ListGraphType<SubMenuType>>(name: "submenusByMenuId",
                                              arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                                              resolve: (ctx) =>
                                              {
                                                  return subMenuService.GetAll(ctx.GetArgument<int>("id"));
                                              });
        }
    }
}
