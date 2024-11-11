using DriversServicesAPI.DTO;
using System.Text.Json;

namespace DriversServicesAPI.Services
{
    public class OrderService
    {
        DataOrders _allOrders = DataManager.Data.Orders;
        private static int Id = 0;
        public List<OrderDTO> GetAllOrders()
        {
            if (_allOrders == null)
            {
                return new List<OrderDTO>();
            }

            return _allOrders.dataOrders;
        }

        public OrderDTO GetById(int id)
        {
            if (_allOrders?.dataOrders == null)
            {
                return null;
            }
            return _allOrders.dataOrders.Find(c => c.Id == id);
        }

        public bool AddOrder(OrderDTO order)
        {
            if (_allOrders == null)
            { return false; }
            order.Id= Id++;
            _allOrders.dataOrders.Add(order);
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "dataOrders.json");
            var data = JsonSerializer.Serialize(_allOrders);
            File.WriteAllText(path, data);
            return true;
        }

        public bool DeleteOrder(int id)
        {
            if (_allOrders?.dataOrders == null)
            {
                return false;
            }
            OrderDTO orderToRemove = _allOrders.dataOrders.Find(c => c.Id == id);
            if (orderToRemove != null)
            {
                _allOrders.dataOrders.Remove(orderToRemove);
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "DataOrders.json");
                var data = JsonSerializer.Serialize(_allOrders);
                File.WriteAllText(path, data);
                return true;
            }
            return false;
        }
        public bool UpdateOrder(OrderDTO order)
        {
            if (_allOrders == null)
            { return false; }

            OrderDTO orderToUpdate = _allOrders.dataOrders.Find(c => c.Id == order.Id);
            if (orderToUpdate != null)
            {
                orderToUpdate.Date = order.Date;
                orderToUpdate.UserId = order.UserId;
                orderToUpdate.DriverId = order.DriverId;
                orderToUpdate.TravelId = order.TravelId;
                orderToUpdate.Price = order.Price;
                orderToUpdate.Payment = order.Payment;
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "dataOrders.json");
                var data = JsonSerializer.Serialize(_allOrders);
                File.WriteAllText(path, data);
                return true;
            }

            return false;
        }


    }
}
