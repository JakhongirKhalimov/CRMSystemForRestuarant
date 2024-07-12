using Dapper;
using RestuarantCRM.Interfaces;
using RestuarantCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class CustomerRepository
{
    private readonly IConnectionFactory1 _connectionFactory;

    public CustomerRepository(IConnectionFactory1 connectionFactory)
    {
        _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
    }

    public List<Customer> GetAll()
    {
        try
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                return (List<Customer>)connection.Query<Customer>("SELECT * FROM Customers");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving all customers: {ex.Message}");
            throw; // Rethrow the exception or handle it appropriately
        }
    }

    public Customer GetById(int id)
    {
        try
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                if (connection == null)
                {
                    throw new InvalidOperationException("Database connection is not initialized.");
                }

                connection.Open(); // Ensure the connection is open

                var query = "SELECT * FROM Customers WHERE Id = @Id";
                var parameters = new { Id = id };

                var customers = connection.Query<Customer>(query, parameters);

                return customers.FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving customer with ID {id}: {ex.Message}");
            throw; // Rethrow the exception or handle it appropriately
        }
    }

    public void Add(Customer customer)
    {
        try
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = "INSERT INTO Customers (Name, Email, Phone) VALUES (@Name, @Email, @Phone)";
                connection.Execute(sql, customer);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding customer: {ex.Message}");
            throw; // Rethrow the exception or handle it appropriately
        }
    }

    public void Update(Customer customer)
    {
        try
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = "UPDATE Customers SET Name = @Name, Email = @Email, Phone = @Phone WHERE Id = @Id";
                connection.Execute(sql, customer);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating customer with ID {customer.Id}: {ex.Message}");
            throw; // Rethrow the exception or handle it appropriately
        }
    }

    public void Delete(int id)
    {
        try
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var sql = "DELETE FROM Customers WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting customer with ID {id}: {ex.Message}");
            throw; // Rethrow the exception or handle it appropriately
        }
    }
}
