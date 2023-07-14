using CEUDWebAPI.Domain.Entities;

namespace CEUDWebAPI.Domain.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Product?> GetProductByIdAsync(Guid productId);
        Task<IReadOnlyCollection<Product>> GetProductsAsync();
        void PostProductAsync(Product product);
        void UpdateProductAsync(Product product);
        void DeleteProductAsync(Guid productId);

    }
}
