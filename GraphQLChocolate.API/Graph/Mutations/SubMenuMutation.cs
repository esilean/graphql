using GraphQLChocolate.API.Models;
using GraphQLChocolate.API.Services.Interfaces;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Graph.Mutations
{
    public class SubMenuMutation
    {
        private readonly ISubMenuService _subMenuService;

        public SubMenuMutation(ISubMenuService subMenuService)
        {
            _subMenuService = subMenuService;
        }

        public async Task<SubMenu> CreateSubMenu(SubMenu subMenu)
        {
            var created = await _subMenuService.Add(subMenu);
            return created;
        }

    }
}
