using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Api.Infrastructure
{
    public interface IOrderService
    {
        public Models.Order GetOrderById(int id);
    }
}
