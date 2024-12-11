using Drivers.Core.Entities;
using Drivers.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Data.Repositories
{
    public class CarRepository:Repository<Car>,ICarRepository
    {
        public CarRepository(DataContext context) : base(context)
        {
        }
    }
}
