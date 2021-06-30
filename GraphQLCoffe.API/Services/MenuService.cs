using GraphQLCoffe.API.Data;
using GraphQLCoffe.API.Models;
using GraphQLCoffe.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLCoffe.API.Services
{
    public class MenuService : IMenuService
    {
        private readonly CoffeDbContext _ctx;

        public MenuService(CoffeDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Menu> Add(Menu menu)
        {
            var added = await _ctx.Menus.AddAsync(menu);

            await _ctx.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<IEnumerable<Menu>> GetAll()
        {
            return await _ctx.Menus.ToListAsync();
        }
    }
}
