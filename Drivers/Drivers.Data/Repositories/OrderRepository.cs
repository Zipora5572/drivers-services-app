using Drivers.Core.Entities;
using Drivers.Core.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Data.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private static int Id = 0;
        readonly IDataContext _dataContext;

        public OrderRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Order> GetAllOrders()
        {

            var data = _dataContext.Orders;

            if (data == null)
            {
                return new List<Order>();
            }

            return data;
        }

        public Order GetById(int id)
        {
            var data = _dataContext.Orders;

            if (data == null)
            {
                return null;
            }
            return data.Find(c => c.Id == id);
        }

        public bool AddOrder(Order order)
        {

            var data = _dataContext.Orders;

            if (data == null)
            { return false; }
            order.Id = Id++;
            data.Add(order);
            _dataContext.SaveData(data);
            return true;
        }

        public bool DeleteOrder(int id)
        {
            var data = _dataContext.Orders;


            if (data == null)
            {
                return false;
            }
            Order orderToRemove = data.Find(c => c.Id == id);
            if (orderToRemove != null)
            {
                data.Remove(orderToRemove);
                _dataContext.SaveData(data);
                return true;
            }
            return false;
        }
        public bool UpdateOrder(int id, Order order)
        {
            var data = _dataContext.Orders;

            if (data == null)
            { return false; }

            Order orderToUpdate = data.Find(c => c.Id == id);
            if (orderToUpdate != null)
            {

                orderToUpdate.Date = order.Date;
                orderToUpdate.UserId = order.UserId;
                orderToUpdate.DriverId = order.DriverId;
                orderToUpdate.TravelId = order.TravelId;
                orderToUpdate.Price = order.Price;
                orderToUpdate.Payment = order.Payment;
                orderToUpdate.CarId = order.CarId;
                _dataContext.SaveData(data);
                return true;
            }

            return false;
        }

    }
}
