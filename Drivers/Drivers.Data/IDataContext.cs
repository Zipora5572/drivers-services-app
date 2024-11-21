using Drivers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Data
{
    public interface IDataContext
    {

        public List<Car> Cars { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<Order> Orders { get; set; }
        public List<Travel> Travels { get; set; }
        public List<User> Users { get; set; }

        public List<T> LoadData<T>();

        public bool SaveData<T>(List<T> data);
    }
}
