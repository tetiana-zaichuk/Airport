using System;
using Airport.Model;

namespace PresentationLayer.Model
{
    public class Aircraft
    {
        public int Id { get; set; }
        public string AircraftName { get; set; }
        public int AircraftTypeId { get; set; }
        public DateTime AircraftReleaseDate { get; set; }
        public TimeSpan ExploitationTimeSpan { get; set; }
    }
}
