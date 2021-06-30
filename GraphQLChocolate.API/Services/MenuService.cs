using GraphQLChocolate.API.Data;
using GraphQLChocolate.API.Models;
using GraphQLChocolate.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Services
{
    public class MenuService : IMenuService
    {
        private readonly ChocoDbContext _ctx;

        public MenuService(ChocoDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Menu> Add(Menu menu)
        {
            var added = await _ctx.Menus.AddAsync(menu);

            await _ctx.SaveChangesAsync();
            return added.Entity;
        }

        public IQueryable<Menu> GetAll()
        {
            return _ctx.Menus
                            .Include(x => x.SubMenus)
                            .AsQueryable();
        }
    }
}
