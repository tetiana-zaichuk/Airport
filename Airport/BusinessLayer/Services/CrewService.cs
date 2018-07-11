using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class CrewService
    {
        public DataAccessLayer.Models.Crew IsCrew(int id) 
            => DataSeends.Crews.FirstOrDefault(a => a.Id == id);

        public List<Crew> GetCrew() 
            => Mapper.Map<List<DataAccessLayer.Models.Crew>,List<Crew>>(DataSeends.Crews);

        public Crew GetCrewDetails(int id)
            => Mapper.Map<DataAccessLayer.Models.Crew, Crew>(IsCrew(id));
        
        public void AddCrew(Crew crew)
            => DataSeends.Crews.Add(Mapper.Map<Crew, DataAccessLayer.Models.Crew>(crew));
        
        public void UpdateCrew(Crew crew)
        {
            var team = IsCrew(crew.Id);
            team.PilotId = crew.PilotId;
            team.Stewardesses = Mapper.Map<List<Stewardess>, List<DataAccessLayer.Models.Stewardess>>(crew.Stewardesses);
        }

        public void RemoveCrew(int id) => DataSeends.Crews.Remove(IsCrew(id));

        public void RemoveCrews() => DataSeends.Crews.Clear();
    }
}
