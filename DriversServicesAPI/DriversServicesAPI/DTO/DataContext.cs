using System.Text.Json;

namespace DriversServicesAPI.DTO
{
            builder.Services.AddScoped<OrderService>();
    public class DataContext: IDataContext
    {
       
        private string GetPath<T>()
        {
            return  Path.Combine(AppContext.BaseDirectory, "Data", $"{typeof(T).Name}.json");
        }

        public List<T> LoadData<T>()
        {
            try
            {            
               string path =GetPath<T>();
               string jsonString = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<List<T>>(jsonString);
                if (data == null)
                {
                    return null;
                }
                return data;
            }
            catch
            {

                return null;
            }
        }

        public bool SaveData<T>(List<T> data)
        {
            try
            {
                string path = GetPath<T>();
                string jsonString = JsonSerializer.Serialize<List<T>>(data);
                File.WriteAllText(path, jsonString);
                return true;
            }
            catch { return false; }
        }

    }
}
