using GraphQL.API.Data;
using GraphQL.API.Interfaces;
using GraphQL.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.API.Services
{
    public class ProductService : IProductService
    {
        private readonly DataDbContext _ctx;

        public ProductService(DataDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _ctx.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _ctx.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> Add(Product p)
        {
            var result = await _ctx.Products.AddAsync(p);

            await _ctx.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(int id)
        {
            var product = await GetById(id);
            if (product != null)
            {
                _ctx.Remove(product);
                _ctx.SaveChanges();
            }
        }

        public async Task<Product> Update(int id, Product p)
        {
            var product = await GetById(id);
            if (product != null)
            {
                product.Name = p.Name;
                product.Price = p.Price;
                await _ctx.SaveChangesAsync();
            }

            return product;
        }
    }
}
