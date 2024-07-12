using Dapper;
using RestuarantCRM.Interfaces;
using RestuarantCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace RestuarantCRM.Repositories
{
    public class ReservationRepository
    {
        private readonly IConnectionFactory1 _connectionFactory;

        public ReservationRepository(IConnectionFactory1 connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public List<Reservation> GetAll()
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    return (List<Reservation>)connection.Query<Reservation>("SELECT * FROM Reservations");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all reservations: {ex.Message}");
                throw;
            }
        }

        public Reservation GetById(int id)
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    connection.Open();

                    var query = "SELECT * FROM Reservations WHERE Id = @Id";

                    var parameters = new { Id = id };

                    var customers = connection.Query<Reservation>(query, parameters);

                    return customers.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving reservation with ID {id}: {ex.Message}");
                throw;
            }
        }

        public void Add(Reservation reservation)
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    var sql = "INSERT INTO Reservations (CustomerId, ReservationDate, NumberOfPeople) VALUES (@CustomerId, @ReservationDate, @NumberOfPeople)";
                    connection.Execute(sql, reservation);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding reservation: {ex.Message}");
                throw;
            }
        }

        public void Update(Reservation reservation)
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    var sql = "UPDATE Reservations SET CustomerId = @CustomerId, ReservationDate = @ReservationDate, NumberOfPeople = @NumberOfPeople WHERE Id = @Id";
                    connection.Execute(sql, reservation);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating reservation with ID {reservation.Id}: {ex.Message}");
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var connection = _connectionFactory.CreateConnection())
                {
                    var sql = "DELETE FROM Reservations WHERE Id = @Id";
                    connection.Execute(sql, new { Id = id });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting reservation with ID {id}: {ex.Message}");
                throw;
            }
        }
    }
}
