
using RestuarantCRM.DTOs;
using RestuarantCRM.Interfaces;
using RestuarantCRM.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestuarantCRM.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll();
            return customers.Select(c => MapToCustomerDTO(c)).ToList();
        }

        public CustomerDTO GetCustomerById(int id)
        {
            var customer = _customerRepository.GetById(id);
            return MapToCustomerDTO(customer);
        }

        public void AddCustomer(CustomerDTO customer)
        {
            var entity = MapToCustomer(customer);
            _customerRepository.Add(entity);
        }

        public void UpdateCustomer(CustomerDTO customer)
        {
            var entity = MapToCustomer(customer);
            _customerRepository.Update(entity);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.Delete(id);
        }

        // Manual mapping methods
        private CustomerDTO MapToCustomerDTO(Customer customer)
        {
            return new CustomerDTO
            {
                Id = customer.Id,
                Name = customer.Name,
                // Map other properties as needed
            };
        }

        private Customer MapToCustomer(CustomerDTO customerDTO)
        {
            return new Customer
            {
                Id = customerDTO.Id,
                Name = customerDTO.Name,
                // Map other properties as needed
            };
        }
    }
}

