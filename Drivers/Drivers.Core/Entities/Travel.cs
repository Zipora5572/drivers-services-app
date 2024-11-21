using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Drivers.Core.Entities
{
    public class Travel
    {
        public enum TravelType
        {
            DELIVERY,
            PASSENGERS
        }

        public enum RateType
        {
            HOURLY,
            METER,
            NIGHT
        }

        [JsonIgnore]
        public int Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public RateType Rate { get; set; }
        public TravelType TravelT { get; set; }
    }
}
