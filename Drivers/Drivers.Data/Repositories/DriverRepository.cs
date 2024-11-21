using Drivers.Core.Entities;
using Drivers.Core.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Data.Repositories
{
    public class DriverRepository:IDriverRepository
    {
        readonly IDataContext _dataContext;
         static int id = 3;

        public DriverRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Driver> GetAllDrivers()
        {
            var data = _dataContext.Drivers;

            if (data == null)
            {
                return new List<Driver>();
            }

            return data;
        }

        public Driver GetById(int id)
        {
            var data = _dataContext.Drivers;

            if (data == null)
            {
                return null;
            }
            return data.Find(c => c.Id == id);
        }

        public bool AddDriver(Driver driver)
        {

            var data = _dataContext.Drivers;
            driver.Id = id++;
            if (data == null)
            { return false; }
            data.Add(driver);
            _dataContext.SaveData(data);
            return true;
        }

        public bool DeleteDriver(int id)
        {
            var data = _dataContext.Drivers;

            if (data == null)
            {
                return false;
            }
            Driver driverToRemove = data.Find(c => c.Id == id);
            if (driverToRemove != null)
            {
                data.Remove(driverToRemove);
                _dataContext.SaveData(data);
                return true;
            }
            return false;
        }
        public bool UpdateDriver(int id, Driver driver)
        {

            var data = _dataContext.Drivers;

            if (data == null)
            { return false; }

            Driver driverToUpdate = data.Find(c => c.Id == id);
            if (driverToUpdate != null)
            {

                driverToUpdate.FirstName = driver.FirstName;
                driverToUpdate.LastName = driver.LastName;
                driverToUpdate.City = driver.City;
                driverToUpdate.Address = driver.Address;
                driverToUpdate.Gender = driver.Gender;
                driverToUpdate.DateOfBirth = driver.DateOfBirth;
                driverToUpdate.LicenseTax = driver.LicenseTax;
                driverToUpdate.PhoneNumber = driver.PhoneNumber;
                driverToUpdate.Status = driver.Status;
                driverToUpdate.Email = driverToUpdate.Email;

                _dataContext.SaveData(data);
                return true;
            }

            return false;
        }

    }
}
