using Microsoft.AspNetCore.Mvc;
using Drivers.Core.Entities;
using Drivers.Core.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Drivers.Service;

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
        // GET: api/<usersController>
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
            var createdUser = _userService.AddUser(user);
            if (createdUser != null)
            {
                return CreatedAtAction(nameof(Get), new { id = createdUser.Id }, createdUser);
            }
            return BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {

            
            User updatedUser = _userService.UpdateUser(id, user);
            return Ok(updatedUser);
        }
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            User user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            _userService.DeleteUser(user);
            return NoContent();
        }
    }
}
