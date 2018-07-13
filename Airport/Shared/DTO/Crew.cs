using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class Crew
    {
        public int Id { get; set; }
        [Required]
        public int PilotId { get; set; }
        [Required]
        public List<int> StewardessesId=new List<int>();
    }
}
