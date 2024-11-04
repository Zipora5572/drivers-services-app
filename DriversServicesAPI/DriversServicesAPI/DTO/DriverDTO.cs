namespace DriversServicesAPI.DTO
{
    public class DriverDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string LicenseTax { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
    }
    public class DataDrivers
    {
        public List<DriverDTO> dataDrivers { get; set; }
    }
}
