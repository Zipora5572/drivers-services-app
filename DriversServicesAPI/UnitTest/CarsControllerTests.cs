using DriversServicesAPI.Controllers;
using DriversServicesAPI.DTO;
using DriversServicesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using UsersServicesAPI.Controllers;

namespace UnitTest
{
    public class CarsControllerTests
    {

        private readonly CarsController _carsController;
        //var controler = new CoinsController(new CoinsSerice(new TestContext()));

        public CarsControllerTests()
        {
            _carsController = new CarsController(new CarService(new FakeContext()));
        }


        [Fact]
        public void GetAll_ReturnsOk()
        {
            var result = _carsController.Get();
            Assert.IsType<ActionResult<IEnumerable<CarDTO>>>(result);
        }

        [Fact]
        public void GetById_ReturnsOk()
        {
            Random rand = new Random();
            var id = rand.Next(_carsController.Get().Value.Count());
            var result = _carsController.Get(id);
            Assert.IsType<ActionResult<DriversServicesAPI.DTO.CarDTO>>(result);
        }
        [Fact]
        public void GetById_ReturnsNotFound()
        {
            var id = _carsController.Get().Value.Count() + 2;
            var result = _carsController.Get(id);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Put_ReturnsOk()
        {
            Random rand = new Random();
            var id = rand.Next(_carsController.Get().Value.Count());
            CarDTO carToUpdate = new CarDTO();
            carToUpdate.Id = 4;
            carToUpdate.Status = true;
            carToUpdate.Manufacturer = "Sdf";
            carToUpdate.NumPlaces = 1;
            carToUpdate.PlateNumber = "123545";
            carToUpdate.Condition = CarDTO.ConditionCar.RENTED;
            carToUpdate.DriverId = "5";
            var result = _carsController.Put(carToUpdate);
            Assert.IsType<OkResult>(result);
        }


        [Fact]
        public void Post_ReturnsOk()
        {
            var id = _carsController.Get().Value.Count() + 1;
            CarDTO carToAdd = new CarDTO();
            carToAdd.Manufacturer = "jkl";
            carToAdd.NumPlaces = 1;
            carToAdd.PlateNumber = "1254";
            carToAdd.Condition = CarDTO.ConditionCar.UNDER_REPAIR;
            carToAdd.DriverId = "4";
            carToAdd.Status = false;
            var result = _carsController.Post(carToAdd);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Post_ReturnsBadRequest()
        {
            var id = _carsController.Get().Value.Count() + 1;
            CarDTO carToAdd = new CarDTO();
            carToAdd.Manufacturer = "jkl";
            carToAdd.NumPlaces = -9;
            carToAdd.PlateNumber = "1254";
            carToAdd.Condition = CarDTO.ConditionCar.BROKEN_DOWN;
            carToAdd.DriverId = "5";
            carToAdd.Status = false;
            var result = _carsController.Post(carToAdd);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Delete_ReturnsOk()
        {
            Random rand = new Random();
            var id = rand.Next(_carsController.Get().Value.Count());
            var result = _carsController.Delete(id);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void Delete_ReturnsNotFound()
        {
            var id = _carsController.Get().Value.Count() + 32;
            var result = _carsController.Delete(id);
            Assert.IsType<NotFoundResult>(result);
        }


    }
}