using DriversServicesAPI.DTO;
using System.Text.Json;

namespace DriversServicesAPI.Services
{
    public class TravelService
    {

        DataTravels _allTravels;

        public TravelService()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "DataTravels.json");
            string jsonString = File.ReadAllText(path);
            _allTravels = JsonSerializer.Deserialize<DataTravels>(jsonString);
        }
        public List<TravelDTO> GetAllTravels()
        {
            if (_allTravels == null)
            {
                return new List<TravelDTO>();
            }

            return _allTravels.dataTravels;
        }

        public TravelDTO GetById(int id)
        {
            if (_allTravels?.dataTravels == null)
            {
                return null;
            }
            return _allTravels.dataTravels.Find(c => c.Id == id);
        }

        public bool AddTravel(TravelDTO car)
        {
            if (_allTravels == null)
            { return false; }
            _allTravels.dataTravels.Add(car);
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "dataTravels.json");
            var data = JsonSerializer.Serialize(_allTravels);
            File.WriteAllText(path, data);
            return true;
        }

        public bool DeleteTravel(int id)
        {
            if (_allTravels?.dataTravels == null)
            {
                return false;
            }
            TravelDTO carToRemove = _allTravels.dataTravels.Find(c => c.Id == id);
            if (carToRemove != null)
            {
                _allTravels.dataTravels.Remove(carToRemove);
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "DataTravels.json");
                var data = JsonSerializer.Serialize(_allTravels);
                File.WriteAllText(path, data);
                return true;
            }
            return false;
        }
        public bool UpdateTravel(TravelDTO car)
        {
            if (_allTravels == null)
            { return false; }

            TravelDTO TravelToUpdate = _allTravels.dataTravels.Find(c => c.Id == car.Id);
            if (TravelToUpdate != null)
            {
                TravelToUpdate.Source = car.Source;
                TravelToUpdate.Destination = car.Destination;
                TravelToUpdate.Date = car.Date;
                TravelToUpdate.RateType = car.RateType;
                TravelToUpdate.TravelType = car.TravelType;
                string path = Path.Combine(AppContext.BaseDirectory, "Data", "dataTravels.json");
                var data = JsonSerializer.Serialize(_allTravels);
                File.WriteAllText(path, data);
                return true;
            }

            return false;
        }


    }

}
