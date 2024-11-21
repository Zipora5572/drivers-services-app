using Drivers.Core.Entities;
using Drivers.Core.Repositories;
using Drivers.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Service
{
    public class TravelService:ITravelService
    {
        private readonly ITravelRepository _TravelRepository;

        public TravelService(ITravelRepository TravelRepository)
        {
            _TravelRepository = TravelRepository;
        }

        public List<Travel> GetAllTravels()
        {
            return _TravelRepository.GetAllTravels();
        }

        public Travel GetById(int id)
        {
            return _TravelRepository.GetById(id);

        }

        public bool AddTravel(Travel travel)
        {

            return _TravelRepository.AddTravel(travel);
        }

        public bool DeleteTravel(int id)
        {
            return _TravelRepository.DeleteTravel(id);
        }
        public bool UpdateTravel(int id, Travel travel)
        {

            return _TravelRepository.UpdateTravel(id, travel);
        }


    }
}
