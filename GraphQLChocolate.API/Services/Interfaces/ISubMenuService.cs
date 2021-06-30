using GraphQLChocolate.API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Services.Interfaces
{
    public interface ISubMenuService
    {
        IQueryable<SubMenu> GetAll();
        IQueryable<SubMenu> GetAll(int menuId);

        Task<SubMenu> Add(SubMenu subMenu);
    }
}
