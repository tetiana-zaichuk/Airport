using System;
using System.Collections.Generic;

namespace Shared.DTO
{
    public class Flight
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
        public List<Ticket> Tickets = new List<Ticket>();
    }
}
