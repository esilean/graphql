using GraphQLChocolate.API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Services.Interfaces
{
    public interface IReservationService
    {
        IQueryable<Reservation> GetAll();

        Task<Reservation> Add(Reservation reservation);
    }
}
