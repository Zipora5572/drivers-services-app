using Drivers.Core.Entities;
using Drivers.Core.Repositories;
using Drivers.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public List<User> GetAllUsers()
        {
            return _UserRepository.GetAllUsers();
        }

        public User GetById(int id)
        {
            return _UserRepository.GetById(id);

        }

        public bool AddUser(User user)
        {

            return _UserRepository.AddUser(user);
        }

        public bool DeleteUser(int id)
        {
            return _UserRepository.DeleteUser(id);
        }
        public bool UpdateUser(int id, User user)
        {

            return _UserRepository.UpdateUser(id, user);
        }


    }
}
