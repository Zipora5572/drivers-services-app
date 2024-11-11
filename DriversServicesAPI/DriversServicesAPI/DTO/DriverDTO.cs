namespace DriversServicesAPI.DTO
{
    public class DriverDTO:UserDTO
    {

        public string LicenseTax { get; set; }
        
    }
    public class DataDrivers
    {
        public List<DriverDTO> dataDrivers { get; set; }
    }
}
