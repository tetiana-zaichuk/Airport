using System.Collections.Generic;

namespace Shared.DTO
{
    public class Crew
    {
        public int Id { get; set; }
        public int PilotId { get; set; }
        public List<Stewardess> Stewardesses=new List<Stewardess>();
    }
}
