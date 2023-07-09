using CEUDWebAPI.Domain.Entities;
using CEUDWebAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRUDWebAPI.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<Product?> GetProductByIdAsync(Guid productId)
        {
            return await FindByCondition(x => x.Id == productId).FirstOrDefaultAsync();
        }
    }
}
