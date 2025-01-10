using Application.Repository.IRepository;
using Application.Repository.Repository;
using Application.ViewModel;
using Application.ViewModel.PostAndEditViewModel;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servicio
{
    public class ServicioProductora
    {
        private readonly IProductoraRepository _productoraRepository;

        public ServicioProductora(IProductoraRepository productoraRepository)
        {
            _productoraRepository = productoraRepository;
        }

        public async Task AddProductora(ProductoraPostAnEditViewModel productoraPost)
        {
            Productora modelo = new();

            modelo.NombreProductora = productoraPost.NombreProductora;

            await _productoraRepository.Add(modelo);

        }

        public async Task<List<ProductoraViewModel>> GetAllProductoras()
        {
            var ListaProductoras = await _productoraRepository.GetAll();

            var modelo = ListaProductoras.Select(Productora => new ProductoraViewModel
            {
                Id = Productora.Id,
                NombreProductora = Productora.NombreProductora
            });

            return modelo.ToList();
        }

        public async Task<ProductoraPostAnEditViewModel> GetById(int id)
        {

            var productora = await _productoraRepository.GetById(p => p.Id == id);

            ProductoraPostAnEditViewModel modelo = new();
            modelo.Id = productora.Id;
            modelo.NombreProductora = productora.NombreProductora;

            return modelo;
        }

        public async Task EditProductora(ProductoraPostAnEditViewModel productoraEdit)
        {
            Productora modelo = new();
            modelo.Id = productoraEdit.Id;
            modelo.NombreProductora = productoraEdit.NombreProductora;


            await _productoraRepository.Edit(modelo);
        }

        public async Task DeleteProductora(ProductoraViewModel productora)
        {
            Productora modelo = new();
            modelo.Id = productora.Id;
            modelo.NombreProductora = productora.NombreProductora;
            
            await _productoraRepository.Eliminar(modelo);
        }
    }
 }
