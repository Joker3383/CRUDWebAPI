using CEUDWebAPI.Domain.Entities;
using CEUDWebAPI.Domain.Repositories;

namespace CRUDWebAPI.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }
    }
}
