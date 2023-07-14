using CEUDWebAPI.Domain.Entities;
using CEUDWebAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CRUDWebAPI.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public void ChangeCustomer(Customer customer)
        {
            Update(customer);
        }

        public  async Task<Customer?> CheckCustomer(Guid Id)
        {
            var customer = await FindByCondition(x => x.Id == Id).FirstOrDefaultAsync();
            return customer;
        }

        public async Task<IReadOnlyCollection<Customer>> CheckCustomers()
        {
            return await FindAll().ToListAsync();
        }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public void DeleteCustomer(Guid Id)
        {
            var customer = FindByCondition(x => x.Id == Id).FirstOrDefault();
            Delete(customer!);
        }
    }
}
