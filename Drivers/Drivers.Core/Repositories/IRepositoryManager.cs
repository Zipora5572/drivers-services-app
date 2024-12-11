using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Repositories
{
    public interface IRepositoryManager
    {
        IUserRepository Users { get; }
        IDriverRepository Drivers { get; }
        ICarRepository Cars { get; }
        ITravelRepository Travels { get; }
        IOrderRepository Orders { get; }

        void Save();
    }
}
