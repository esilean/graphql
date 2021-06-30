using GraphQL.Types;
using GraphQLCoffe.API.Models;
using GraphQLCoffe.API.Services.Interfaces;

namespace GraphQLCoffe.API.Graph.Types.Queries
{
    public class MenuType : ObjectGraphType<Menu>
    {
        public MenuType(ISubMenuService subMenuService)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.ImageUrl);
            Field<ListGraphType<SubMenuType>>(name: "submenus",
                                              resolve: (context) =>
                                              {
                                                  return subMenuService.GetAll(context.Source.Id);
                                              });
        }
    }
}
