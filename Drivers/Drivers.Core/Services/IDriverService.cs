using Drivers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Services
{
    public interface IDriverService
    {
        List<Driver> GetAllDrivers();
        Driver GetById(int id);
        Driver AddDriver(Driver driver);
        void DeleteDriver(Driver driver);
        Driver UpdateDriver(int id, Driver driver);
    }
}
