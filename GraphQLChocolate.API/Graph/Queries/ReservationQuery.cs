using GraphQLChocolate.API.Models;
using GraphQLChocolate.API.Services.Interfaces;
using System.Linq;

namespace GraphQLChocolate.API.Graph.Queries
{
    public class ReservationQuery
    {
        private readonly IReservationService _reservationService;

        public ReservationQuery(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IQueryable<Reservation> Reservations() => _reservationService.GetAll();

    }
}
