using GraphQLChocolate.API.Graph.Mutations;
using HotChocolate.Types;

namespace GraphQLChocolate.API.Graph.Types.Queries
{
    public class SubMenuMutationTypeExtension : ObjectTypeExtension
    {

        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Mutation");

            descriptor.Field("CreateSubMenu")
                        .ResolveWith<SubMenuMutation>(m => m.CreateSubMenu(default))
                        .Argument("subMenu", _ => _.Type<SubMenuInputType>())
                        .Name("createSubMenu");
        }

    }
}
