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
    public class ProductoraRepository : Repository<Productora>, IProductoraRepository
    {
        private readonly ApplicationContext _context;
        public ProductoraRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Productora> Edit(Productora productora)
        {
           _context.Update(productora);
            await _context.SaveChangesAsync();

            return productora;
        }
    }
}
