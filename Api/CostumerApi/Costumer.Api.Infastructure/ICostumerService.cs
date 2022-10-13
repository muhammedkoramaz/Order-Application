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
       // public Models.Costumer GetCostumerById(int id);
        List<Models.Costumer> GetCustomers();
        Models.Costumer CreateCustomer(Models.Costumer customer);
        Models.Costumer GetCustomer(string id);
        void DeleteCustomer(string id);
        void UpdateCustomer(string id, Models.Costumer customer);
    }
}
