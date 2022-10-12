using Costumer.Api.Infastructure;
using Costumer.Api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        //public Models.Costumer GetCostumerById(string id)
        //{
        //    //BURADA VERİTABANINDAN ALINACAK VERİ VE SERVİS O VERİYİ DÖNDERECEK.
        //    Address address = new Address() { AddressLine = "asd", City = "Kayseri", CityCode = 38, Country = "Turkey" };   //geçici çözüm
            
        //    return new Models.Costumer()
        //    {
        //        Id = id,
        //        Email = "muhammed@gmail.com",
        //        Name = "Muhammed",
        //        Address = address,
                
        //        //Address = {AddressLine = "asd", City = "Kayseri", CityCode = 38, Country = "Turkey"}

        //    };
        //}

        //public Models.Costumer GetCostumerById(int id)
        //{
        //    throw new NotImplementedException();
        //}

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

        public Models.Costumer UpdateCustomer(Models.Costumer customer)
        {
            throw new NotImplementedException();
        }
    }
}
