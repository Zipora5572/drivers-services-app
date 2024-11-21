using Drivers.Core.Entities;
using Drivers.Core.Repositories;
using Drivers.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Service
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _OrderRepository;

        public OrderService(IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return _OrderRepository.GetAllOrders();
        }

        public Order GetById(int id)
        {
            return _OrderRepository.GetById(id);

        }

        public bool AddOrder(Order order)
        {

            return _OrderRepository.AddOrder(order);
        }

        public bool DeleteOrder(int id)
        {
            return _OrderRepository.DeleteOrder(id);
        }
        public bool UpdateOrder(int id, Order order)
        {

            return _OrderRepository.UpdateOrder(id, order);
        }


    }
}
