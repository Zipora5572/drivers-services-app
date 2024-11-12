using DriversServicesAPI.DTO;
using System.Text.Json;

namespace DriversServicesAPI.Services
{
    public class UserService
    {
        readonly IDataContext _dataContext;

        public UserService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<UserDTO> GetAllUsers()
        {
            var data = _dataContext.LoadData<UserDTO>();


            if (data == null)
            {
                return new List<UserDTO>();
            }

            return data;
        }

        public UserDTO GetById(string id)
        {
            var data = _dataContext.LoadData<UserDTO>();

            if (data == null)
            {
                return null;
            }
            return data.Find(c => c.Id == id);
        }

        public bool AddUser(UserDTO car)
        {
            var data = _dataContext.LoadData<UserDTO>();

            if (data == null)
            { return false; }
            data.Add(car);
            _dataContext.SaveData(data);
            return true;
        }

        public bool DeleteUser(string id)
        {
            var data = _dataContext.LoadData<UserDTO>();

            if (data == null)
            {
                return false;
            }
            UserDTO carToRemove = data.Find(c => c.Id == id);
            if (carToRemove != null)
            {
                data.Remove(carToRemove);
                _dataContext.SaveData(data);
                return true;
            }
            return false;
        }
        public bool UpdateUser(UserDTO car)
        {

            var data = _dataContext.LoadData<UserDTO>();

            if (data == null)
            { return false; }

            UserDTO carToUpdate =data.Find(c => c.Id == car.Id);
            if (carToUpdate != null)
            {
                carToUpdate.FirstName = car.FirstName;
                carToUpdate.LastName = car.LastName;
                carToUpdate.Address = car.Address;
                carToUpdate.Gender = car.Gender;
                carToUpdate.DateOfBirth = car.DateOfBirth;
                carToUpdate.PhoneNumber = car.PhoneNumber;
                carToUpdate.City = car.City;
                _dataContext.SaveData(data);
                return true;
            }

            return false;
        }


    }

}
