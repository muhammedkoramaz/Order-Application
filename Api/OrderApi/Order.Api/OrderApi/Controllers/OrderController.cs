 using Microsoft.AspNetCore.Mvc;

namespace OrderApi.Controllers
{
    public class OrderController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
