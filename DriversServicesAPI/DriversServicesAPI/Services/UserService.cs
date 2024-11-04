using DriversServicesAPI.DTO;
using System.Text.Json;

namespace DriversServicesAPI.Services
{
    public class UserService
    {

        DataUsers _allUsers;

        public UserService()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "DataUsers.json");
            string jsonString = File.ReadAllText(path);
            _allUsers = JsonSerializer.Deserialize<DataUsers>(jsonString);
        }
        public List<UserDTO> GetAllUsers()
        {
            if (_allUsers == null)
            {
                return new List<UserDTO>();
            }

            return _allUsers.dataUsers;
        }

        public UserDTO GetById(int id)
        {
            if (_allUsers?.dataUsers == null)
            {
                return null;
            }
            return _allUsers.dataUsers.Find(c => c.Id == id);
        }

        public bool AddUser(UserDTO car)
        {
            if (_allUsers == null)
            { return false; }
            _allUsers.dataUsers.Add(car);
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "dataUsers.json");
            var data = JsonSerializer.Serialize(_allUsers);
            File.WriteAllText(path, data);
            return true;
        }

        public bool DeleteUser(int id)
        {
            if (_allUsers?.dataUsers == null)
            {
                return false;
            }
            UserDTO carToRemove = _allUsers.dataUsers.Find(c => c.Id == id);
            if (carToRemove != null)
            {
                _allUsers.dataUsers.Remove(carToRemove);

                string path = Path.Combine(AppContext.BaseDirectory, "Data", "DataUsers.json");
                var data = JsonSerializer.Serialize(_allUsers);
                File.WriteAllText(path, data);
                return true;
            }
            return false;
        }
        public bool UpdateUser(UserDTO car)
        {
            if (_allUsers == null)
            { return false; }

            UserDTO carToUpdate = _allUsers.dataUsers.Find(c => c.Id == car.Id);
            if (carToUpdate != null)
            {
                carToUpdate.FirstName = car.FirstName;
                carToUpdate.LastName = car.LastName;
                carToUpdate.Address = car.Address;
                carToUpdate.Gender = car.Gender;
                carToUpdate.DateOfBirth = car.DateOfBirth;
                carToUpdate.PhoneNumber = car.PhoneNumber;
                carToUpdate.City = car.City;
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "dataUsers.json");
                var data = JsonSerializer.Serialize(_allUsers);
                File.WriteAllText(path, data);
                return true;
            }

            return false;
        }


    }

}
