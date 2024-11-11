using DriversServicesAPI.DTO;
using DriversServicesAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DriversServicesAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {


        readonly DriverService _driverService;
        public DriversController()
        {
            _driverService = new DriverService();
        }

        [HttpGet]

        public ActionResult<IEnumerable<DriverDTO>> Get()
        {

            List<DriverDTO> drivers = _driverService.GetAllDrivers();
            if (drivers == null)
            {
                return NotFound();
            }
            return Ok(drivers);
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public ActionResult<DriverDTO> Get(string id)
        {
            DriverDTO result = _driverService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // POST api/<DriverController>
        [HttpPost]
        public ActionResult Post([FromBody] DriverDTO driver)
        {
            if(_driverService.AddDriver(driver))
                return NoContent();
            return BadRequest();
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] DriverDTO car)
        {
            if(_driverService.UpdateDriver(car))
                return NoContent();
            return NotFound();
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]

        public ActionResult Delete(string id)
        {
            if(_driverService.DeleteDriver(id))
                return NoContent();
            return NotFound();
        }
    }

}

