using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Model;
using WebApiApp.Services;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private ILoggerManager _logger;
        private readonly IOrderRepository _orderRepository;

        public OrdersController(ILoggerManager logger, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;

        }



        [HttpGet("{id}", Name = "OrderById")]
        public IActionResult GetOrderById(int id)
        {
            try
            {

                
                var order = _orderRepository.getById(id);
                return Ok(order);

            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        public IActionResult GetAllOrdersFilter(string search, OrderStatus? from, OrderStatus? to, string sortBy, int page = 1)
        {
            try
            {
                if (from > to)
                {
                    return BadRequest("Max status  cannot be less than min status ");
                }
                var result = _orderRepository.GetAll(search, from, to, sortBy, page);
                _logger.LogInfo($"Returned owners from database.");
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest("We can't get the product.");
                
            }
        }
        
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Order order)
        {


            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid owner object sent from client.");
                return BadRequest("Invalid model object");
            }
            if (order.BrandId != 0)
            {
                _orderRepository.Save(order);
            }
            else
            {
                _logger.LogError("Invalid id object sent from client.");
                return BadRequest("Invalid Brand Id");
            }



            return CreatedAtRoute("OrderById", new { id = order.Id }, order);


        }
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id,[FromBody] Order order)
        {
            /*if (order is null)
            {
                _logger.LogError("Orner object sent from client is null.");
                return BadRequest("Orner object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid orner object sent from client.");
                return BadRequest("Invalid model object");
            }
            if (order.Id != null)
            {
                _orderRepository.Update(order);
                return Ok(order);
            }
            
            else
            {
                _orderRepository.Save(order);
                _logger.LogError($"Orner with id hasn't been found in db.");
                return Ok("Order Created");
            }

            return NoContent();*/
            if (order == null)
            {
                return BadRequest("Customer is null");
            }
            Order orderToUpdate = _orderRepository.getById(id);
            if (orderToUpdate == null)
            {
                return NotFound("Order could not be found");
            }
            _orderRepository.Update(orderToUpdate,order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _orderRepository.getById(id);

            if (order != null)
            {
                _orderRepository.Delete(id);

            }
            else
            {
                _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                return NotFound();

            }

            return NoContent();


        }

    }
}

