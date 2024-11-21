using Drivers.Core.Entities;
using Drivers.Core.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Data.Repositories
{
    public class TravelRepository:ITravelRepository
    {

        private static int Id = 0;
        readonly IDataContext _dataContext;

        public TravelRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<Travel> GetAllTravels()
        {
            var data = _dataContext.Travels;

            if (data == null)
            {
                return new List<Travel>();
            }

            return data;
        }

        public Travel GetById(int id)
        {
            var data = _dataContext.Travels;

            if (data == null)
            {
                return null;
            }
            return data.Find(c => c.Id == id);
        }

        public bool AddTravel(Travel travel)
        {
            var data = _dataContext.Travels;

            if (data == null)
            { return false; }
            travel.Id = Id++;
            data.Add(travel);
            _dataContext.SaveData(data);
            return true;
        }

        public bool DeleteTravel(int id)
        {
            var data = _dataContext.Travels;


            if (data == null)
            {
                return false;
            }
            Travel carToRemove = data.Find(c => c.Id == id);
            if (carToRemove != null)
            {
                data.Remove(carToRemove);
                _dataContext.SaveData(data);
                return true;
            }
            return false;
        }
        public bool UpdateTravel(int id, Travel car)
        {
            var data = _dataContext.Travels;

            if (data == null)
            { return false; }

            Travel TravelToUpdate = data.Find(c => c.Id == id);
            if (TravelToUpdate != null)
            {
                TravelToUpdate.Source = car.Source;
                TravelToUpdate.Destination = car.Destination;
                TravelToUpdate.Date = car.Date;
                TravelToUpdate.Rate = car.Rate;
                TravelToUpdate.TravelT = car.TravelT;
                _dataContext.SaveData(data);
                return true;
            }

            return false;
        }
    }
}
