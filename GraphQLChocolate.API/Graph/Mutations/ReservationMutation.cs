using GraphQLChocolate.API.Models;
using GraphQLChocolate.API.Services.Interfaces;
using HotChocolate;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Graph.Mutations
{
    public class ReservationMutation
    {

        public async Task<Reservation> CreateReservation([Service] IReservationService reservationService,
                                                          Reservation reservation)
        {

            var created = await reservationService.Add(reservation);
            return created;
        }

    }
}
