using Microsoft.AspNetCore.Mvc;
using RestuarantCRM.DTOs;
using RestuarantCRM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication7.Controllers
{

    [Route("api/reservations")]
    public class ReservationsController : ApiController
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public IEnumerable<ReservationDTO> GetAllReservations()
        {
            return _reservationService.GetAllReservations();
        }

        [HttpGet]
        public ReservationDTO GetReservationById(int id)
        {
            return _reservationService.GetReservationById(id);
        }

        [HttpPost]
        public IActionResult AddReservation([FromBody] ReservationDTO reservation)
        {
            if (!ModelState.IsValid)
            {
                return (IActionResult)BadRequest(ModelState);
            }

            _reservationService.AddReservation(reservation);
            return (IActionResult)Ok();
        }

        [HttpPut]
        public IActionResult UpdateReservation([FromBody] ReservationDTO reservation)
        {
            if (!ModelState.IsValid)
            {
                return (IActionResult)BadRequest(ModelState);
            }

            _reservationService.UpdateReservation(reservation);
            return (IActionResult)Ok();
        }

        [HttpDelete]
        public IActionResult DeleteReservation(int id)
        {
            _reservationService.DeleteReservation(id);
            return (IActionResult)Ok();
        }
    }
}
