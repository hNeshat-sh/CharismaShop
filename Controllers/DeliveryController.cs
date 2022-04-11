using Microsoft.AspNetCore.Mvc;
using CharismaShop.Services;
using CharismaShop.Model;

namespace CharismaShop.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class DeliveryController : ControllerBase
    {
        private readonly ILogger<DeliveryController> _logger;
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(ILogger<DeliveryController> logger, IDeliveryService deliveryService)
        {
            _logger = logger;
            _deliveryService = deliveryService;
        }

        [HttpGet(Name = "get-deliveries")]
        public IEnumerable<Delivery> Get()
        {
            return _deliveryService.GetAll();
        }

    }
}