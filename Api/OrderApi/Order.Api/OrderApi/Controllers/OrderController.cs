using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Api.Infrastructure;
using Order.Api.Models;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService OrderService)
        {
            orderService = OrderService;
        }
        [HttpGet("{id}")]   
        public Order.Api.Models.Order GetOrderById(int id)  
        {
           return orderService.GetOrderById(id);
        }
    }
}
