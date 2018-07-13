using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Crew: Entity
    {
        public int PilotId { get; set; }
        public List<int> StewardessesId=new List<int>();
    }
}
