
using Microsoft.AspNetCore.Mvc;
using DriversServicesAPI.Services;
using DriversServicesAPI.DTO;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrdersServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        readonly OrderService _OrderService;
        public OrdersController(OrderService orderService)
        {
            _OrderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDTO>> Get()
        {

            List<OrderDTO> orders = _OrderService.GetAllOrders();
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderDTO> Get(int id)
        {
            OrderDTO result = _OrderService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult Post([FromBody] OrderDTO order)
        {
           if( _OrderService.AddOrder(order))
                return NoContent();
            return BadRequest();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] OrderDTO order)
        {
            if(_OrderService.UpdateOrder(order))
                return NoContent();
            return NotFound();
        }
        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
           if( _OrderService.DeleteOrder(id))
                return NoContent();
            return NotFound();
        }
    }
}

