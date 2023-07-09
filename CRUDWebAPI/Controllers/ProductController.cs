using CEUDWebAPI.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public ProductController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
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
    }
}
