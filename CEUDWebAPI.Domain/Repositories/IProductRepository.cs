using CEUDWebAPI.Domain.Entities;

namespace CEUDWebAPI.Domain.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Product?> GetProductByIdAsync(Guid productId);
    }
}
