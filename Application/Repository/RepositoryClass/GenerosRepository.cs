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
    public class GenerosRepository : Repository<Generos>, IGenerosRepository
    {
        private readonly ApplicationContext _Context;
        public GenerosRepository(ApplicationContext context) : base(context)
        {
            _Context = context;
        }
        public async Task<Generos> Edit(Generos generos)
        {
            _Context.Update(generos);
            await _Context.SaveChangesAsync();

            return generos;
        }
    }
}
