using Application.Repository.IRepository;
using Application.Servicio.RepositoryLINQ;
using Application.ViewModel;
using Application.ViewModel.PostAndEditViewModel;
using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servicio
{
    public class ServicioSeries : ServicioLINQ
    {
        private readonly ISeriesRepository _seriesRepository;
        private readonly ApplicationContext _Context;
        
        public ServicioSeries(ApplicationContext context , ISeriesRepository seriesRepository)   : base(context)
        {
            _seriesRepository = seriesRepository;   
            _Context = context;
           
        }

        public async Task AddSerie(SeriesPostAndEditViewModel seriesPost)
        {
            Series modelo = new();
           
             
            modelo.NombreSerie = seriesPost.NombreSerie;
            modelo.GeneroId = seriesPost.GeneroId;
            modelo.ProductoraId = seriesPost.ProductoraID;
            modelo.ImagenPortada = seriesPost.ImagenPortada;
            modelo.EnlaceVideo = seriesPost.EnlaceVideo;
            modelo.GeneroSecundarioId = seriesPost.GeneroSecundarioId;
            await _seriesRepository.Add(modelo);

        }

        public async Task<List<SeriesViewModel>> GetAllSeries()
        {
            var ListaSeries = await _seriesRepository.GetAll();

            var modelo = ListaSeries.Select(Series => new SeriesViewModel
            {
                Id = Series.Id,
                NombreSerie = Series.NombreSerie,
                GeneroId = Series.GeneroId,
                ImagenPortada = Series.ImagenPortada,
                ElanceVideo = Series.EnlaceVideo,
                ProductoraId = Series.ProductoraId,

            });


            return modelo.ToList();
        }
        public async Task<SeriesPostAndEditViewModel> GetById(int id)
        {
           
            var series = await _seriesRepository.GetById(s => s.Id == id);
           
            SeriesPostAndEditViewModel modelo = new();
            modelo.Id = id;
            modelo.NombreSerie = series.NombreSerie;
            modelo.ImagenPortada = series.ImagenPortada;
            modelo.EnlaceVideo = series.EnlaceVideo;
            modelo.ProductoraID = series.ProductoraId;
            modelo.GeneroId = series.GeneroId;
            modelo.GeneroSecundarioId = series.GeneroSecundarioId;
            return modelo;
        }

      

    
       
        public async Task EditSerie(SeriesPostAndEditViewModel seriesEdit)
        {
            Series modelo = new();

            modelo.NombreSerie = seriesEdit.NombreSerie;
            modelo.EnlaceVideo = seriesEdit.EnlaceVideo;
            modelo.GeneroId = seriesEdit.GeneroId;
            modelo.ImagenPortada = seriesEdit.ImagenPortada;
            modelo.GeneroId = seriesEdit.GeneroId;
            modelo.ProductoraId = seriesEdit.ProductoraID;
            modelo.Id = seriesEdit.Id;
            modelo.GeneroSecundarioId = seriesEdit.GeneroSecundarioId;  
          

          await  _seriesRepository.Edit(modelo);
        }

        public async Task DeleteSerie(SeriesViewModel Serie)
        {
            Series modelo = new();

            modelo.NombreSerie = Serie.NombreSerie;
            modelo.EnlaceVideo = Serie.ElanceVideo;
            modelo.GeneroId = Serie.GeneroId;
            modelo.ImagenPortada = Serie.ImagenPortada;
            modelo.GeneroId = Serie.GeneroId;
            modelo.ProductoraId = Serie.ProductoraId;
            modelo.Id = Serie.Id;

            await _seriesRepository.Eliminar(modelo);
        }
    }
}
