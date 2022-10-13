using Costumer.Api.Infastructure;
using Costumer.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CostumerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly ICostumerService costumerService;

        //DI olarak verilen interfaceler buraya parametre olarak gönderiliyor.
        public CostumerController(ICostumerService CostumerService)
        {
            costumerService = CostumerService;
        }
        [HttpGet]
        public ActionResult<List<Costumer.Api.Models.Costumer>> GetCustomers() =>
            costumerService.GetCustomers();

        [HttpGet("{Id:length(24)}", Name ="GetCostumer")]
        public Costumer.Api.Models.Costumer GetCustomer(string Id)
        {
            return costumerService.GetCustomer(Id);
        }

        [HttpPost]
        public ActionResult<Costumer.Api.Models.Costumer> CreateCustomer(Costumer.Api.Models.Costumer costumer)
        {
            costumerService.CreateCustomer(costumer);

            return CreatedAtRoute("GetCostumer", new { id = costumer.Id.ToString() }, costumer);
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var customer = costumerService.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            costumerService.DeleteCustomer(id);

            return NoContent();
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult UpdateCustomer(string id, Costumer.Api.Models.Costumer customerIn)
        {
            var customer = costumerService.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            costumerService.UpdateCustomer(id, customerIn);

            return NoContent();
        }




    }
}
