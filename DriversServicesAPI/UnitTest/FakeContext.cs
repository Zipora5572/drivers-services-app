using DriversServicesAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UnitTest
{
    internal class FakeContext:IDataContext
    {
        private string GetPath<T>()
        {
            return Path.Combine(AppContext.BaseDirectory, "Data", $"{typeof(T).Name}.json");
        }

        public List<T> LoadData<T>()
        {
            try
            {
                string path = GetPath<T>();
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
            return true;
        }

    }
}
