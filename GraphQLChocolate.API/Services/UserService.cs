using GraphQLChocolate.API.Data;
using GraphQLChocolate.API.Models;
using GraphQLChocolate.API.Services.Interfaces;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Services
{
    public class UserService : IUserService
    {
        private readonly ChocoDbContext _ctx;

        public UserService(ChocoDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> Add(User user)
        {
            var added = await _ctx.Users.AddAsync(user);

            await _ctx.SaveChangesAsync();
            return added.Entity;
        }

    }
}
