using Microsoft.AspNetCore.Mvc;
using CharismaShop.Services;
using CharismaShop.Model;

namespace CharismaShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet(Name = "get-products")]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAll();
        }

    }
}