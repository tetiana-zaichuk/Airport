using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class StewardessService
    {
        public DataAccessLayer.Models.Stewardess IsStewardess(int id)
            => DataSeends.Stewardesses.FirstOrDefault(a => a.Id == id);

        public List<Stewardess> GetStewardesses()
            => Mapper.Map<List<DataAccessLayer.Models.Stewardess>, List<Stewardess>>(DataSeends.Stewardesses);

        public Stewardess GetStewardessDetails(int id)
            => Mapper.Map<DataAccessLayer.Models.Stewardess, Stewardess>(IsStewardess(id));

        public void AddStewardess(Stewardess stewardess)
            => DataSeends.Stewardesses.Add(Mapper.Map<Stewardess, DataAccessLayer.Models.Stewardess>(stewardess));

        public void UpdateStewardess(Stewardess stewardess)
        {
            var st = IsStewardess(stewardess.Id);
            st.FirstName = stewardess.FirstName;
            st.LastName = stewardess.LastName;
            st.Dob = stewardess.Dob;
        }

        public void RemoveStewardess(int id) => DataSeends.Stewardesses.Remove(IsStewardess(id));

        public void RemoveStewardesses() => DataSeends.Stewardesses.Clear();
    }
}
