using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Model
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
