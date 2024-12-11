using Microsoft.AspNetCore.Mvc;
using Drivers.Core.Entities;
using Drivers.Core.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Drivers.Service;

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
        // GET: api/<travelsController>
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
            var createdTravel = _travelService.AddTravel(travel);
            if (createdTravel != null)
            {
                return CreatedAtAction(nameof(Get), new { id = createdTravel.Id }, createdTravel);
            }
            return BadRequest();
        }

        // PUT api/<TravelController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Travel travel)
        {

           
            Travel updatedtravel = _travelService.UpdateTravel(id, travel);
            return Ok(updatedtravel);
        }
        // DELETE api/<TravelController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            Travel travel = _travelService.GetById(id);
            if (travel == null)
            {
                return NotFound();
            }
            _travelService.DeleteTravel(travel);
            return NoContent();
        }
    }
}
