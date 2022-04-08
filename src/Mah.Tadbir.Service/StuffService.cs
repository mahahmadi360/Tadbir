using Mah.Tadbir.Entity;
using Mah.Tadbir.Interface.DAL;
using Mah.Tadbir.Interface.DAL.Repository;
using Mah.Tadbir.Interface.Services;
using Mah.Tadbir.Specification;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mah.Tadbir.Service
{
    public class StuffService : IStuffService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IStuffRepository _SuffRepository;

        public StuffService(IUnitOfWork unitOfWork, IStuffRepository suffRepository)
        {
            this._UnitOfWork = unitOfWork;
            this._SuffRepository = suffRepository;
        }
        public Task Add(Stuff entity)
        {
            _SuffRepository.Add(entity);
            return _UnitOfWork.SaveChangesAsync();
        }

        public Task Delete(params Stuff[] entities)
        {
            _SuffRepository.Delete(entities);
            return _UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Stuff>> GetAllStuff()
        {
            return await _SuffRepository.GetData(new TrueSpecification<Stuff>()).ToListAsync();
        }

        public Task<Stuff> GetStuffById(int id)
        {
            return _SuffRepository.GetData(id);
        }

        public Task Update(Stuff entity)
        {
            _SuffRepository.Update(entity);
            return _UnitOfWork.SaveChangesAsync();
        }
    }
}
