using Drivers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Repositories
{
    public interface IDriverRepository
    {
        List<Driver> GetAllDrivers();
        Driver GetById(int id);
        bool AddDriver(Driver driver);
        bool DeleteDriver(int id);
        bool UpdateDriver(int id, Driver driver);
    }
}
