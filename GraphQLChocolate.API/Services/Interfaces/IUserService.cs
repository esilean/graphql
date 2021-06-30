using GraphQLChocolate.API.Models;
using System.Threading.Tasks;

namespace GraphQLChocolate.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Add(User user);
    }
}
