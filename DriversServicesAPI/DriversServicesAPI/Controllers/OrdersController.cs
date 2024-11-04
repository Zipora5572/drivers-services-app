
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
        public OrdersController()
        {
            _OrderService = new OrderService();
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
        public void Post([FromBody] OrderDTO order)
        {
            _OrderService.AddOrder(order);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] OrderDTO order)
        {
            _OrderService.UpdateOrder(order);
        }
        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            _OrderService.DeleteOrder(id);
        }
    }
}

