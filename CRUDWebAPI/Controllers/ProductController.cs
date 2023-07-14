using CEUDWebAPI.Domain.Repositories;
using CRUDWebAPI.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using CEUDWebAPI.Domain.Entities;

namespace CRUDWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public ProductController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _repositoryManager.ProductRepository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _repositoryManager.ProductRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return StatusCode(404);
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductCreateReqest reqest)
        {
            var productId = Guid.NewGuid();
            var product = new Product 
            {
                Id = productId,
                Name = reqest.Name,
                Category = reqest.Category,
                Count = reqest.Count
            };

            _repositoryManager.ProductRepository.PostProduct(product);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductReqest request)
        {
            var product = await _repositoryManager.ProductRepository.GetProductByIdAsync(request.Id);
            if (product == null) 
            {
                return NotFound();
            }

            product.Name = request.Name;
            product.Category = request.Category;
            product.Count = request.Count;
            _repositoryManager.ProductRepository.UpdateProduct(product);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var product = await _repositoryManager.ProductRepository.GetProductByIdAsync(Id);
            if (product == null)
            {
                return NotFound();
            }
            _repositoryManager.ProductRepository.DeleteProduct(product);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
