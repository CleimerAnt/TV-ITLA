using Application.Repository.IRepository;
using Application.Servicio;
using Application.ViewModel;
using Application.ViewModel.PostAndEditViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ITLA_TV.Controllers
{
    public class ProductoraController : Controller
    {
        private readonly ServicioProductora _servicioProductora;
        public ProductoraController(ServicioProductora servicioProductora)
        {
            _servicioProductora = servicioProductora;   
        }
        public IActionResult Create()
        {
            return View("Create", new ProductoraPostAnEditViewModel());
        }


        [HttpPost]
        public async Task <IActionResult> Create(ProductoraPostAnEditViewModel productoraPost)
        {

            if (!ModelState.IsValid)
            {
                return View("Create", new ProductoraPostAnEditViewModel());
            }
            await _servicioProductora.AddProductora(productoraPost);

            return RedirectToAction("Acciones", "Productora");
        }

        public async Task<ActionResult<IEnumerable<ProductoraViewModel>>> Presentacion()
        {
            var modelo = await _servicioProductora.GetAllProductoras();

            return View(modelo);
        }

        public async Task<IActionResult> Editar(int Id)
        {

            return View("Create", await _servicioProductora.GetById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProductoraPostAnEditViewModel productora)
        {
            await _servicioProductora.EditProductora(productora);

            return RedirectToAction("Index", "Series");
        }

        public async Task<IActionResult> Eliminar(int Id)
        {
            return View("Eliminar", await _servicioProductora.GetById(Id));
        }

        [HttpPost]

        public async Task<IActionResult> Eliminar(ProductoraViewModel productora)
        {
          await  _servicioProductora.DeleteProductora(productora); 
            
            return RedirectToAction("Acciones", "Productora");  
        }

        public async Task<ActionResult<ProductoraViewModel>> Acciones()
        {
            var modelo = await _servicioProductora.GetAllProductoras();

            return View(modelo);
        }
    }
}
