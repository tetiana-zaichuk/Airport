using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class AircraftService
    {
        public DataAccessLayer.Models.Aircraft IsAircraft(int id) 
            => DataSeends.Aircraft.FirstOrDefault(a => a.Id == id);

        public List<Aircraft> GetAircraft() 
            => Mapper.Map<List<DataAccessLayer.Models.Aircraft>,List<Aircraft>>(DataSeends.Aircraft);

        public Aircraft GetAircraftDetails(int id)
            => Mapper.Map<DataAccessLayer.Models.Aircraft, Aircraft>(IsAircraft(id));
        
        public void AddAircraft(Aircraft aircraft)
            => DataSeends.Aircraft.Add(Mapper.Map<Aircraft, DataAccessLayer.Models.Aircraft>(aircraft));
        
        public void UpdateAircraft(Aircraft aircraft)
        {
            var plane = IsAircraft(aircraft.Id);
            plane.AircraftName = aircraft.AircraftName;
            plane.AircraftReleaseDate = aircraft.AircraftReleaseDate;
            plane.AircraftTypeId = aircraft.AircraftTypeId;
            plane.ExploitationTimeSpan = aircraft.ExploitationTimeSpan;
        }

        public void RemoveAircraft(int id) => DataSeends.Aircraft.Remove(IsAircraft(id));

        public void RemoveAircrafts() => DataSeends.Aircraft.Clear();
    }
}
