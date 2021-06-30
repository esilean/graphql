using GraphQLChocolate.API.Models.Auth;

namespace GraphQLChocolate.API.Services.Interfaces
{
    public interface IAuthService
    {
        AuthToken Login(AuthLogin login);

    }
}
