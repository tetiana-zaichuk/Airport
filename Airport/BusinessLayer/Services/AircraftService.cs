using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PresentationLayer;
using PresentationLayer.Model;

namespace BusinessLayer.Services
{
    class AircraftService
    {
        public List<Aircraft> GetAircraft() => Seeds.Aircraft;

        public string GetAircraftDetails(int id)
        {
            var aircraft = Seeds.Aircraft.FirstOrDefault(a => a.Id == id);
            return "" + aircraft?.Id + " " + aircraft?.AircraftName + " " + aircraft?.AircraftReleaseDate + " " +
                   aircraft?.AircraftTypeId + " " + aircraft?.ExploitationTimeSpan;
        }

        public void AddAircraft(int id, string name, int typeId, DateTime releaseTime, TimeSpan expl)
        {
            Seeds.Aircraft.Add(new Aircraft()
            {
                Id = id,
                AircraftName = name,
                AircraftTypeId = typeId,
                AircraftReleaseDate = releaseTime,
                ExploitationTimeSpan = expl
            });
        }

        public void UpdateAircraft()
        {

        }

        public void RemoveAircraft(int id)
        {
            Seeds.Aircraft.Remove(Seeds.Aircraft.FirstOrDefault(a => a.Id == id));
        }

        public void RemoveAircrafts()
        {
            Seeds.Aircraft.Clear();
        }
    }
}
