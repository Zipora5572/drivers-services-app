using Drivers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Services
{
    public interface ICarService
    {

        List<Car> GetAllCars();
        Car GetById(int id);
        Car AddCar(Car car);
        void DeleteCar(Car car);
        Car UpdateCar(int id,Car car);
    }
}
