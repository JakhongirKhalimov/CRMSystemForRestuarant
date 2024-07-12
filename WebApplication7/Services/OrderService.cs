using RestuarantCRM.DTOs;
using RestuarantCRM.Interfaces;
using RestuarantCRM.Models;
using RestuarantCRM.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RestuarantCRM.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<OrderDTO> GetAllOrders()
        {
            var orders = _orderRepository.GetAll();
            return orders.Select(order => MapToOrderDTO(order)).ToList();
        }

        public OrderDTO GetOrderById(int id)
        {
            var order = _orderRepository.GetById(id);
            return MapToOrderDTO(order);
        }

        public void AddOrder(OrderDTO order)
        {
            var entity = MapToOrder(order);
            _orderRepository.Add(entity);
        }

        public void UpdateOrder(OrderDTO order)
        {
            var entity = MapToOrder(order);
            _orderRepository.Update(entity);
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
        }

        // Manual mapping methods
        private OrderDTO MapToOrderDTO(Order order)
        {
            return new OrderDTO
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                // Map other properties as needed
            };
        }

        private Order MapToOrder(OrderDTO orderDTO)
        {
            return new Order
            {
                Id = orderDTO.Id,
                CustomerId = orderDTO.CustomerId,
                // Map other properties as needed
            };
        }
    }
}
