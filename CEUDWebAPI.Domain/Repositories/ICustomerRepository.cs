using CEUDWebAPI.Domain.Entities;

namespace CEUDWebAPI.Domain.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        void CreateCustomer(Customer customer);
        void DeleteCustomer(Guid Id);
        void ChangeCustomer(Customer customer);
        Task<IReadOnlyCollection<Customer>> CheckCustomers();
        Task<Customer?> CheckCustomer(Guid Id);
    }
}
