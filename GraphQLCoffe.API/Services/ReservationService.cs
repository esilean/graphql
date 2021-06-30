using GraphQLCoffe.API.Data;
using GraphQLCoffe.API.Models;
using GraphQLCoffe.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLCoffe.API.Services
{
    public class ReservationService : IReservationService
    {
        private readonly CoffeDbContext _ctx;

        public ReservationService(CoffeDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Reservation> Add(Reservation reservation)
        {
            var added = await _ctx.Reservations.AddAsync(reservation);

            await _ctx.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await _ctx.Reservations.ToListAsync();
        }
    }
}
