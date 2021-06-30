using GraphQLChocolate.API.Models;
using HotChocolate.Types;

namespace GraphQLChocolate.API.Graph.Types.Queries
{
    public class MenuInputType : InputObjectType<Menu>
    {

        protected override void Configure(IInputObjectTypeDescriptor<Menu> descriptor)
        {
            descriptor.Name("MenuInput");

            descriptor.Field(_ => _.Id)
                        .Type<IntType>()
                        .Name("id");

            descriptor.Field(_ => _.Name)
                        .Type<StringType>()
                        .Name("name");

            descriptor.Field(_ => _.ImageUrl)
                        .Type<StringType>()
                        .Name("imageUrl");
        }
    }
}
