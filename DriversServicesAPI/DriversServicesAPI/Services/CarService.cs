using DriversServicesAPI.DTO;
using System.Text.Json;

namespace DriversServicesAPI.Services
{
    public class CarService
    {

        DataCars _allCars;

        public CarService()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "DataCars.json");
            string jsonString = File.ReadAllText(path);
            _allCars = JsonSerializer.Deserialize<DataCars>(jsonString);
        }
        public List<CarDTO> GetAllCars()
        {
            if (_allCars == null)
            {
                return new List<CarDTO>();
            }

            return _allCars.dataCars;
        }

        public CarDTO GetById(int id)
        {
            if (_allCars?.dataCars == null)
            {
                return null;
            }
            return _allCars.dataCars.Find(c => c.Id == id);
        }

        public bool AddCar(CarDTO car)
        {
            if (_allCars == null)
            { return false; }
            _allCars.dataCars.Add(car);
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "DataCars.json");
            var data = JsonSerializer.Serialize(_allCars);
            File.WriteAllText(path, data);
            return true;
        }

        public bool DeleteCar(int id)
        {
            if (_allCars?.dataCars == null)
            {
                return false;
            }
            CarDTO carToRemove = _allCars.dataCars.Find(c => c.Id == id);
            if (carToRemove != null)
            {
                _allCars.dataCars.Remove(carToRemove);
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "DataCars.json");
                var data = JsonSerializer.Serialize(_allCars);
                File.WriteAllText(path, data);
                return true;
            }
            return false;
        }
        public bool UpdateCar(CarDTO car)
        {
            if (_allCars == null)
            { return false; }

            CarDTO carToUpdate = _allCars.dataCars.Find(c => c.Id == car.Id);
            if (carToUpdate != null)
            {
                carToUpdate.NumPlaces = car.NumPlaces;
                carToUpdate.YearOfProduction = car.YearOfProduction;
                carToUpdate.Status = car.Status;
                carToUpdate.PlateNumber = car.PlateNumber;
                carToUpdate.Manufacturer = car.Manufacturer;
                carToUpdate.DriverId = car.DriverId;
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "DataCars.json");
                var data = JsonSerializer.Serialize(_allCars);
                File.WriteAllText(path, data);
                return true;
            }
         
            return false;
        }


    }
}
