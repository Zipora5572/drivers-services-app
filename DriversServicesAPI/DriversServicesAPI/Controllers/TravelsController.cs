
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
        public TravelsController()
        {
            _TravelService = new TravelService();
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
        public void Post([FromBody] TravelDTO travel)
        {
            _TravelService.AddTravel(travel);
        }

        // PUT api/<TravelController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] TravelDTO travel)
        {
            _TravelService.UpdateTravel(travel);
        }
        // DELETE api/<TravelController>/5
        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            _TravelService.DeleteTravel(id);
        }
    }




}
