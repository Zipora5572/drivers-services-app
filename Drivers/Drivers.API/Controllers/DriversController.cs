using Microsoft.AspNetCore.Mvc;
using Drivers.Core.Entities;
using Drivers.Core.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Drivers.Service;

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
        // GET: api/<driversController>
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
            var createdDriver = _driverService.AddDriver(driver);
            if (createdDriver != null)
            {
                return CreatedAtAction(nameof(Get), new { id = createdDriver.Id }, createdDriver);
            }
            return BadRequest();
        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Driver driver)
        {


            
            Driver updatedDriver = _driverService.UpdateDriver(id, driver);
            return Ok(updatedDriver);
           
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Driver driver = _driverService.GetById(id);
            if (driver == null)
            {
                return NotFound();
            }
            _driverService.DeleteDriver(driver);
            return NoContent();
        }
    }
}
