using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class Departure
    {
        
        public int Id { get; set; }
        [Required]
        public int FlightId { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public int CrewId { get; set; }
        [Required]
        public int AircraftId { get; set; }
    }
}
