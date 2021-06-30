using GraphQLChocolate.API.Graph.Mutations;
using HotChocolate.Types;

namespace GraphQLChocolate.API.Graph.Types.Queries
{
    public class UserMutationTypeExtension : ObjectTypeExtension
    {

        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Mutation");

            descriptor.Field("CreateUser")
                        .ResolveWith<UserMutation>(m => m.CreateUser(default))
                        .Argument("user", _ => _.Type<UserInputType>())
                        .Name("createUser");
        }

    }
}
