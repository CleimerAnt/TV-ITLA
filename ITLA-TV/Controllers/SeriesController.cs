using Application.Repository.IRepository;
using Application.Repository.Repository;
using Application.Servicio;
using Application.ViewModel;
using Application.ViewModel.PostAndEditViewModel;
using Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ServicioSeries _servicioSeries;
        private readonly ServicioGenero _servicioGeneros;
        private readonly ServicioProductora _servicioProductora;
        public SeriesController(ServicioSeries servicioSeries, ServicioGenero servicioGenero, ServicioProductora servicioProductora)
        {
            _servicioSeries = servicioSeries;
            _servicioGeneros = servicioGenero;
            _servicioProductora = servicioProductora;
        }
        public async Task<ActionResult<List<GenerosViewModel>>> Index()
        {

            List<GenerosViewModel> generoList = await _servicioGeneros.GetAllGeneros();
            List<ProductoraViewModel> productoraList = await _servicioProductora.GetAllProductoras();
            
            ViewBag.productoras = productoraList;
            ViewBag.generos = generoList;

            var modelo = await _servicioSeries.GetAllLINQ();
            
            
            return View(modelo);

        }

        [HttpPost]
        public async Task<IActionResult> Index( string series, int genero, int productora)
        {
            

            var SerieBusqueda = await _servicioSeries.GetForName(series);

            List<GenerosViewModel> generoList = await _servicioGeneros.GetAllGeneros();

            List<ProductoraViewModel> productoraList = await _servicioProductora.GetAllProductoras();

            ViewBag.productoras = productoraList;
            ViewBag.generos = generoList;
            ViewBag.serie = SerieBusqueda;

            var productoraSelect = await _servicioSeries.GetForProductora(productora);
            var generoSelect = await _servicioSeries.GetForGenero(genero);
            
            if(generoSelect.Count == 0)
            {
                generoSelect = await _servicioSeries.GetForGeneroSecundario(genero);
            }

            ViewBag.mandar = 0;

            ViewBag.mandar = SerieBusqueda.Count != 0 ? SerieBusqueda :
                  productoraSelect.Count != 0 ? productoraSelect :
                  generoSelect.Count != 0 ? generoSelect :
                  null;

            var modelo = await _servicioSeries.GetAllLINQ();
            return View(modelo);

        }
        public async Task<IActionResult> Eliminar(int Id)
        {
            return View("Eliminar", await _servicioSeries.GetById(Id));

        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(SeriesViewModel serie)
        {
            var modelo =  _servicioSeries.DeleteSerie(serie);

            return RedirectToAction("Acciones", "Series");
        }
        public async Task<IActionResult> Editar(int Id)
        {
            List<GenerosViewModel> generoList = await _servicioGeneros.GetAllGeneros();
            List<ProductoraViewModel> productoraList = await _servicioProductora.GetAllProductoras();

            ViewBag.productoras = productoraList;
            ViewBag.generos = generoList;

            return View("Create", await _servicioSeries.GetById(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Editar(SeriesPostAndEditViewModel series)
        {
            await _servicioSeries.EditSerie(series);
            return RedirectToAction("Index", "Series");
        }

        public async Task<IActionResult> Create()
        {
           

            List<GenerosViewModel> generoList = await _servicioGeneros.GetAllGeneros();
            List<ProductoraViewModel> productoraList = await _servicioProductora.GetAllProductoras();
           

            ViewBag.productoras = productoraList;
            ViewBag.generos = generoList;

            return View("Create", new SeriesPostAndEditViewModel());
         
        }

        [HttpPost]
        public async Task<IActionResult> Create(SeriesPostAndEditViewModel seriesPost)
        {
           

            if (!ModelState.IsValid)
            {
                List<GenerosViewModel> generoList = await _servicioGeneros.GetAllGeneros();
                List<ProductoraViewModel> productoraList = await _servicioProductora.GetAllProductoras();



                ViewBag.productoras = productoraList;
                ViewBag.generos = generoList;

                return View("Create", seriesPost);
            }
            await _servicioSeries.AddSerie(seriesPost);
            return RedirectToAction("Acciones", "Series");
        }

        public async Task<ActionResult<SeriesPostAndEditViewModel>> VerSerie(int Id)
        {
            var modelo = new SeriesPostAndEditViewModel();
            if(Id == 0)
            {
            
                modelo.NombreSerie = "Black Mirror";
                modelo.EnlaceVideo = "https://www.youtube.com/embed/V0XOApF5nLU?si=JDwXNiieLqYNApBX";
            }
            else
            {
                modelo = await _servicioSeries.GetById(Id);
            }

            return View(modelo);
        }

        public async Task<ActionResult<SeriesPostAndEditViewModel>> Acciones()
        {
            var modelo = await _servicioSeries.GetAllSeries();

            return View(modelo);
        }

    }
}


