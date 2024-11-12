using DriversServicesAPI.DTO;
using System.Text.Json;

namespace DriversServicesAPI.Services
{
    public class TravelService
    {

        
        private static int Id = 0;
        readonly IDataContext _dataContext;

        public TravelService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<TravelDTO> GetAllTravels()
        {
            var data = _dataContext.LoadData<TravelDTO>();

            if (data == null)
            {
                return new List<TravelDTO>();
            }

            return data;
        }

        public TravelDTO GetById(int id)
        {
            var data = _dataContext.LoadData<TravelDTO>();

            if (data == null)
            {
                return null;
            }
            return data.Find(c => c.Id == id);
        }

        public bool AddTravel(TravelDTO travel)
        {
            var data = _dataContext.LoadData<TravelDTO>();

            if (data == null)
            { return false; }
            travel.Id = Id++;
            data.Add(travel);
            _dataContext.SaveData(data);
            return true;
        }

        public bool DeleteTravel(int id)
        {
            var data = _dataContext.LoadData<TravelDTO>();


            if (data == null)
            {
                return false;
            }
            TravelDTO carToRemove = data.Find(c => c.Id == id);
            if (carToRemove != null)
            {
               data.Remove(carToRemove);
                _dataContext.SaveData(data);
                return true;
            }
            return false;
        }
        public bool UpdateTravel(TravelDTO car)
        {
            var data = _dataContext.LoadData<TravelDTO>();

            if (data == null)
            { return false; }

            TravelDTO TravelToUpdate = data.Find(c => c.Id == car.Id);
            if (TravelToUpdate != null)
            {
                TravelToUpdate.Source = car.Source;
                TravelToUpdate.Destination = car.Destination;
                TravelToUpdate.Date = car.Date;
                TravelToUpdate.Rate = car.Rate;
                TravelToUpdate.Travel = car.Travel;
                _dataContext.SaveData(data);
                return true;
            }

            return false;
        }


    }

}
