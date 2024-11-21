using Microsoft.AspNetCore.Mvc;
using Drivers.Core.Entities;
using Drivers.Core.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
namespace Drivers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<CarsController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {

            List<User> Users = _userService.GetAllUsers();
            if (Users == null)
            {
                return NotFound();
            }
            return Ok(Users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User result = _userService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            if (_userService.AddUser(user))
                return NoContent();
            return BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            if (_userService.UpdateUser(id, user))
                return NoContent();
            return NotFound();
        }
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_userService.DeleteUser(id))
                return NoContent();
            return NotFound();
        }
    }
}
