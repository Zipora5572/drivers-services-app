using Drivers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Services
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetById(int id);
        bool AddOrder(Order order);
        bool DeleteOrder(int id);
        bool UpdateOrder(int id, Order order);
    }
}
