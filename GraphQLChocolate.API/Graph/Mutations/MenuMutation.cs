using GraphQLChocolate.API.Models;
using GraphQLChocolate.API.Services.Interfaces;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Graph.Mutations
{
    public class MenuMutation
    {
        private readonly IMenuService _menuService;
        private readonly ITopicEventSender _eventSender;

        public MenuMutation(IMenuService menuService,
                            ITopicEventSender eventSender)
        {
            _menuService = menuService;
            _eventSender = eventSender;
        }

        public async Task<Menu> CreateMenu(Menu menu)
        {
            if (string.IsNullOrWhiteSpace(menu.Name))
                throw new QueryException("Name cannot be null or empty.");

            var created = await _menuService.Add(menu);

            await _eventSender.SendAsync("MenuCreated", created);
            return created;
        }

    }
}
