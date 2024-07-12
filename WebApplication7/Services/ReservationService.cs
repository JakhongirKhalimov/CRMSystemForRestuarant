using RestuarantCRM.DTOs;
using RestuarantCRM.Interfaces;
using RestuarantCRM.Models;
using RestuarantCRM.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RestuarantCRM.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationService(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public List<ReservationDTO> GetAllReservations()
        {
            var reservations = _reservationRepository.GetAll();
            return reservations.Select(reservation => MapToReservationDTO(reservation)).ToList();
        }

        public ReservationDTO GetReservationById(int id)
        {
            var reservation = _reservationRepository.GetById(id);
            return MapToReservationDTO(reservation);
        }

        public void AddReservation(ReservationDTO reservation)
        {
            var entity = MapToReservation(reservation);
            _reservationRepository.Add(entity);
        }

        public void UpdateReservation(ReservationDTO reservation)
        {
            var entity = MapToReservation(reservation);
            _reservationRepository.Update(entity);
        }

        public void DeleteReservation(int id)
        {
            _reservationRepository.Delete(id);
        }

        // Manual mapping methods
        private ReservationDTO MapToReservationDTO(Reservation reservation)
        {
            return new ReservationDTO
            {
                Id = reservation.Id,
                CustomerId = reservation.CustomerId,
                ReservationDate = reservation.ReservationDate,
                // Map other properties as needed
            };
        }

        private Reservation MapToReservation(ReservationDTO reservationDTO)
        {
            return new Reservation
            {
                Id = reservationDTO.Id,
                CustomerId = reservationDTO.CustomerId,
                ReservationDate = reservationDTO.ReservationDate,
                // Map other properties as needed
            };
        }
    }
}
