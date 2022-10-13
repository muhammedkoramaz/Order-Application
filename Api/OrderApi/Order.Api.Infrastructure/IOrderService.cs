using System;
using System.Collections.Generic;

namespace Order.Api.Infrastructure
{
    public interface IOrderService
    {
        List<Models.Order> GetOrders();
        Models.Order GetOrder(string id);
        void DeleteOrder(string id);
        void UpdateOrder(string id, Models.Order order);
        Models.Order CreateOrder(Models.Order order);
    }
}
