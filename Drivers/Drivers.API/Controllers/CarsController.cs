using Drivers.Core.Entities;
using Drivers.Core.Services;
using Drivers.Service;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Drivers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        // GET: api/<CarsController>
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            List<Car> cars = _carService.GetAllCars();
            if (cars == null)
            {
                return NotFound();
            }
            return cars;
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            Car result = _carService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // POST api/<CarsController>
        [HttpPost]
        public ActionResult Post([FromBody] Car car)
        {
            var createdCar = _carService.AddCar(car);
            if (createdCar != null)
            {
                return CreatedAtAction(nameof(Get), new { id = createdCar.Id }, createdCar);
            }
            return BadRequest();
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Car car)
        {
            //validation
            if (car.NumPlaces <= 0)
                return BadRequest("Invalid num of places");

            Car updatedCar = _carService.UpdateCar(id, car);
            return Ok(updatedCar);
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Car car = _carService.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            _carService.DeleteCar(car);
            return NoContent();
        }
    }
}
