﻿using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.IRepository
{
    public interface ISeriesRepository : IRepository<Series>    
    {
        Task<Series> Edit(Series series);
    }
}
