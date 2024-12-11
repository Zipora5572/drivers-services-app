using Drivers.Core.Entities;
using Drivers.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IDataContext _context;
        public IUserRepository Users { get; }
        public ICarRepository Cars { get; }
        public IOrderRepository Orders { get; }
        public ITravelRepository Travels { get; }
        public IDriverRepository Drivers { get; }

        public RepositoryManager(IDataContext context, ICarRepository carRepository, IDriverRepository driverRepository, IOrderRepository orderRepository,IUserRepository userRepository,ITravelRepository travelRepository)
        { 
            _context = context;
           Users =userRepository;
            Cars =carRepository;
            Orders =orderRepository;
            Travels=travelRepository;
            Drivers=driverRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
