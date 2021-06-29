using GraphQL.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.API.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product> GetById(int id);

        Task<Product> Add(Product p);

        Task<Product> Update(int id, Product p);

        Task Delete(int id);
    }
}
