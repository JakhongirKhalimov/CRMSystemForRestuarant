using Microsoft.AspNetCore.Mvc;
using RestuarantCRM.DTOs;
using RestuarantCRM.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApplication7.Controllers
{
    [Route("api/customers")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public List<CustomerDTO> GetAllCustomers()
        {
            return _customerService.GetAllCustomers();
        }

        [HttpGet]
        public CustomerDTO GetCustomerById(int id)
        {
            return _customerService.GetCustomerById(id);
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] CustomerDTO customer)
        {
            if (!ModelState.IsValid)
            {
                return (IActionResult)BadRequest(ModelState);
            }

            _customerService.AddCustomer(customer);
            return (IActionResult)Ok();
        }

        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] CustomerDTO customer)
        {
            if (!ModelState.IsValid)
            {
                return (IActionResult)BadRequest(ModelState);
            }

            _customerService.UpdateCustomer(customer);
            return (IActionResult)Ok();
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
            return (IActionResult)Ok();
        }
    }
}
