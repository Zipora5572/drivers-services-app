using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Drivers.Core.Entities
{
    public class Car
    {

        public enum ConditionCar
        {
            RENTED,
            AVAILABLE,
            BROKEN_DOWN,
            UNDER_REPAIR
        }

        [JsonIgnore]
        public int Id { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int NumPlaces { get; set; }
        public string PlateNumber { get; set; }
        public string Manufacturer { get; set; }
        public ConditionCar Condition { get; set; }
        public bool Status { get; set; }
        public int DriverId { get; set; }
    }
}
