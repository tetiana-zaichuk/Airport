using System;

namespace DataAccessLayer.Models
{
    public class Departure
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public DateTime DepartureDate { get; set; }
        public int CrewId { get; set; }
        public int AircraftId { get; set; }
    }
}
