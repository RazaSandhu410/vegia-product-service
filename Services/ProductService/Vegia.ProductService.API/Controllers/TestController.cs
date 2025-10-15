using Microsoft.AspNetCore.Mvc;
using Vegia.ProductService.Core.Interfaces;

namespace Vegia.ProductService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("test-repositories")]
        public async Task<IActionResult> TestRepositories()
        {
            try
            {
                // Test that repositories are accessible
                var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
                var products = await _unitOfWork.ProductRepository.GetAllAsync();

                return Ok(new {
                    Message = "Repository pattern working correctly!",
                    CategoriesCount = categories.Count(),
                    ProductsCount = products.Count()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
