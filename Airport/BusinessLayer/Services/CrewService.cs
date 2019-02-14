using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Model = DataAccessLayer.Models;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class CrewService : IService<Crew>
    {
        private readonly IRepository<Model.Crew> _repository;
        private readonly IRepository<Model.Pilot> _repositoryPilot;
        private readonly IRepository<Model.Stewardess> _repositoryStewardess;

        public CrewService(IRepository<Model.Crew> repository, IRepository<Model.Pilot> rP, IRepository<Model.Stewardess> rSt)
        {
            _repository = repository;
            _repositoryPilot = rP;
            _repositoryStewardess = rSt;
        }

        public bool ValidationForeignId(Crew ob)
        {
            foreach (var st in ob.StewardessesId)
            {
                if (_repositoryStewardess.Get(st).FirstOrDefault() == null) return false;
            }
            return _repositoryPilot.Get().FirstOrDefault(o => o.Id == ob.PilotId) != null;
        }

        public Crew IsExist(int id) => Mapper.Map<Model.Crew, Crew>(_repository.Get(id).FirstOrDefault());

        public Model.Crew ConvertToModel(Crew crew) => Mapper.Map<Crew, Model.Crew>(crew);

        public List<Crew> GetAll() => Mapper.Map<List<Model.Crew>, List<Crew>>(_repository.Get());

        public Crew GetDetails(int id) => IsExist(id);

        public void Add(Crew crew) => _repository.Create(ConvertToModel(crew));

        public void Update(Crew crew) => _repository.Update(ConvertToModel(crew));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
