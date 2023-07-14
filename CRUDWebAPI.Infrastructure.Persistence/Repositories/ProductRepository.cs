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

        public void DeleteProduct(Product product)
        {
            Delete(product);        
        }

        public async Task<Product?> GetProductByIdAsync(Guid productId)
        {
            return await FindByCondition(x => x.Id == productId)
                .FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<Product>> GetAllProductsAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public void PostProduct(Product product)
        {
            Create(product);
        }

        public void UpdateProduct(Product product)
        {
           Update(product);
        }
    }
}
