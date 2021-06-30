using GraphQLChocolate.API.Models.Auth;
using GraphQLChocolate.API.Services.Interfaces;

namespace GraphQLChocolate.API.Graph.Mutations
{
    public class AuthMutation
    {
        private readonly IAuthService _authService;

        public AuthMutation(IAuthService authService)
        {
            _authService = authService;
        }

        public AuthToken Login(AuthLogin login)
        {
            var created = _authService.Login(login);
            return created;
        }

    }
}
