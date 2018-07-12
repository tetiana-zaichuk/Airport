using System;

namespace DataAccessLayer.Models
{
    public class Aircraft: Entity
    {
        public string AircraftName { get; set; }
        public int AircraftTypeId { get; set; }
        public DateTime AircraftReleaseDate { get; set; }
        public TimeSpan ExploitationTimeSpan { get; set; }
    }
}
