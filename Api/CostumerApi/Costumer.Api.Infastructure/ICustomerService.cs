using Costumer.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costumer.Api.Infastructure
{
    public interface ICustomerService
    {
       // public Models.Costumer GetCostumerById(int id);
        List<Models.Customer> GetCustomers();
        Models.Customer CreateCustomer(Models.Customer customer);
        Models.Customer GetCustomer(string id);
        void DeleteCustomer(string id);
        void UpdateCustomer(string id, Models.Customer customer);
    }
}
