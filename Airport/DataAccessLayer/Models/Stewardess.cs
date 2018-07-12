using System;

namespace DataAccessLayer.Models
{
    public class Stewardess : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
    }
}
