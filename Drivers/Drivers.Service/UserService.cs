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
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public List<User> GetAllUsers()
        {
            return _repositoryManager.Users.GetAll().ToList();
        }

        public User GetById(int id)
        {
            return _repositoryManager.Users.GetById(id);

        }

        public User AddUser(User user)
        {
            var addedUser= _repositoryManager.Users.Add(user);
            _repositoryManager.Save();
            return addedUser;
        }

        public void DeleteUser(User user)
        {
             _repositoryManager.Users.Delete(user);
            _repositoryManager.Save();
        }
        public User UpdateUser(int id,User user)
        {
            var updatedUser= _repositoryManager.Users.Update(id,user);
            _repositoryManager.Save();
            return updatedUser;
        }


    }
}
