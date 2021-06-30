using GraphQLChocolate.API.Graph.Mutations;
using HotChocolate.Types;

namespace GraphQLChocolate.API.Graph.Types.Queries
{
    public class MenuMutationTypeExtension : ObjectTypeExtension
    {

        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Mutation");

            descriptor.Field("CreateMenu")
                        .ResolveWith<MenuMutation>(m => m.CreateMenu(default))
                        .Argument("menu", _ => _.Type<MenuInputType>())
                        .Name("createMenu");
        }

    }
}
