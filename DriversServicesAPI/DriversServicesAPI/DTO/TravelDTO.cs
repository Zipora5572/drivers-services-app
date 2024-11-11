using System.Text.Json.Serialization;

namespace DriversServicesAPI.DTO
{
    public class TravelDTO
    {
        public enum TravelType
        {
            DELIVERY,
            PASSENGERS
        }

        public enum RateType
        {
            HOURLY,
            METER,
            NIGHT
        }

        [JsonIgnore]
        public int Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public RateType Rate { get; set; }
        public TravelType Travel { get; set; }
    }
    public class DataTravels
    {
        public List<TravelDTO> dataTravels { get; set; }
    }
}
