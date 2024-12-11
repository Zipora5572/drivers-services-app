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
        Order AddOrder(Order order);
        void DeleteOrder(Order order);
        Order UpdateOrder(int id, Order order);
    }
}
