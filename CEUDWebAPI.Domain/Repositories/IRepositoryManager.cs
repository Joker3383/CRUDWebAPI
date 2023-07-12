namespace CEUDWebAPI.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
