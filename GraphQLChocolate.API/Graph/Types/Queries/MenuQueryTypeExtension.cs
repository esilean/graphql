using GraphQLChocolate.API.Graph.Queries;
using HotChocolate.Types;

namespace GraphQLChocolate.API.Graph.Types.Queries
{
    public class MenuQueryTypeExtension : ObjectTypeExtension
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Query");

            descriptor.Field("Menus")
                        .ResolveWith<MenuQuery>(_ => _.Menus())
                        .Name("menus")
                        .Authorize(new[] { "user", "admin" })
                        .UsePaging()
                        .UseProjection()
                        .UseFiltering()
                        .UseSorting();
        }
    }
}
