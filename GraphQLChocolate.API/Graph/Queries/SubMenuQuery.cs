using GraphQLChocolate.API.Models;
using GraphQLChocolate.API.Services.Interfaces;
using System;
using System.Linq;

namespace GraphQLChocolate.API.Graph.Queries
{
    public class SubMenuQuery
    {
        private readonly ISubMenuService _subMenuService;

        public SubMenuQuery(ISubMenuService subMenuService)
        {
            _subMenuService = subMenuService;
        }

        public IQueryable<SubMenu> SubMenus() => _subMenuService.GetAll();

        public IQueryable<SubMenu> SubMenus(Guid menuId) => _subMenuService.GetAll(menuId);

    }
}
