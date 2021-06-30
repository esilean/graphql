using GraphQLChocolate.API.Data;
using GraphQLChocolate.API.Models;
using GraphQLChocolate.API.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ChocoDbContext _ctx;

        public ReservationService(ChocoDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Reservation> Add(Reservation reservation)
        {
            var added = await _ctx.Reservations.AddAsync(reservation);

            await _ctx.SaveChangesAsync();
            return added.Entity;
        }

        public IQueryable<Reservation> GetAll()
        {
            return _ctx.Reservations.AsQueryable();
        }
    }
}
