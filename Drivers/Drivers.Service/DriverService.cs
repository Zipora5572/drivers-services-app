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
    public class DriverService:IDriverService
    {
        private readonly IDriverRepository _DriverRepository;

        public DriverService(IDriverRepository DriverRepository)
        {
            _DriverRepository = DriverRepository;
        }

        public List<Driver> GetAllDrivers()
        {
            return _DriverRepository.GetAllDrivers();
        }

        public Driver GetById(int id)
        {
            return _DriverRepository.GetById(id);

        }

        public bool AddDriver(Driver driver)
        {

            return _DriverRepository.AddDriver(driver);
        }

        public bool DeleteDriver(int id)
        {
            return _DriverRepository.DeleteDriver(id);
        }
        public bool UpdateDriver(int id, Driver driver)
        {

            return _DriverRepository.UpdateDriver(id, driver);
        }


    }
}
