using CEUDWebAPI.Domain.Entities;
using CEUDWebAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRUDWebAPI.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public void UpdateCustomer(Customer customer)
        {
            Update(customer);
        }

        public async Task<Customer?> GetCustomerByIdAsync(Guid Id)
        {
            return await FindByCondition(x => x.Id == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<Customer>> GetAllCustomersAsync()
        {
            return await FindAll()
                .ToListAsync();
        }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            Delete(customer);
        }
    }
}
