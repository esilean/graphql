using GraphQLCoffe.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLCoffe.API.Services.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<Reservation>> GetAll();

        Task<Reservation> Add(Reservation reservation);
    }
}
