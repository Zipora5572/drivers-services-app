using DriversServicesAPI.DTO;
using System.Text.Json;

namespace DriversServicesAPI.Services
{
    public class OrderService
    {
       
        private static int Id = 0;
        readonly IDataContext _dataContext;

        public OrderService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<OrderDTO> GetAllOrders()
        {

            var data = _dataContext.LoadData<OrderDTO>();

            if (data == null)
            {
                return new List<OrderDTO>();
            }

            return data;
        }

        public OrderDTO GetById(int id)
        {
            var data = _dataContext.LoadData<OrderDTO>();

            if (data == null)
            {
                return null;
            }
            return data.Find(c => c.Id == id);
        }

        public bool AddOrder(OrderDTO order)
        {

            var data = _dataContext.LoadData<OrderDTO>();

            if (data == null)
            { return false; }
            order.Id= Id++;
            data.Add(order);
           _dataContext.SaveData(data);
            return true;
        }

        public bool DeleteOrder(int id)
        {
            var data = _dataContext.LoadData<OrderDTO>();


            if (data== null)
            {
                return false;
            }
            OrderDTO orderToRemove = data.Find(c => c.Id == id);
            if (orderToRemove != null)
            {
               data.Remove(orderToRemove);
                _dataContext.SaveData(data) ;   
                return true;
            }
            return false;
        }
        public bool UpdateOrder(OrderDTO order)
        {
            var data = _dataContext.LoadData<OrderDTO>();

            if (data == null)
            { return false; }

            OrderDTO orderToUpdate = data.Find(c => c.Id == order.Id);
            if (orderToUpdate != null)
            {
                orderToUpdate.Date = order.Date;
                orderToUpdate.UserId = order.UserId;
                orderToUpdate.DriverId = order.DriverId;
                orderToUpdate.TravelId = order.TravelId;
                orderToUpdate.Price = order.Price;
                orderToUpdate.Payment = order.Payment;
                _dataContext.SaveData(data);
                return true;
            }

            return false;
        }


    }
}
