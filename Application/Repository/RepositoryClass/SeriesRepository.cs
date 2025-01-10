using Application.Repository.IRepository;
using Database;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Repository
{
    public class SeriesRepository : Repository<Series>, ISeriesRepository
    {
        private readonly ApplicationContext _Context;
        public SeriesRepository(ApplicationContext context) : base(context)
        {
            _Context = context;
        }
        public async Task<Series> Edit(Series series)
        {
            _Context.Update(series);
            await _Context.SaveChangesAsync();

            return series;
        }
    }
}
