namespace CEUDWebAPI.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
