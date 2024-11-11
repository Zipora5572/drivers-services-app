using System.Text.Json.Serialization;

namespace DriversServicesAPI.DTO
{
    public class UserDTO
    {
        [JsonIgnore]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
        
    }
    public class DataUsers
    {
        public List<UserDTO> dataUsers { get; set; }
    }
}

