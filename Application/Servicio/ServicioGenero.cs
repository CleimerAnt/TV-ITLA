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
    public class ServicioGenero
    {
        private readonly IGenerosRepository _generoRepository;

        public ServicioGenero(IGenerosRepository generosRepository)
        {
            _generoRepository = generosRepository;  
        }

        public async Task AddGenero(GeneroPostAnEditViewModel generoPost)
        {
            Generos modelo = new();
        
            modelo.NombreGenero = generoPost.NombreGenero;

         await _generoRepository.Add(modelo);

        }
       public async Task<List<GenerosViewModel>> GetAllGeneros()
        {
             var ListaGenero = await _generoRepository.GetAll();

            var modelo = ListaGenero.Select(Generos => new GenerosViewModel
            {
                Id = Generos.Id,
                NombreGenero = Generos.NombreGenero,
            });

            return modelo.ToList();

        }

       
        public async Task<GeneroPostAnEditViewModel> GetById(int id)
        {

            var Genero = await _generoRepository.GetById(p => p.Id == id);

            GeneroPostAnEditViewModel modelo = new();
            modelo.Id = Genero.Id;
            modelo.NombreGenero = Genero.NombreGenero;

            return modelo;
        }

        public async Task EditProductora(GeneroPostAnEditViewModel GeneroEdit)
        {
            Generos modelo = new();
            modelo.Id = GeneroEdit.Id;
            modelo.NombreGenero = GeneroEdit.NombreGenero;


            await _generoRepository.Edit(modelo);
        }

        public async Task DeleteProductora(GenerosViewModel genero)
        {
            Generos modelo = new();
            modelo.Id = genero.Id;
            modelo.NombreGenero = genero.NombreGenero;

            await _generoRepository.Eliminar(modelo);
        }
    }
}
