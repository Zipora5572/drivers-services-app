using Drivers.Core.Entities;
using Drivers.Core.Repositories;
using Drivers.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Service
{
    public class DriverService:IDriverService
    {
        private readonly IRepositoryManager _repositoryManager;

        public DriverService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public List<Driver> GetAllDrivers()
        {
            return _repositoryManager.Drivers.GetAll().ToList();
        }

        public Driver GetById(int id)
        {
            return _repositoryManager.Drivers.GetById(id);

        }

        public Driver AddDriver(Driver driver)
        {
            var addedDriver= _repositoryManager.Drivers.Add(driver); ;
            _repositoryManager.Save();
            return addedDriver;
        }

        public void DeleteDriver(Driver driver)
        {
             _repositoryManager.Drivers.Delete(driver);
            _repositoryManager.Save();
        }
        public Driver UpdateDriver(int id,Driver driver)
        {
            var updatedDriver = _repositoryManager.Drivers.Update( id,driver);
            _repositoryManager.Save();
            return updatedDriver;
            
        }


    }
}
