using GraphQLChocolate.API.Data;
using GraphQLChocolate.API.Infra.Interfaces;
using GraphQLChocolate.API.Models.Auth;
using GraphQLChocolate.API.Services.Interfaces;
using System.Linq;

namespace GraphQLChocolate.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly ChocoDbContext _ctx;
        private readonly IGenerateToken _generateToken;

        public AuthService(ChocoDbContext ctx,
                           IGenerateToken generateToken)
        {
            _ctx = ctx;
            _generateToken = generateToken;
        }

        public AuthToken Login(AuthLogin login)
        {
            var user = _ctx.Users.FirstOrDefault(x => x.Email == login.Email);

            if (user == null)
                return null;

            if (user.Password != login.Password)
                return null;

            return new AuthToken
            {
                Token = _generateToken.Generate(user)
            };
        }


    }
}
