using Application.Servicio;
using Application.ViewModel;
using Application.ViewModel.PostAndEditViewModel;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV.Controllers
{
    public class GeneroController : Controller
    {
        private readonly ServicioGenero _servicioGenero;
        public GeneroController(ServicioGenero servicioGenero)
        {
            _servicioGenero = servicioGenero;
        }
        public IActionResult Create()
        {
           
           return View("Create", new GeneroPostAnEditViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(GeneroPostAnEditViewModel generoPost)
        {
            if(!ModelState.IsValid)
            {
                return View("Create", new GeneroPostAnEditViewModel());
            }
            await _servicioGenero.AddGenero(generoPost);  
            return RedirectToAction("Acciones", "Genero");
        }

        public async Task<ActionResult<IEnumerable<GenerosViewModel>>> Presentacion()
        {
            var modelo = await _servicioGenero.GetAllGeneros();

            return View(modelo);
        }

        public async Task<IActionResult> Editar(int Id)
        {

            return View("Create", await _servicioGenero.GetById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Editar(GeneroPostAnEditViewModel genero)
        {
            await _servicioGenero.EditProductora(genero);

            return RedirectToAction("Acciones", "Genero");
        }


        public async Task<IActionResult> Eliminar(int Id)
        {
            return View("Eliminar", await _servicioGenero.GetById(Id));
        }

        [HttpPost]

        public async Task<IActionResult> Eliminar(GenerosViewModel genero)
        {
            await _servicioGenero.DeleteProductora(genero);

            return RedirectToAction("Acciones", "Genero");
        }

        public async Task<ActionResult<GenerosViewModel>> Acciones()
        {
            var modelo = await _servicioGenero.GetAllGeneros();

            return View(modelo);

        }
    }
}
