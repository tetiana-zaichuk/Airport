using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class AircraftTypeService : IService<AircraftType>
    {
        private readonly IRepository<DataAccessLayer.Models.AircraftType> _repository;

        public AircraftTypeService(IRepository<DataAccessLayer.Models.AircraftType> repository)
            => _repository = repository;

        public bool ValidationForeignId(AircraftType ob) => true;

        public AircraftType IsExist(int id)
            => Mapper.Map<DataAccessLayer.Models.AircraftType, AircraftType>(_repository.Get(id).FirstOrDefault());

        public DataAccessLayer.Models.AircraftType ConvertToModel(AircraftType aircraftType)
            => Mapper.Map<AircraftType, DataAccessLayer.Models.AircraftType>(aircraftType);

        public List<AircraftType> GetAll()
            => Mapper.Map<List<DataAccessLayer.Models.AircraftType>, List<AircraftType>>(_repository.Get());

        public AircraftType GetDetails(int id) => IsExist(id);

        public void Add(AircraftType aircraftType) => _repository.Create(ConvertToModel(aircraftType));

        public void Update(AircraftType aircraftType) => _repository.Update(ConvertToModel(aircraftType));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
