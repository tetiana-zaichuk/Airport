namespace DataAccessLayer.Models
{
    public class Ticket : Entity
    {
        public decimal Price { get; set; }
        public int FlightId { get; set; }
    }
}
