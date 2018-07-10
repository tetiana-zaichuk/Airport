using System.Collections.Generic;
using Airport.Model;

namespace PresentationLayer.Model
{
    public class Сrew
    {
        public int Id { get; set; }
        public int PilotId { get; set; }
        public List<Stewardess> Stewardesses=new List<Stewardess>();
    }
}
