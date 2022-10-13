using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Api.Infrastructure;
using Order.Api.Models;
using Order.Api.Services;
using System.Collections.Generic;

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
        [HttpGet]
        public ActionResult<List<Order.Api.Models.Order>> GetOrders() =>
            orderService.GetOrders();

        [HttpGet("{Id:length(24)}", Name = "GetOrder")]
        public  Order.Api.Models.Order GetOrder(string Id)
        {
            return orderService.GetOrder(Id);
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteOrder(string id)
        {
            var orderForCheck = orderService.GetOrder(id);
            if (orderForCheck == null)
            {
                return NotFound();
            }
            orderService.DeleteOrder(id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Order.Api.Models.Order> CreateOrder(Order.Api.Models.Order order)
        {
            orderService.CreateOrder(order);
            return CreatedAtRoute("GetOrder", new { id = order.Id.ToString() }, order);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateOrder(string id, Order.Api.Models.Order orderIn)
        {
            var order = orderService.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            orderService.UpdateOrder(id, orderIn);

            return NoContent();
        }
    }
}
