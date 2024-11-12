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
        public CarsController(CarService carService)
        {
            _carService = carService;
        }
        // GET: api/<CarsController>
        [HttpGet]
        public ActionResult<IEnumerable<CarDTO> >Get()
        {
            List<CarDTO> cars = _carService.GetAllCars();
            if (cars == null)
            {
                return NotFound();
            }
            return cars;
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
            return result;
        }

        // POST api/<CarsController>
        [HttpPost]
        public ActionResult Post([FromBody] CarDTO car)
        {
           
           if( _carService.AddCar(car))
                return Ok();
           return BadRequest();
        }

        // PUT api/<CarsController>/5
        [HttpPut]
        public ActionResult Put([FromBody] CarDTO car)
        {

            //validation
            if(car.NumPlaces<=0)
                return BadRequest("Invalid num of places");

           if( _carService.UpdateCar(car))
                return Ok();
           return NotFound();
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           if( _carService.DeleteCar(id))
                return Ok();
           return NotFound();
        }
    }
}
