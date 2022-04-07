using Mah.Tadbir.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mah.Tadbir.Interface.Services
{
    public interface IStuffService
    {
        void Add(Stuff entity);
        void Update(Stuff entity);
        void Delete(params Stuff[] entities);

        Task<IEnumerable<Stuff>> GetAllStuff();

        Task<Stuff> GetStuffById(int id);
    }
}
