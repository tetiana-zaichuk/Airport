using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Model = DataAccessLayer.Models;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class AircraftTypeService : IService<AircraftType>
    {
        private readonly IRepository<Model.AircraftType> _repository;

        public AircraftTypeService(IRepository<Model.AircraftType> repository) => _repository = repository;

        public bool ValidationForeignId(AircraftType ob) => true;

        public AircraftType IsExist(int id) => Mapper.Map<Model.AircraftType, AircraftType>(_repository.Get(id).FirstOrDefault());

        public Model.AircraftType ConvertToModel(AircraftType aircraftType) => Mapper.Map<AircraftType, Model.AircraftType>(aircraftType);

        public List<AircraftType> GetAll() => Mapper.Map<List<Model.AircraftType>, List<AircraftType>>(_repository.Get());

        public AircraftType GetDetails(int id) => IsExist(id);

        public void Add(AircraftType aircraftType) => _repository.Create(ConvertToModel(aircraftType));

        public void Update(AircraftType aircraftType) => _repository.Update(ConvertToModel(aircraftType));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
