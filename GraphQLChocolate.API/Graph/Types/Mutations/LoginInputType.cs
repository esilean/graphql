using GraphQLChocolate.API.Models.Auth;
using HotChocolate.Types;

namespace GraphQLChocolate.API.Graph.Types.Queries
{
    public class LoginInputType : InputObjectType<AuthLogin>
    {

        protected override void Configure(IInputObjectTypeDescriptor<AuthLogin> descriptor)
        {
            descriptor.Name("LoginInput");

            descriptor.Field(_ => _.Email)
                        .Type<StringType>()
                        .Name("email");

            descriptor.Field(_ => _.Password)
                        .Type<StringType>()
                        .Name("password");
        }
    }
}
