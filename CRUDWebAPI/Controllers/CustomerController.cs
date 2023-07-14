using Azure.Core;
using CEUDWebAPI.Domain.Entities;
using CEUDWebAPI.Domain.Repositories;
using CRUDWebAPI.Contracts.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public CustomerController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _repositoryManager.CustomerRepository.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer =  await _repositoryManager.CustomerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return StatusCode(404);
            }
            return Ok(customer);
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

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateCustomerReqest request)
        {
            var customer = await _repositoryManager.CustomerRepository.GetCustomerByIdAsync(request.Id);
            if (customer == null) 
            {
                return NotFound();
            }

            customer.Name = request.Name;
            _repositoryManager.CustomerRepository.UpdateCustomer(customer);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var customer = await _repositoryManager.CustomerRepository.GetCustomerByIdAsync(Id);
            if (customer == null)
            {
                return NotFound();
            }
            _repositoryManager.CustomerRepository.DeleteCustomer(customer);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
