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
    public class CarService : ICarService
    {

        private readonly IRepositoryManager _repositoryManager;

        public CarService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public List<Car> GetAllCars()
        {
            return _repositoryManager.Cars.GetAll().ToList();
        }

        public Car GetById(int id)
        {
            return _repositoryManager.Cars.GetById(id);

        }
        public Car AddCar(Car car)
        {
            var addedCar = _repositoryManager.Cars.Add(car);
            _repositoryManager.Save();
            return addedCar;
        }
        public void DeleteCar(Car car)
        {
            _repositoryManager.Cars.Delete(car);
            _repositoryManager.Save();

        }
        public Car UpdateCar(int id,Car car)
        {
            var updatedCar= _repositoryManager.Cars.Update(id,car);
            _repositoryManager.Save();
            return updatedCar;
        }
    }
}
