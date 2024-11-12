using DriversServicesAPI.DTO;
using System.Text.Json;

namespace DriversServicesAPI.Services
{
    public class DriverService
    {

        readonly IDataContext _dataContext;

        public DriverService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<DriverDTO> GetAllDrivers()
        {
            var data = _dataContext.LoadData<DriverDTO>();

            if (data == null)
            {
                return new List<DriverDTO>();
            }

            return data;
        }

        public DriverDTO GetById(string id)
        {
            var data = _dataContext.LoadData<DriverDTO>();

            if (data == null)
            {
                return null;
            }
            return data.Find(c => c.Id == id);
        }

        public bool AddDriver(DriverDTO driver)
        {

            var data = _dataContext.LoadData<DriverDTO>();

            if (data == null)
            { return false; }
            data.Add(driver);
            _dataContext.SaveData(data);
            return true;
        }

        public bool DeleteDriver(string id)
        {
            var data = _dataContext.LoadData<DriverDTO>();

            if (data == null)
            {
                return false;
            }
            DriverDTO driverToRemove = data.Find(c => c.Id == id);
            if (driverToRemove != null)
            {
                data.Remove(driverToRemove);
                _dataContext.SaveData(data);
                return true;
            }
            return false;
        }
        public bool UpdateDriver(DriverDTO driver)
        {

            var data = _dataContext.LoadData<DriverDTO>();

            if (data == null)
            { return false; }

            DriverDTO driverToUpdate = data.Find(c => c.Id == driver.Id);
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
                _dataContext.SaveData(data);
                return true;
            }

            return false;
        }


    }
}

