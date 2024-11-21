using Microsoft.AspNetCore.Mvc;
using Drivers.Core.Entities;
using Drivers.Core.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
namespace Drivers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        readonly ITravelService _travelService;
        public TravelsController(ITravelService travelService)
        {
            _travelService = travelService;
        }
        // GET: api/<CarsController>
        [HttpGet]
        public ActionResult<IEnumerable<Travel>> Get()
        {

            List<Travel> Travels = _travelService.GetAllTravels();
            if (Travels == null)
            {
                return NotFound();
            }
            return Ok(Travels);
        }

        // GET api/<TravelController>/5
        [HttpGet("{id}")]
        public ActionResult<Travel> Get(int id)
        {
            Travel result = _travelService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // POST api/<TravelController>
        [HttpPost]
        public ActionResult Post([FromBody] Travel travel)
        {
            if (_travelService.AddTravel(travel))
                return NoContent();
            return BadRequest();
        }

        // PUT api/<TravelController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Travel travel)
        {
            if (_travelService.UpdateTravel(id, travel))
                return NoContent();
            return NotFound();
        }
        // DELETE api/<TravelController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_travelService.DeleteTravel(id))
                return NoContent();
            return NotFound();
        }
    }
}
