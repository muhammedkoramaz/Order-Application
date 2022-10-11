using Costumer.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costumer.Api.Infastructure
{
    public interface ICostumerService
    {
        public Models.Costumer GetCostumerById(int id);
    }
}
