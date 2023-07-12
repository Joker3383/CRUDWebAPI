using CEUDWebAPI.Domain.Entities;
using CEUDWebAPI.Domain.Repositories;
using CRUDWebAPI.Contracts.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public CustomerController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request)
        {
            var customerId = Guid.NewGuid();
            var customer = new Customer { Id = customerId, Name = request.Name };
            _repositoryManager.CustomerRepository.CreateCustomer(customer);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return StatusCode(201);
        }
    }
}
