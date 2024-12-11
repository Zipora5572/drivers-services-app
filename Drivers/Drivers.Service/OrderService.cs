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
        private readonly IRepositoryManager _repositoryManager;

        public OrderService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public List<Order> GetAllOrders()
        {
            return _repositoryManager.Orders.GetAll().ToList();
        }

        public Order GetById(int id)
        {
            return _repositoryManager.Orders.GetById(id);

        }

        public Order AddOrder(Order order)
        {
           var addedOrder= _repositoryManager.Orders.Add(order);
            _repositoryManager.Save();
            return addedOrder;
        }

        public void DeleteOrder(Order order)
        {
             _repositoryManager.Orders.Delete(order);
            _repositoryManager.Save();
        }
        public Order UpdateOrder(int id,Order order)
        {
            var updatedOrder= _repositoryManager.Orders.Update(id,order);
            _repositoryManager.Save();
            return updatedOrder;
        }


    }
}
