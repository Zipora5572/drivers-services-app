
using Microsoft.AspNetCore.Mvc;
using DriversServicesAPI.Services;
using DriversServicesAPI.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelsServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {

        readonly TravelService _TravelService;
        public TravelsController(TravelService travelService)
        {
            _TravelService = travelService;
        }

        [HttpGet]

        public ActionResult<IEnumerable<TravelDTO>> Get()
        {

            List<TravelDTO> Travels = _TravelService.GetAllTravels();
            if (Travels == null)
            {
                return NotFound();
            }
            return Ok(Travels);
        }

        // GET api/<TravelController>/5
        [HttpGet("{id}")]
        public ActionResult<TravelDTO> Get(int id)
        {
            TravelDTO result = _TravelService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // POST api/<TravelController>
        [HttpPost]
        public ActionResult Post([FromBody] TravelDTO travel)
        {
            if (_TravelService.AddTravel(travel))
                return NoContent();
            return BadRequest();
        }

        // PUT api/<TravelController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] TravelDTO travel)
        {
            if(_TravelService.UpdateTravel(travel))
                return NoContent();
            return NotFound();
        }
        // DELETE api/<TravelController>/5
        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            if(_TravelService.DeleteTravel(id))
                return NoContent();
            return NotFound();
        }
    }




}
