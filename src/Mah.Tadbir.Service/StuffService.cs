using Mah.Tadbir.Entity;
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
        private readonly DbContext _DbContext;
        private readonly IStuffRepository _SuffRepository;

        public StuffService(DbContext dbContext, IStuffRepository suffRepository)
        {
            this._DbContext = dbContext;
            this._SuffRepository = suffRepository;
        }
        public void Add(Stuff entity)
        {
            _SuffRepository.Add(entity);
            _DbContext.SaveChanges();
        }

        public void Delete(params Stuff[] entities)
        {
            _SuffRepository.Delete(entities);
            _DbContext.SaveChanges();
        }

        public async Task<IEnumerable<Stuff>> GetAllStuff()
        {
            return await _SuffRepository.GetData(new TrueSpecification<Stuff>()).ToListAsync();
        }

        public Task<Stuff> GetStuffById(int id)
        {
            return _SuffRepository.GetData(id);
        }

        public void Update(Stuff entity)
        {
            _SuffRepository.Update(entity);
            _DbContext.SaveChanges();
        }
    }
}
