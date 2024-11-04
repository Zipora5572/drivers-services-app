
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
        public ActionResult<UserDTO> Get(int id)
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
        public void Post([FromBody] UserDTO user)
        {
            _UserService.AddUser(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] UserDTO user)
        {
            _UserService.UpdateUser(user);
        }
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _UserService.DeleteUser(id);
        }
    }
}

