using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestuarantCRM.DTOs;
using RestuarantCRM.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace RestuarantCRM.Controllers
{
    [Route("api/orders")]
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<OrderDTO> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }

        [HttpGet]
        public OrderDTO GetOrderById(int id)
        {
            return _orderService.GetOrderById(id);
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderDTO order)
        {
            if (!ModelState.IsValid)
            {
                return (IActionResult)BadRequest(ModelState);
            }

            _orderService.AddOrder(order);
            return (IActionResult)Ok();
        }

        [HttpPut]
        public IActionResult UpdateOrder([FromBody] OrderDTO order)
        {
            if (!ModelState.IsValid)
            {
                return (IActionResult)BadRequest(ModelState);
            }

            _orderService.UpdateOrder(order);
            return (IActionResult)Ok();
        }

        [HttpDelete]
        public IActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return (IActionResult)Ok();
        }
    }
}
