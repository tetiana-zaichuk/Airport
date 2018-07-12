using System;

namespace DataAccessLayer.Models
{
    public class Pilot : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public int Experience { get; set; }
    }
}
