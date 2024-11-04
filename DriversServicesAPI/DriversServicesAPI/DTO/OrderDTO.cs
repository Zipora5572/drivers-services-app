namespace DriversServicesAPI.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int DriverId { get; set; }
        public int TravelId { get; set; }
        public decimal Price { get; set; }
        public string PaymentType { get; set; }
        public int CarId { get; set; }
    }
    public class DataOrders
    {
        public List<OrderDTO> dataOrders { get; set; }
    }
}
