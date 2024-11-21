using Drivers.Core.Repositories;
using Drivers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Data.Repositories
{
    public class CarRepository:ICarRepository
    {

        static int id = 3;
        private readonly IDataContext _context;

        public CarRepository(IDataContext dataContext)
        {
            _context = dataContext;
        }

        public List<Car> GetAllCars()
        {
            var data = _context.Cars;
            if (data == null)
                return null;
            return data;
        }

        public Car GetById(int id)
        {

            var data = _context.Cars;

            if (data == null)
            {
                return null;
            }
            return data.Find(c => c.Id == id);
        }

        public bool AddCar(Car car)
        {

            var data = _context.Cars;
            if (data == null || car.NumPlaces < 0)
            { return false; }
            car.Id = id++;
            data.Add(car);
            _context.SaveData(data);
            return true;
        }

        public bool DeleteCar(int id)
        {

            var data = _context.Cars;

            if (data == null)
            {
                return false;
            }
            Car carToRemove = data.Find(c => c.Id == id);
            if (carToRemove != null)
            {
                data.Remove(carToRemove);
                _context.SaveData(data);
                return true;
            }
            return false;
        }
        public bool UpdateCar(int id, Car car)
        {

            var data = _context.Cars;

            if (data == null)
            { return false; }

            Car carToUpdate = data.Find(c => c.Id == id);
            if (carToUpdate != null)
            {
                carToUpdate.Model = car.Model;
                carToUpdate.Condition = car.Condition;
                carToUpdate.NumPlaces = car.NumPlaces;
                carToUpdate.YearOfProduction = car.YearOfProduction;
                carToUpdate.Status = car.Status;
                carToUpdate.PlateNumber = car.PlateNumber;
                carToUpdate.Manufacturer = car.Manufacturer;
                carToUpdate.DriverId = car.DriverId;
                _context.SaveData(data);
                return true;
            }

            return false;
        }


    }
}
