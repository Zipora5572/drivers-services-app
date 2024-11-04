namespace DriversServicesAPI.DTO
{
    public class CarDTO
    {
       
        public int Id { get; set; }
        public string Model { get; set; }
        public string YearOfProduction { get; set; }

        public int NumPlaces { get; set; }
        public string PlateNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Condition { get; set; }
        public string Status { get; set; }
       
        public string DriverId { get; set; }
    }
    public class DataCars
    {
        public List<CarDTO> dataCars { get; set; }
    }
}
