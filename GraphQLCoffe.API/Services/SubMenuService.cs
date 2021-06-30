using GraphQLCoffe.API.Data;
using GraphQLCoffe.API.Models;
using GraphQLCoffe.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCoffe.API.Services
{
    public class SubMenuService : ISubMenuService
    {
        private readonly CoffeDbContext _ctx;

        public SubMenuService(CoffeDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<SubMenu> Add(SubMenu subMenu)
        {
            var added = await _ctx.SubMenus.AddAsync(subMenu);

            await _ctx.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<IEnumerable<SubMenu>> GetAll()
        {
            return await _ctx.SubMenus.ToListAsync();
        }

        public async Task<IEnumerable<SubMenu>> GetAll(int menuId)
        {
            return await _ctx.SubMenus.Where(x => x.MenuId == menuId).ToListAsync();
        }
    }
}
