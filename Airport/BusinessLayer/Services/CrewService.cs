using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class CrewService : IService<Crew>
    {
        private readonly IRepository<DataAccessLayer.Models.Crew> _repository;
        private readonly IRepository<DataAccessLayer.Models.Pilot> _repositoryPilot;
        private readonly IRepository<DataAccessLayer.Models.Stewardess> _repositoryStewardess;

        public CrewService(IRepository<DataAccessLayer.Models.Crew> repository, 
            IRepository<DataAccessLayer.Models.Pilot> rP, IRepository<DataAccessLayer.Models.Stewardess> rSt)
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

        public Crew IsExist(int id) => Mapper.Map<DataAccessLayer.Models.Crew, Crew>(_repository.Get(id).FirstOrDefault());

        public DataAccessLayer.Models.Crew ConvertToModel(Crew crew) => Mapper.Map<Crew, DataAccessLayer.Models.Crew>(crew);

        public List<Crew> GetAll() => Mapper.Map<List<DataAccessLayer.Models.Crew>, List<Crew>>(_repository.Get());

        public Crew GetDetails(int id) => IsExist(id);

        public void Add(Crew crew) => _repository.Create(ConvertToModel(crew));

        public void Update(Crew crew) => _repository.Update(ConvertToModel(crew));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
