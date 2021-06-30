using GraphQL;
using GraphQL.Types;
using GraphQLCoffe.API.Graph.Types.Mutations;
using GraphQLCoffe.API.Graph.Types.Queries;
using GraphQLCoffe.API.Models;
using GraphQLCoffe.API.Services.Interfaces;

namespace GraphQLCoffe.API.Graph.Mutations
{
    public class ReservationMutation : ObjectGraphType
    {
        public ReservationMutation(IReservationService reservationService)
        {
            Field<ReservationType>(name: "createReservation",
                               arguments: new QueryArguments { new QueryArgument<ReservationInputType> { Name = "reservation" } },
                               resolve: ctx =>
                               {
                                   return reservationService.Add(ctx.GetArgument<Reservation>("reservation"));
                               });
        }
    }
}
