using Microsoft.AspNetCore.Mvc;
using CharismaShop.Services;
using CharismaShop.Model;
using CharismaShop.Dto;

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

    [HttpGet]
    public IEnumerable<Order> Get()
    {
        return _orderService.GetAll();
    }

    [HttpPost]
    [Route("create")]
    public async Task CreateOrder([FromBody] OrderDto dto)
    {
        await _orderService.CreateOrderAsync(dto);
    }
}
