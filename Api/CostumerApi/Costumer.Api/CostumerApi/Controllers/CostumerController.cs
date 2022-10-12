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
        [HttpGet("{Id}")]
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
    }
}
