using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mah.Tadbir.Interface.DAL
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
    }
}
