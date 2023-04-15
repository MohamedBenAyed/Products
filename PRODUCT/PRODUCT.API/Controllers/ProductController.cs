using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRODUCT.Services.Interfaces;

namespace PRODUCT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProduct()
        {
            var products = _productService.GetProducts();
            return new OkObjectResult(products);
        }
    }
}
