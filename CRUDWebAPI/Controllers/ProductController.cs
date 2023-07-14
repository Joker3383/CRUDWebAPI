using CEUDWebAPI.Domain.Repositories;
using CRUDWebAPI.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using CEUDWebAPI.Domain.Entities;
using Azure.Core;

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
            var products = await _repositoryManager.ProductRepository.GetProductsAsync();
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
            var guid = Guid.NewGuid();
            var product = new Product {Id = guid , Name = reqest.Name,Category = reqest.Category, Count = reqest.Count};
            _repositoryManager.ProductRepository.PostProductAsync(product);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return StatusCode(201);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductReqest reqest)
        {
            var product_reqest = _repositoryManager.ProductRepository.GetProductByIdAsync(reqest.Id);
            if (product_reqest == null) 
            {
                return NotFound();
            }
            var product = new Product {Id = reqest.Id, Name =  reqest.Name, Category = reqest.Category,Count = reqest.Count};
            _repositoryManager.ProductRepository.UpdateProductAsync(product);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok(product);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var product_reqest = await _repositoryManager.ProductRepository.GetProductByIdAsync(Id);
            if (product_reqest == null)
            {
                return NotFound();
            }
            var product = new Product { Id = product_reqest.Id, Name = product_reqest.Name, Category = product_reqest.Category, Count = product_reqest.Count };
            _repositoryManager.ProductRepository.DeleteProductAsync(product.Id);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
