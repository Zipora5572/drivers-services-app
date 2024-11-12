using DriversServicesAPI.DTO;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace DriversServicesAPI.Services
{
    public class CarService
    {
        private static int Id = 0;

        readonly IDataContext _dataContext;

        public CarService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<CarDTO> GetAllCars()
        {
            var data = _dataContext.LoadData<CarDTO>();
            if (data == null)
                return null;
            return data;
        }

        public CarDTO GetById(int id)
        {

            var data = _dataContext.LoadData<CarDTO>();

            if (data == null)
            {
                return null;
            }
            return data.Find(c => c.Id == id);
        }

        public bool AddCar(CarDTO car)
        {
            var data = _dataContext.LoadData<CarDTO>();
            if (data == null || car.NumPlaces < 0)
            { return false; }
            car.Id = Id++;
            data.Add(car);
            _dataContext.SaveData(data);
            return true;
        }

        public bool DeleteCar(int id)
        {

            var data = _dataContext.LoadData<CarDTO>();

            if (data == null)
            {
                return false;
            }
            CarDTO carToRemove = data.Find(c => c.Id == id);
            if (carToRemove != null)
            {
                data.Remove(carToRemove);
                _dataContext.SaveData(data);
                return true;
            }
            return false;
        }
        public bool UpdateCar(CarDTO car)
        {

            var data = _dataContext.LoadData<CarDTO>();

            if (data == null)
            { return false; }

            CarDTO carToUpdate =data.Find(c => c.Id == car.Id);
            if (carToUpdate != null)
            {
                carToUpdate.NumPlaces = car.NumPlaces;
                carToUpdate.YearOfProduction = car.YearOfProduction;
                carToUpdate.Status = car.Status;
                carToUpdate.PlateNumber = car.PlateNumber;
                carToUpdate.Manufacturer = car.Manufacturer;
                carToUpdate.DriverId = car.DriverId;
                _dataContext.SaveData(data);
                return true;
            }

            return false;
        }


    }
}
