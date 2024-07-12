namespace RestuarantCRM.DTOs
{
    public class OrderDTO
    {

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Details { get; set; } = string.Empty;
    }
}
