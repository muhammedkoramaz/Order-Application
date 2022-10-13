using Costumer.Api.Models;
using MongoDB.Driver;
using Order.Api.Infrastructure;
using Order.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Models.Order> _orders;

        public OrderService(IOrderDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _orders = database.GetCollection<Models.Order>(settings.OrdersCollectionName);
        }

        public Models.Order CreateOrder(Models.Order order)
        {
            order.CreatedAt = DateTime.Now;
            _orders.InsertOne(order);
            return order;
        }

        public void DeleteOrder(string id)
        {
            _orders.DeleteOne(order => order.Id == id);
        }

        public Models.Order GetOrder(string id)
        {
            return _orders
                .Find<Models.Order>(order => order.Id == id)
                .FirstOrDefault();
        }

        public List<Models.Order> GetOrders()
        {
            return _orders.Find(order => true).ToList();
        }

        public void UpdateOrder(string id ,Models.Order orderIn)
        {
            GetOrder(orderIn.Id);
            orderIn.UpdatedAt = DateTime.Now; 
            _orders.ReplaceOne(order => order.Id == id, orderIn);

        }
    }
}
