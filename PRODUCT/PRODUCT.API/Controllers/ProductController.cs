using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRODUCT.Services.Interfaces;
using System.Text.Json;

namespace PRODUCT.API.Controllers
{
    /// <summary>
    /// Product controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        
        private readonly ILogger<ProductController> _logger;
        private IProductService _productService;
        private IQRCodeService _qrCodeService;

        public ProductController(ILogger<ProductController> logger, IProductService productService,
            IQRCodeService qrCodeService)
        {
            _logger = logger;
            _productService = productService;
            _qrCodeService = qrCodeService;
        }

        #region Methodes

        /// <summary>
        /// Get All products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProduct()
        {
            var products = _productService.GetProducts();
            return new OkObjectResult(products);
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProductById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);

            if(product == null)
            {
                return NotFound();
            }
            if(product.Price < 30)
            {
                return ValidationProblem("Product Price can't be less than 10.");
            }
            else
            {
                return new OkObjectResult(product);
            }
            
        }

        /// <summary>
        /// Get QRCode of Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetQRCodeProductById/{id}")]
        public IActionResult GetQRCodeProductById(int id)
        {
            var product = _productService.GetProductById(id);
            var jsonString = JsonSerializer.Serialize(product);
            return new OkObjectResult(_qrCodeService.CreateQRCode(jsonString));
        }
        #endregion

    }
}
