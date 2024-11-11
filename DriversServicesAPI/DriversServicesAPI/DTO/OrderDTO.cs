using System.Text.Json.Serialization;

namespace DriversServicesAPI.DTO
{
    public class OrderDTO
    {

        public enum PaymentType
        {
            CREDIT_CARD,
            CHECK,
            CASH
        }

        [JsonIgnore]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int DriverId { get; set; }
        public int TravelId { get; set; }
        public double Price { get; set; }
        public PaymentType Payment { get; set; }
        public int CarId { get; set; }
    }
    public class DataOrders
    {
        public List<OrderDTO> dataOrders { get; set; }
    }
}
