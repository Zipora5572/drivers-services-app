using DriversServicesAPI.DTO;

namespace DriversServicesAPI
{
    public interface IDataContext
    {
        
        public List<T> LoadData<T>();

        public bool SaveData<T>(List<T> data);
    }
}
