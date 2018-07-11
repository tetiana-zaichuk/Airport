using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class AircraftTypeService
    {

        public DataAccessLayer.Models.AircraftType IsAircraftTypes(int id)
            => DataSeends.AircraftTypes.FirstOrDefault(a => a.Id == id);

        public List<AircraftType> GetAircraftsTypes()
            => Mapper.Map<List<DataAccessLayer.Models.AircraftType>, List<AircraftType>>(DataSeends.AircraftTypes);

        public AircraftType GetAircraftTypeDetails(int id)
            => Mapper.Map<DataAccessLayer.Models.AircraftType, AircraftType>(IsAircraftTypes(id));

        public void AddAircraftType(AircraftType aircraft)
            => DataSeends.AircraftTypes.Add(Mapper.Map<AircraftType, DataAccessLayer.Models.AircraftType>(aircraft));

        public void UpdateAircraftType(AircraftType type)
        {
            var planeType = IsAircraftTypes(type.Id);
            planeType.AircraftModel = type.AircraftModel;
            planeType.SeatsNumber = type.SeatsNumber;
            planeType.Carrying = type.Carrying;
        }

        public void RemoveAircraftType(int id) => DataSeends.AircraftTypes.Remove(IsAircraftTypes(id));

        public void RemoveAircraftsTypes() => DataSeends.AircraftTypes.Clear();
    }
}
