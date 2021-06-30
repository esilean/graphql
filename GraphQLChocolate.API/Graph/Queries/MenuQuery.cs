using GraphQLChocolate.API.Models;
using GraphQLChocolate.API.Services.Interfaces;
using System.Linq;

namespace GraphQLChocolate.API.Graph.Queries
{
    public class MenuQuery
    {
        private readonly IMenuService _menuService;

        public MenuQuery(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public IQueryable<Menu> Menus() => _menuService.GetAll();

    }
}
