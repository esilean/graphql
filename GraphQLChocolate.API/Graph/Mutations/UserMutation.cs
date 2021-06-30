using GraphQLChocolate.API.Models;
using GraphQLChocolate.API.Services.Interfaces;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Graph.Mutations
{
    public class UserMutation
    {
        private readonly IUserService _userService;

        public UserMutation(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> CreateUser(User user)
        {
            var created = await _userService.Add(user);
            return created;
        }

    }
}
