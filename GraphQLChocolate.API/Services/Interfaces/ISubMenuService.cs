using GraphQLChocolate.API.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Services.Interfaces
{
    public interface ISubMenuService
    {
        IQueryable<SubMenu> GetAll();
        IQueryable<SubMenu> GetAll(Guid menuId);

        Task<SubMenu> Add(SubMenu subMenu);
    }
}
