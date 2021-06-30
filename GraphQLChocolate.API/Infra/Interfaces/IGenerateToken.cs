using GraphQLChocolate.API.Models;

namespace GraphQLChocolate.API.Infra.Interfaces
{
    public interface IGenerateToken
    {
        string Generate(User user);
    }
}
