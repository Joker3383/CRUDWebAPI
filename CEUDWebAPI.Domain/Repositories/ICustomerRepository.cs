using CEUDWebAPI.Domain.Entities;

namespace CEUDWebAPI.Domain.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        void CreateCustomer(Customer customer);
    }
}
