using GraphQLCoffe.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLCoffe.API.Data
{
    public class CoffeDbContext : DbContext
    {
        public CoffeDbContext(DbContextOptions<CoffeDbContext> options) : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
