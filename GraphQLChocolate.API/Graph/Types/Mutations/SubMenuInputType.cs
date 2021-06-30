using GraphQLChocolate.API.Models;
using HotChocolate.Types;

namespace GraphQLChocolate.API.Graph.Types.Queries
{
    public class SubMenuInputType : InputObjectType<SubMenu>
    {

        protected override void Configure(IInputObjectTypeDescriptor<SubMenu> descriptor)
        {
            descriptor.Name("SubMenuInput");

            descriptor.Field(_ => _.Id)
                        .Type<IntType>()
                        .Name("id");

            descriptor.Field(_ => _.Name)
                        .Type<StringType>()
                        .Name("name");

            descriptor.Field(_ => _.Description)
                        .Type<StringType>()
                        .Name("description");

            descriptor.Field(_ => _.ImageUrl)
                        .Type<StringType>()
                        .Name("imageUrl");

            descriptor.Field(_ => _.Price)
                        .Type<FloatType>()
                        .Name("price");

            descriptor.Field(_ => _.MenuId)
                        .Type<IntType>()
                        .Name("menuId");
        }
    }
}
