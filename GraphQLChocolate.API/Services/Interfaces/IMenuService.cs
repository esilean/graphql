using GraphQLChocolate.API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Services.Interfaces
{
    public interface IMenuService
    {
        IQueryable<Menu> GetAll();

        Task<Menu> Add(Menu menu);
    }
}
