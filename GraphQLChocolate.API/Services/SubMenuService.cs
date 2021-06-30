using GraphQLChocolate.API.Data;
using GraphQLChocolate.API.Models;
using GraphQLChocolate.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Services
{
    public class SubMenuService : ISubMenuService
    {
        private readonly ChocoDbContext _ctx;

        public SubMenuService(ChocoDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<SubMenu> Add(SubMenu subMenu)
        {
            var added = await _ctx.SubMenus.AddAsync(subMenu);

            await _ctx.SaveChangesAsync();
            return added.Entity;
        }

        public IQueryable<SubMenu> GetAll()
        {
            return _ctx.SubMenus.AsQueryable();
        }

        public IQueryable<SubMenu> GetAll(int menuId)
        {
            return _ctx.SubMenus.Where(x => x.MenuId == menuId).AsQueryable();
        }
    }
}
