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
        private readonly IRepositoryManager _repositoryManager;

        public TravelService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public List<Travel> GetAllTravels()
        {
            return _repositoryManager.Travels.GetAll().ToList();
        }

        public Travel GetById(int id)
        {
            return _repositoryManager.Travels.GetById(id);

        }

        public Travel AddTravel(Travel travel)
        {
           var addedTravel= _repositoryManager.Travels.Add(travel);
            _repositoryManager.Save();
            return addedTravel;
        }

        public void DeleteTravel(Travel travel)
        {
             _repositoryManager.Travels.Delete(travel);
            _repositoryManager.Save();
        }
        public Travel UpdateTravel(int id,Travel travel)
        {
            var updatedTravel= _repositoryManager.Travels.Update(id,travel);
            _repositoryManager.Save();
            return updatedTravel;
        }


    }
}
