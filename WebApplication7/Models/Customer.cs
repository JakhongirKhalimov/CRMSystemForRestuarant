using System.Collections.Generic;
using WebApplication7.Models;

namespace RestuarantCRM.Models
{
    public class Customer : BaseEntity
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public  List<Reservation> Reservations { get; set; }
        public List<Order> Orders { get; set; }
    }
}
