using DriversServicesAPI.DTO;
using System.Text.Json;

namespace DriversServicesAPI.Services
{
    public class DriverService
    {

        DataDrivers _allDrivers;

        public DriverService()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "DataDrivers.json");
            string jsonString = File.ReadAllText(path);
            _allDrivers = JsonSerializer.Deserialize<DataDrivers>(jsonString);
        }
        public List<DriverDTO> GetAllDrivers()
        {
            if (_allDrivers == null)
            {
                return new List<DriverDTO>();
            }

            return _allDrivers.dataDrivers;
        }

        public DriverDTO GetById(int id)
        {
            if (_allDrivers?.dataDrivers == null)
            {
                return null;
            }
            return _allDrivers.dataDrivers.Find(c => c.Id == id);
        }

        public bool AddDriver(DriverDTO driver)
        {
            if (_allDrivers == null)
            { return false; }
            _allDrivers.dataDrivers.Add(driver);
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "dataDrivers.json");
            var data = JsonSerializer.Serialize(_allDrivers);
            File.WriteAllText(path, data);
            return true;
        }

        public bool DeleteDriver(int id)
        {
            if (_allDrivers?.dataDrivers == null)
            {
                return false;
            }
            DriverDTO driverToRemove = _allDrivers.dataDrivers.Find(c => c.Id == id);
            if (driverToRemove != null)
            {
                _allDrivers.dataDrivers.Remove(driverToRemove);
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "DataDrivers.json");
                var data = JsonSerializer.Serialize(_allDrivers);
                File.WriteAllText(path, data);
                return true;
            }
            return false;
        }
        public bool UpdateDriver(DriverDTO driver)
        {
            if (_allDrivers == null)
            { return false; }

            DriverDTO driverToUpdate = _allDrivers.dataDrivers.Find(c => c.Id == driver.Id);
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
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "dataDrivers.json");
                var data = JsonSerializer.Serialize(_allDrivers);
                File.WriteAllText(path, data);
                return true;
            }

            return false;
        }


    }
}

