using Drivers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetById(int id);
        bool AddUser(User user);
        bool DeleteUser(int id);
        bool UpdateUser(int id, User user);
    }
}
