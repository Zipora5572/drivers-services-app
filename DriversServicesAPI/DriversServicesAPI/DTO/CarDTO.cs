using System.Text.Json.Serialization;

namespace DriversServicesAPI.DTO
{
    public class CarDTO
    {

        public enum ConditionCar
        {
            RENTED,
            AVAILABLE,
            BROKEN_DOWN,
            UNDER_REPAIR
        }

        [JsonIgnore]
        public int Id { get; set; }
        public string Model { get; set; }
        public DateOnly YearOfProduction { get; set; }
        public int NumPlaces { get; set; }
        public string PlateNumber { get; set; }
        public string Manufacturer { get; set; }
        public ConditionCar Condition { get; set; }
        public bool Status { get; set; }
        public string DriverId { get; set; }


    }
    public class DataCars
    {
        public List<CarDTO> dataCars { get; set; }
    }
}
