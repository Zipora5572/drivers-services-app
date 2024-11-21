using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Drivers.Core.Entities
{
    public class Order
    {

        public enum PaymentType
        {
            CREDIT_CARD,
            CHECK,
            CASH
        }

        [JsonIgnore]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int DriverId { get; set; }
        public int TravelId { get; set; }
        public double Price { get; set; }
        public PaymentType Payment { get; set; }
        public int CarId { get; set; }
    }
}
