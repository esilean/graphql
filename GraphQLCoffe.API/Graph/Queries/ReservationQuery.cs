using GraphQL.Types;
using GraphQLCoffe.API.Graph.Types.Queries;
using GraphQLCoffe.API.Services.Interfaces;

namespace GraphQLCoffe.API.Graph.Queries
{
    public class ReservationQuery : ObjectGraphType
    {
        public ReservationQuery(IReservationService reservationService)
        {
            Field<ListGraphType<ReservationType>>(name: "reservations",
                                              resolve: (context) =>
                                              {
                                                  return reservationService.GetAll();
                                              });
        }
    }
}
