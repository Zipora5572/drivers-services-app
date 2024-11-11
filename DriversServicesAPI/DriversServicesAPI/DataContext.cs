using DriversServicesAPI.DTO;
using System.Text.Json;

namespace DriversServicesAPI
{
    public class DataContext
    {
        public DataCars Cars { get; set; }

        public DataDrivers Drivers { get; set; }

        public DataOrders Orders { get; set; }   

        public DataTravels Travels { get; set; }

        public DataUsers Users { get; set; }

        public DataContext()
        {
            string path, jsonString;
            path = Path.Combine(AppContext.BaseDirectory, "Data", "DataCars.json");
            jsonString = File.ReadAllText(path);
            Cars = JsonSerializer.Deserialize<DataCars>(jsonString);

            path = Path.Combine(AppContext.BaseDirectory, "Data", "DataDrivers.json");
            jsonString = File.ReadAllText(path);
            Drivers = JsonSerializer.Deserialize<DataDrivers>(jsonString);

            path = Path.Combine(AppContext.BaseDirectory, "Data", "DataOrders.json");
            jsonString = File.ReadAllText(path);
            Cars = JsonSerializer.Deserialize<DataCars>(jsonString);

            path = Path.Combine(AppContext.BaseDirectory, "Data", "DataTravels.json");
            jsonString = File.ReadAllText(path);
            Travels = JsonSerializer.Deserialize<DataTravels>(jsonString);

            path = Path.Combine(AppContext.BaseDirectory, "Data", "DataCars.json");
            jsonString = File.ReadAllText(path);
            Cars = JsonSerializer.Deserialize<DataCars>(jsonString);

            path = Path.Combine(AppContext.BaseDirectory, "Data", "DataUsers.json");
            jsonString = File.ReadAllText(path);
            Users = JsonSerializer.Deserialize<DataUsers>(jsonString);
        }
    }
}
