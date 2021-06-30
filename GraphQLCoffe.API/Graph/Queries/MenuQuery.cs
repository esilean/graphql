using GraphQL.Types;
using GraphQLCoffe.API.Graph.Types.Queries;
using GraphQLCoffe.API.Services.Interfaces;

namespace GraphQLCoffe.API.Graph.Queries
{
    public class MenuQuery : ObjectGraphType
    {
        public MenuQuery(IMenuService menuService)
        {
            Field<ListGraphType<MenuType>>(name: "menus",
                                              resolve: (context) =>
                                              {
                                                  return menuService.GetAll();
                                              });
        }
    }
}
