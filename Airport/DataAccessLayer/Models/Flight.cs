using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Flight : Entity
    {
        public string Departure { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalTime { get; set; }
        public List<int> TicketsId = new List<int>();
    }
}
