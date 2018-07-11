using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class PilotService
    {
        public DataAccessLayer.Models.Pilot IsPilot(int id)
            => DataSeends.Pilots.FirstOrDefault(a => a.Id == id);

        public List<Pilot> GetPilots()
            => Mapper.Map<List<DataAccessLayer.Models.Pilot>, List<Pilot>>(DataSeends.Pilots);

        public Pilot GetPilotDetails(int id)
            => Mapper.Map<DataAccessLayer.Models.Pilot, Pilot>(IsPilot(id));

        public void AddPilot(Pilot pilot)
            => DataSeends.Pilots.Add(Mapper.Map<Pilot, DataAccessLayer.Models.Pilot>(pilot));

        public void UpdatePilot(Pilot pilot)
        {
            var p = IsPilot(pilot.Id);
            p.FirstName = pilot.FirstName;
            p.LastName = pilot.LastName;
            p.Dob = pilot.Dob;
            p.Experience = pilot.Experience;
        }

        public void RemovePilot(int id) => DataSeends.Pilots.Remove(IsPilot(id));

        public void RemovePilots() => DataSeends.Pilots.Clear();
    }
}
