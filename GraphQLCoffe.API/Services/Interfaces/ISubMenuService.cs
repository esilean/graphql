using GraphQLCoffe.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLCoffe.API.Services.Interfaces
{
    public interface ISubMenuService
    {
        Task<IEnumerable<SubMenu>> GetAll();
        Task<IEnumerable<SubMenu>> GetAll(int menuId);

        Task<SubMenu> Add(SubMenu subMenu);
    }
}
