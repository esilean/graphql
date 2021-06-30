using GraphQLChocolate.API.Models;
using HotChocolate.Types;

namespace GraphQLChocolate.API.Graph.Types.Queries
{
    public class UserInputType : InputObjectType<User>
    {

        protected override void Configure(IInputObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Name("UserInput");

            descriptor.Field(_ => _.Id)
                        .Type<IntType>()
                        .Name("id");

            descriptor.Field(_ => _.Email)
                        .Type<StringType>()
                        .Name("email");

            descriptor.Field(_ => _.Password)
                        .Type<StringType>()
                        .Name("password");
        }
    }
}
