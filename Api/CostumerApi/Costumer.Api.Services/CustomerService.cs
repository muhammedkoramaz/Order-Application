using Costumer.Api.Infastructure;
using Costumer.Api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Net;

namespace Costumer.Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Models.Customer> _customers;

        public CustomerService(ICustomerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _customers = database.GetCollection<Models.Customer>(settings.CustomersCollectionName);
        }

        public Models.Customer CreateCustomer(Models.Customer customer)
        {
            customer.CreatedAt = DateTime.Now;
            _customers.InsertOne(customer);
            return customer;
        }

        public void DeleteCustomer(string id)
        {
            _customers.DeleteOne(customer => customer.Id == id);
        }

        public Models.Customer GetCustomer(string id)
        {
            return _customers
                .Find<Models.Customer>(customer => customer.Id == id)
                .FirstOrDefault();

        }

        public List<Models.Customer> GetCustomers()
        {
            return _customers
                .Find(customer => true)
                .ToList();
        }

        public void UpdateCustomer(string id, Models.Customer customerIn)
        {
            GetCustomer(customerIn.Id);
            customerIn.UpdatedAt = DateTime.Now;
            _customers.ReplaceOne(customer => customer.Id == id, customerIn);
        }

    }
}
