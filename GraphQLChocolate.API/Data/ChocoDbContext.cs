using GraphQLChocolate.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLChocolate.API.Data
{
    public class ChocoDbContext : DbContext
    {
        public ChocoDbContext(DbContextOptions<ChocoDbContext> options) : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
