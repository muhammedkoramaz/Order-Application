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

        //Scooped olarak verilen interface buraya parametre olarak gönderiliyor.
        public CostumerController(ICostumerService CostumerService)
        {
            costumerService = CostumerService;
        }
        [HttpGet("{Id}")]
        public Costumer.Api.Models.Costumer Get(int Id)
        {
            return costumerService.GetCostumerById(Id);
        }
    }
}
