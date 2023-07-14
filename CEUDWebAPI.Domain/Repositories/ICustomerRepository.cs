using CEUDWebAPI.Domain.Entities;

namespace CEUDWebAPI.Domain.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        void CreateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        Task<IReadOnlyCollection<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(Guid Id);
    }
}
