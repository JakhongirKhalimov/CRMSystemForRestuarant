using RestuarantCRM.DTOs;
using System.Collections.Generic;

namespace RestuarantCRM.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerById(int id);
        void AddCustomer(CustomerDTO customer);
        void UpdateCustomer(CustomerDTO customer);
        void DeleteCustomer(int id);
    }
}
