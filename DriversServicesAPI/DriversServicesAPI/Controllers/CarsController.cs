using DriversServicesAPI.DTO;
using DriversServicesAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DriversServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        readonly CarService _carService;
        public CarsController()
        {
            _carService = new CarService();
        }
        // GET: api/<CarsController>
        [HttpGet]
        public ActionResult< IEnumerable<CarDTO> >Get()
        {
            List<CarDTO> cars = _carService.GetAllCars();
            if (cars == null)
            {
                return NotFound();
            }
            return Ok(cars);
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public ActionResult<CarDTO> Get(int id)
        {
           CarDTO result = _carService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody] CarDTO car)
        {
            _carService.AddCar(car);
        }

        // PUT api/<CarsController>/5
        [HttpPut]
        public void Put( [FromBody] CarDTO car)
        {
            _carService.UpdateCar(car);
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _carService.DeleteCar(id);
        }
    }
}
