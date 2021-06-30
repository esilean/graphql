using GraphQL.Types;
using GraphQLCoffe.API.Models;

namespace GraphQLCoffe.API.Graph.Types.Queries
{
    public class SubMenuType : ObjectGraphType<SubMenu>
    {
        public SubMenuType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Description);
            Field(x => x.ImageUrl);
            Field(x => x.Price);
            Field(x => x.MenuId);
        }
    }
}
