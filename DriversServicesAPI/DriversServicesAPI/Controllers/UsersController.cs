
using Microsoft.AspNetCore.Mvc;
using DriversServicesAPI.Services;
using DriversServicesAPI.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly UserService _UserService;
        public UsersController()
        {
            _UserService = new UserService();
        }

        [HttpGet]

        public ActionResult<IEnumerable<UserDTO>> Get()
        {

            List<UserDTO> Users = _UserService.GetAllUsers();
            if (Users == null)
            {
                return NotFound();
            }
            return Ok(Users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(string id)
        {
            UserDTO result = _UserService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] UserDTO user)
        {
            if(_UserService.AddUser(user))
                return NoContent();
            return BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] UserDTO user)
        {
            if(_UserService.UpdateUser(user))
                return NoContent();
            return NotFound();
        }
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            if(_UserService.DeleteUser(id))
                return NoContent();
            return NotFound();
        }
    }
}

