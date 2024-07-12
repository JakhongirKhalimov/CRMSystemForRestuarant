using RestuarantCRM.DTOs;
using System.Collections.Generic;

namespace RestuarantCRM.Interfaces
{
    public interface IReservationService
    {
        List<ReservationDTO> GetAllReservations();
        ReservationDTO GetReservationById(int id);
        void AddReservation(ReservationDTO reservation);
        void UpdateReservation(ReservationDTO reservation);
        void DeleteReservation(int id);
    }
}
