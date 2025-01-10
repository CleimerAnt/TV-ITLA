using Application.ViewModel;
using Application.ViewModel.PostAndEditViewModel;
using Azure.Core.GeoJson;
using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace Application.Servicio.RepositoryLINQ
{
    public class ServicioLINQ
    {
        private readonly ApplicationContext _Context;

        public ServicioLINQ(ApplicationContext context)
        {
            _Context = context;
        }

        public async Task<List<SeriesViewModel>> GetAllLINQ()
        {

            var modelo = from s in _Context.Series
                         join p in _Context.Productoras on s.ProductoraId equals p.Id
                         join g in _Context.Generos on s.GeneroId equals g.Id
                         join gSec in _Context.Generos on s.GeneroSecundarioId equals gSec.Id into gSecundario
                         from gSec in gSecundario.DefaultIfEmpty() 
                         select new SeriesViewModel
                         {
                             Id = s.Id,
                             ProductoraId = s.ProductoraId,
                             ProductoraNombre = p.NombreProductora,
                             GeneroId = s.GeneroId,
                             GeneroSecundario = gSec != null ? gSec.NombreGenero : "",
                             ImagenPortada = s.ImagenPortada,
                             ElanceVideo = s.EnlaceVideo,
                             NombreSerie = s.NombreSerie,
                             GeneroNombre = g.NombreGenero,
                         };



            return modelo.ToList();
        }



        public async Task<List<SeriesViewModel>> GetForName(string nombre)
        {
            var series = from s in _Context.Series
                         join p in _Context.Productoras
                         on s.ProductoraId equals p.Id
                         join g in _Context.Generos
                        on s.GeneroId equals g.Id
                         join gS in _Context.Generos
                         on s.GeneroSecundarioId equals gS.Id
                         where s.NombreSerie == nombre
                         select new SeriesViewModel
                         {
                             GeneroId = s.GeneroId,
                             NombreSerie = s.NombreSerie,
                             ImagenPortada = s.ImagenPortada,
                             ProductoraId = s.ProductoraId,
                             GeneroNombre = g.NombreGenero,
                             GeneroSecundario = gS.NombreGenero,
                             ProductoraNombre = p.NombreProductora,
                             Id = s.Id
                         };



            return await series.ToListAsync();
        }
        public async Task<List<SeriesViewModel>> GetForGeneroSecundario(int Id)
        {
            var series = from s in _Context.Series
                         join p in _Context.Productoras
                         on s.ProductoraId equals p.Id
                         join g in _Context.Generos
                         on s.GeneroId equals g.Id
                         join gS in _Context.Generos
                         on s.GeneroSecundarioId equals gS.Id
                         where s.GeneroSecundarioId == Id
                         select new SeriesViewModel
                         {
                             GeneroId = s.GeneroId,
                             NombreSerie = s.NombreSerie,
                             ImagenPortada = s.ImagenPortada,
                             ProductoraId = s.ProductoraId,
                             GeneroNombre = g.NombreGenero,
                             GeneroSecundario = gS.NombreGenero,
                             ProductoraNombre = p.NombreProductora,
                             Id = s.Id
                         };

            return await series.ToListAsync();
        }
        public async Task<List<SeriesViewModel>> GetForGenero(int Id)
        {
            var series = from s in _Context.Series
                         join p in _Context.Productoras
                         on s.ProductoraId equals p.Id
                         join g in _Context.Generos
                         on s.GeneroId equals g.Id
                         join gS in _Context.Generos
                         on s.GeneroSecundarioId equals gS.Id
                         where s.GeneroId == Id
                         select new SeriesViewModel
                         {
                             GeneroId = s.GeneroId,
                             NombreSerie = s.NombreSerie,
                             ImagenPortada = s.ImagenPortada,
                             ProductoraId = s.ProductoraId,
                             GeneroNombre = g.NombreGenero,
                             GeneroSecundario = gS.NombreGenero,
                             ProductoraNombre = p.NombreProductora,
                             Id = s.Id
                         };

            return await series.ToListAsync();
        }
        
        public async Task<List<SeriesViewModel>> GetForProductora(int Id)
        {
            var series = from s in _Context.Series
                         join p in _Context.Productoras
                         on s.ProductoraId equals p.Id
                         join g in _Context.Generos
                        on s.GeneroId equals g.Id
                         join gS in _Context.Generos
                         on s.GeneroSecundarioId equals gS.Id
                         where s.ProductoraId == Id
                         select new SeriesViewModel
                         {
                             GeneroId = s.GeneroId,
                             NombreSerie = s.NombreSerie,
                             ImagenPortada = s.ImagenPortada,
                             ProductoraId = s.ProductoraId,
                             GeneroNombre = g.NombreGenero,
                             GeneroSecundario = gS.NombreGenero,
                             ProductoraNombre = p.NombreProductora,
                             Id = s.Id
                         };

            return await series.ToListAsync();
        }

    }
}
