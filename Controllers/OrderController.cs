using Microsoft.AspNetCore.Mvc;
using CharismaShop.Services;
using CharismaShop.Model;

namespace CharismaShop.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _orderService;

    public OrderController(ILogger<OrderController> logger, IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }

    [HttpGet(Name = "get-orders")]
    public IEnumerable<Order> Get()
    {
        return _orderService.GetAll();
    }
}
