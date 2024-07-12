using System;
using WebApplication7.Models;

namespace RestuarantCRM.Models
{
    public class Reservation : BaseEntity
    {

        public int CustomerId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfPeople { get; set; }
        public  Customer Customer { get; set; } 
    }
}
