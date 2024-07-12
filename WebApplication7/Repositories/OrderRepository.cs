using Dapper;
using RestuarantCRM.Interfaces;
using RestuarantCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace RestuarantCRM.Repositories
{
    public class OrderRepository
    {
        private readonly IConnectionFactory1 _connectionFactory;

        public OrderRepository(IConnectionFactory1 connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public List<Order> GetAll()
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    return (List<Order>)connection.Query<Order>("SELECT * FROM Orders");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all orders: {ex.Message}");
                throw;
            }
        }

        public Order GetById(int id)
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    connection.Open();

                    var query = "SELECT * FROM Orders WHERE Id = @Id";
                    var parameters = new { Id = id };

                    var orders = connection.Query<Order>(query, parameters);

                    return orders.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving order with ID {id}: {ex.Message}");
                throw;
            }
        }

        public void Add(Order order)
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    var sql = "INSERT INTO Orders (CustomerId, Details) VALUES (@CustomerId, @Details)";
                    connection.Execute(sql, order);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding order: {ex.Message}");
                throw;
            }
        }

        public void Update(Order order)
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    var sql = "UPDATE Orders SET CustomerId = @CustomerId, Details = @Details WHERE Id = @Id";
                    connection.Execute(sql, order);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating order with ID {order.Id}: {ex.Message}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    var sql = "DELETE FROM Orders WHERE Id = @Id";
                    connection.Execute(sql, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting order with ID {id}: {ex.Message}");
                throw;
            }
        }
    }
}
