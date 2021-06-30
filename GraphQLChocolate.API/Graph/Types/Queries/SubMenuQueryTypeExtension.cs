using GraphQLChocolate.API.Graph.Queries;
using HotChocolate.Types;

namespace GraphQLChocolate.API.Graph.Types.Queries
{
    public class SubMenuQueryTypeExtension : ObjectTypeExtension
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Query");

            descriptor.Field("SubMenus")
                        .ResolveWith<SubMenuQuery>(_ => _.SubMenus())
                        .Name("submenus")
                        .Authorize("user-policy");
        }
    }
}
