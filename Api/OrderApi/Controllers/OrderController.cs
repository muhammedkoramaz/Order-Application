using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CostumerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Order1", "Order2" };
        }
    }
}
