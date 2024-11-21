using Microsoft.AspNetCore.Mvc;
using Drivers.Core.Entities;
using Drivers.Core.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
namespace Drivers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IOrderService _orderService;
        public OrdersController(IOrderService carService)
        {
            _orderService = carService;
        }

        // GET: api/<CarsController>
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {

            List<Order> orders = _orderService.GetAllOrders();
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            Order result = _orderService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            if (_orderService.AddOrder(order))
                return NoContent();
            return BadRequest();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Order order)
        {
            if (_orderService.UpdateOrder(id, order))
                return NoContent();
            return NotFound();
        }
        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            if (_orderService.DeleteOrder(id))
                return NoContent();
            return NotFound();
        }

    }
}
