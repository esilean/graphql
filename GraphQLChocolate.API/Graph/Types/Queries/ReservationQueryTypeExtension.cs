using GraphQLChocolate.API.Graph.Queries;
using HotChocolate.Types;

namespace GraphQLChocolate.API.Graph.Types.Queries
{
    public class ReservationQueryTypeExtension : ObjectTypeExtension
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Query");

            descriptor.Field("Reservations")
                        .ResolveWith<ReservationQuery>(_ => _.Reservations())
                        .Name("reservations");
        }
    }
}
