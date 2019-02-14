using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Model = DataAccessLayer.Models;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class AircraftService : IService<Aircraft>
    {
        private readonly IRepository<Model.Aircraft> _repository;
        private readonly IRepository<Model.AircraftType> _repositoryType;

        public AircraftService(IRepository<Model.Aircraft> repository, IRepository<Model.AircraftType> repositoryType)
        {
            _repository = repository;
            _repositoryType = repositoryType;
        }

        public bool ValidationForeignId(Aircraft ob) =>_repositoryType.Get().FirstOrDefault(o=>o.Id==ob.AircraftTypeId)!=null;

        public Aircraft IsExist(int id) => Mapper.Map<Model.Aircraft, Aircraft>(_repository.Get(id).FirstOrDefault());

        public Model.Aircraft ConvertToModel(Aircraft aircraft) => Mapper.Map<Aircraft, Model.Aircraft>(aircraft);

        public List<Aircraft> GetAll() => Mapper.Map<List<Model.Aircraft>, List<Aircraft>>(_repository.Get());

        public Aircraft GetDetails(int id) => IsExist(id);

        public void Add(Aircraft aircraft) => _repository.Create(ConvertToModel(aircraft));

        public void Update(Aircraft aircraft) => _repository.Update(ConvertToModel(aircraft));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
