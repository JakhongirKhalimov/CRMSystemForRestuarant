using WebApplication7.Models;

namespace RestuarantCRM.Models
{
    public class Order : BaseEntity
    {

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } 
        public string Details { get; set; } = string.Empty;
    }
}
