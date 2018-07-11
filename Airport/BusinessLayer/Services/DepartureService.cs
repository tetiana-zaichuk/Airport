using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class DepartureService
    {
        public DataAccessLayer.Models.Departure IsDeparture(int id)
            => DataSeends.Departures.FirstOrDefault(a => a.Id == id);

        public List<Departure> GetDeparture()
            => Mapper.Map<List<DataAccessLayer.Models.Departure>, List<Departure>>(DataSeends.Departures);

        public Departure GetDepartureDetails(int id)
            => Mapper.Map<DataAccessLayer.Models.Departure, Departure>(IsDeparture(id));

        public void AddDeparture(Departure departure)
            => DataSeends.Departures.Add(Mapper.Map<Departure, DataAccessLayer.Models.Departure>(departure));

        public void UpdateDeparture(Departure departure)
        {
            var dep = IsDeparture(departure.Id);
            dep.FlightId = departure.FlightId;
            dep.AircraftId = departure.AircraftId;
            dep.CrewId = departure.CrewId;
            dep.DepartureDate = departure.DepartureDate;
        }

        public void RemoveDeparture(int id) => DataSeends.Departures.Remove(IsDeparture(id));

        public void RemoveDepartures() => DataSeends.Departures.Clear();
    }
}
