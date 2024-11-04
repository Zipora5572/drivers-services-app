namespace DriversServicesAPI.DTO
{
    public class TravelDTO
    {

        public int Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public string RateType { get; set; }
        public string TravelType { get; set; }
    }
    public class DataTravels
    {
        public List<TravelDTO> dataTravels { get; set; }
    }
}
