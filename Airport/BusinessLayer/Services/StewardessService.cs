using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using Shared.DTO;

namespace BusinessLayer.Services
{
    public class StewardessService : IService<Stewardess>
    {
        private readonly IRepository<DataAccessLayer.Models.Stewardess> _repository;

        public StewardessService(IRepository<DataAccessLayer.Models.Stewardess> repository)
            => _repository = repository;

        public bool ValidationForeignId(Stewardess ob) => true;

        public Stewardess IsExist(int id)
            => Mapper.Map<DataAccessLayer.Models.Stewardess, Stewardess>(_repository.Get(id).FirstOrDefault());

        public DataAccessLayer.Models.Stewardess ConvertToModel(Stewardess stewardess)
            => Mapper.Map<Stewardess, DataAccessLayer.Models.Stewardess>(stewardess);

        public List<Stewardess> GetAll()
            => Mapper.Map<List<DataAccessLayer.Models.Stewardess>, List<Stewardess>>(_repository.Get());

        public Stewardess GetDetails(int id) => IsExist(id);

        public void Add(Stewardess stewardess) => _repository.Create(ConvertToModel(stewardess));

        public void Update(Stewardess stewardess) => _repository.Update(ConvertToModel(stewardess));

        public void Remove(int id) => _repository.Delete(id);

        public void RemoveAll() => _repository.Delete();
    }
}
