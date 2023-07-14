using CEUDWebAPI.Domain.Entities;
using CEUDWebAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.ComponentModel;

namespace CRUDWebAPI.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public void DeleteProductAsync(Guid productId)
        {
            var product = FindByCondition(x => x.Id == productId).FirstOrDefault();
            Delete(product!);
            
        }

        public  async Task<Product?> GetProductByIdAsync(Guid productId)
        {
            var product = await FindByCondition(x => x.Id == productId).FirstOrDefaultAsync();
            return product;
        }

        public async Task<IReadOnlyCollection<Product>> GetProductsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public  void PostProductAsync(Product product)
        {
            Create(product);
        }

        public  void UpdateProductAsync(Product product)
        {
           Update(product);
        }

    }
}
