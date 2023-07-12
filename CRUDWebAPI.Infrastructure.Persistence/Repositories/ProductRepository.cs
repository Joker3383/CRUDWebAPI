using CEUDWebAPI.Domain.Entities;
using CEUDWebAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace CRUDWebAPI.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<Product?> GetProductByIdAsync(Guid productId)
        {
            return await FindByCondition(x => x.Id == productId).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<Product>> GetProductsAsync()
        {
            return await FindAll().ToListAsync();
        }
    }
}
