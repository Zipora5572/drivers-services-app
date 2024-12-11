using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drivers.Core.Repositories;
using Drivers.Core.Entities;

namespace Drivers.Data.Repositories
{
    public class DriverRepository:Repository<Driver>,IDriverRepository
    {

        public DriverRepository(DataContext context) : base(context)
        {
        }
    }
}
