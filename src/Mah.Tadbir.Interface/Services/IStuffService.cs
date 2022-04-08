using Mah.Tadbir.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mah.Tadbir.Interface.Services
{
    public interface IStuffService
    {
        Task Add(Stuff entity);
        Task Update(Stuff entity);
        Task Delete(params Stuff[] entities);

        Task<IEnumerable<Stuff>> GetAllStuff();

        Task<Stuff> GetStuffById(int id);
    }
}
