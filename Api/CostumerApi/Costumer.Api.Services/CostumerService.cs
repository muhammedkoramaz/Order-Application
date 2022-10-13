using Costumer.Api.Infastructure;
using Costumer.Api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Net;

namespace Costumer.Api.Services
{
    public class CostumerService : ICostumerService
    {
        private readonly IMongoCollection<Models.Costumer> _customers;

        public CostumerService(ICustomerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _customers = database.GetCollection<Models.Costumer>(settings.CustomersCollectionName);
        }

        public Models.Costumer CreateCustomer(Models.Costumer customer)
        {
            customer.CreatedAt = DateTime.Now;
            _customers.InsertOne(customer);
            return customer;
        }

        public void DeleteCustomer(string id)
        {
            _customers.DeleteOne(customer => customer.Id == id);
        }

        public Models.Costumer GetCustomer(string id)
        {
            return _customers
                .Find<Models.Costumer>(customer => customer.Id == id)
                .FirstOrDefault();

        }

        public List<Models.Costumer> GetCustomers()
        {
            return _customers
                .Find(customer => true)
                .ToList();
        }

        public void UpdateCustomer(string id, Models.Costumer customerIn)
        {
            GetCustomer(customerIn.Id);
            customerIn.UpdatedAt = DateTime.Now;
            _customers.ReplaceOne(customer => customer.Id == id, customerIn);
        }

    }
}
