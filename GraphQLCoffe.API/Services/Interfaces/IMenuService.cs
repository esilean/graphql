using GraphQLCoffe.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLCoffe.API.Services.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<Menu>> GetAll();

        Task<Menu> Add(Menu menu);
    }
}
