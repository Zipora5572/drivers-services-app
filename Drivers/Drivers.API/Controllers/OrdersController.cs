using Microsoft.AspNetCore.Mvc;
using Drivers.Core.Entities;
using Drivers.Core.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Drivers.Service;

namespace Drivers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<ordersController>
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
            var createdOrder = _orderService.AddOrder(order);
            if (createdOrder != null)
            {
                return CreatedAtAction(nameof(Get), new { id = createdOrder.Id }, createdOrder);
            }
            return BadRequest();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Order order)
        {

           
            Order updatedorder = _orderService.UpdateOrder(id, order);
            return Ok(updatedorder);
        }
        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            Order order = _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            _orderService.DeleteOrder(order);
            return NoContent();
        }

    }
}
