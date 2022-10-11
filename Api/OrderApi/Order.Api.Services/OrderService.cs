using Costumer.Api.Models;
using Order.Api.Infrastructure;
using Order.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Address = Order.Api.Models.Address;

namespace Order.Api.Services
{
    public class OrderService : IOrderService
    {
        public Models.Order GetOrderById(int id)
        {
            Address address = new Address() { AddressLine = "asd", City = "Kayseri", CityCode = 38, Country = "Turkey" };   //geçici çözüm
            Product product = new Product() { Id = 2,ImageUrl ="asd", Name = "urun" };
            return new Models.Order()
            {
                Id = (new Random()).Next(100),
                Price = (new Random()).Next(1000),
                Quantity = (new Random()).Next(10),
                Product = product,
                Address = address,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now.Date.AddDays(20),   

            };
        }
    }
}
