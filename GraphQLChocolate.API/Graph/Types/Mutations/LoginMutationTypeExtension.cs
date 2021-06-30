using GraphQLChocolate.API.Graph.Mutations;
using HotChocolate.Types;

namespace GraphQLChocolate.API.Graph.Types.Queries
{
    public class LoginMutationTypeExtension : ObjectTypeExtension
    {

        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Mutation");

            descriptor.Field("Login")
                        .ResolveWith<AuthMutation>(m => m.Login(default))
                        .Argument("login", _ => _.Type<LoginInputType>())
                        .Name("login");
        }

    }
}
