namespace DataAccessLayer.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int FlightId { get; set; }
    }
}
