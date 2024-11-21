using Drivers.Core.Entities;
using Drivers.Core.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        readonly IDataContext _dataContext;
        public static int id = 3;

        public UserRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<User> GetAllUsers()
        {
            var data = _dataContext.Users;
            if (data == null)
            {
                return new List<User>();
            }

            return data;
        }

        public User GetById(int id)
        {
            var data = _dataContext.Users;

            if (data == null)
            {
                return null;
            }
            return data.Find(c => c.Id == id);
        }

        public bool AddUser(User user)
        {
            var data = _dataContext.Users;

            if (data == null)
            { return false; }
            user.Id = id++;
            data.Add(user);

            _dataContext.SaveData(data);
            return true;
        }

        public bool DeleteUser(int id)
        {
            var data = _dataContext.Users;

            if (data == null)
            {
                return false;
            }
            User carToRemove = data.Find(c => c.Id == id);
            if (carToRemove != null)
            {
                data.Remove(carToRemove);
                _dataContext.SaveData(data);
                return true;
            }
            return false;
        }
        public bool UpdateUser(int id, User car)
        {

            var data = _dataContext.Users;

            if (data == null)
            { return false; }

            User userToUpdate = data.Find(c => c.Id == id);
            if (userToUpdate != null)
            {
                userToUpdate.FirstName = car.FirstName;
                userToUpdate.LastName = car.LastName;
                userToUpdate.Address = car.Address;
                userToUpdate.Gender = car.Gender;
                userToUpdate.DateOfBirth = car.DateOfBirth;
                userToUpdate.PhoneNumber = car.PhoneNumber;
                userToUpdate.City = car.City;
                userToUpdate.Status = car.Status;
                userToUpdate.Email = car.Email;
                _dataContext.SaveData(data);
                return true;
            }

            return false;
        }
    }
}
