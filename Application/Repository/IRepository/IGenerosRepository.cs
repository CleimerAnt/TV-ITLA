using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.IRepository
{
    public interface IGenerosRepository : IRepository<Generos>
    {
        Task<Generos> Edit(Generos generos);
    }
}
