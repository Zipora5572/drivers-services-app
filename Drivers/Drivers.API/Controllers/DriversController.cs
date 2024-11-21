using Microsoft.AspNetCore.Mvc;
using Drivers.Core.Entities;
using Drivers.Core.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Drivers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        readonly IDriverService _driverService;
        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }
        // GET: api/<CarsController>
        [HttpGet]
        public ActionResult<IEnumerable<Driver>> Get()
        {

            List<Driver> drivers = _driverService.GetAllDrivers();
            if (drivers == null)
            {
                return NotFound();
            }
            return Ok(drivers);
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public ActionResult<Driver> Get(int id)
        {
            Driver result = _driverService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // POST api/<DriverController>
        [HttpPost]
        public ActionResult Post([FromBody] Driver driver)
        {
            if (_driverService.AddDriver(driver))
                return NoContent();
            return BadRequest();
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Driver driver)
        {
            if (_driverService.UpdateDriver(id, driver))
                return NoContent();
            return NotFound();
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_driverService.DeleteDriver(id))
                return NoContent();
            return NotFound();
        }
    }
}
