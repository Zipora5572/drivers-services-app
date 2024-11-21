using Drivers.Core.Entities;
using Drivers.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drivers.Core.Services;

namespace Drivers.Service
{
    public class CarService:ICarService
    {

        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public List<Car> GetAllCars()
        {
            return _carRepository.GetAllCars();
        }

        public Car GetById(int id)
        {
            return _carRepository.GetById(id);

        }

        public bool AddCar(Car car)
        {

            return _carRepository.AddCar(car);
        }

        public bool DeleteCar(int id)
        {
            return _carRepository.DeleteCar(id);
        }
        public bool UpdateCar(int id, Car car)
        {

            return _carRepository.UpdateCar(id, car);
        }


    }
}
