﻿using Drivers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers.Core.Repositories
{
    public interface ITravelRepository
    {
        List<Travel> GetAllTravels();
        Travel GetById(int id);
        bool AddTravel(Travel travel);
        bool DeleteTravel(int id);
        bool UpdateTravel(int id, Travel travel);
    }
}