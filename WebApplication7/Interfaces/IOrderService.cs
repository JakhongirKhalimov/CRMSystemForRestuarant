using RestuarantCRM.DTOs;
using System.Collections.Generic;

namespace RestuarantCRM.Interfaces
{
    public interface IOrderService
    {
        List<OrderDTO> GetAllOrders();
        OrderDTO GetOrderById(int id);
        void AddOrder(OrderDTO order);
        void UpdateOrder(OrderDTO order);
        void DeleteOrder(int id);
    }
}
