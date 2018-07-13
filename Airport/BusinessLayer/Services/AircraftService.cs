using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class AircraftService : IService<Aircraft>
    {
        private readonly IRepository<DataAccessLayer.Models.Aircraft> _repository;
        private readonly IRepository<DataAccessLayer.Models.AircraftType> _repositoryType;

        public AircraftService(IRepository<DataAccessLayer.Models.Aircraft> repository, IRepository<DataAccessLayer.Models.AircraftType> repositoryType)
        {
            _repository = repository;
            _repositoryType = repositoryType;
        }

        public bool ValidationForeignId(Aircraft ob)
            =>_repositoryType.Get().FirstOrDefault(o=>o.Id==ob.AircraftTypeId)!=null;

        public Aircraft IsExist(int id)
            => Mapper.Map<DataAccessLayer.Models.Aircraft, Aircraft>(_repository.Get(id).FirstOrDefault());

        public DataAccessLayer.Models.Aircraft ConvertToModel(Aircraft aircraft)
            => Mapper.Map<Aircraft, DataAccessLayer.Models.Aircraft>(aircraft);

        public List<Aircraft> GetAll()
            => Mapper.Map<List<DataAccessLayer.Models.Aircraft>, List<Aircraft>>(_repository.Get());

        public Aircraft GetDetails(int id) => IsExist(id);

        public void Add(Aircraft aircraft) => _repository.Create(ConvertToModel(aircraft));

        public void Update(Aircraft aircraft) => _repository.Update(ConvertToModel(aircraft));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
