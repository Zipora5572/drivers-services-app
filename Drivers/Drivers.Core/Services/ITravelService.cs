using Drivers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Services
{
    public interface ITravelService
    {
        List<Travel> GetAllTravels();
        Travel GetById(int id);
        Travel AddTravel(Travel travel);
        void DeleteTravel(Travel travel);
        Travel UpdateTravel(int id,Travel travel);
    }
}
