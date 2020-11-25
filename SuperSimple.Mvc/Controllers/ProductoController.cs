using Microsoft.AspNetCore.Mvc;
using SuperSimple.Core;

namespace SuperSimple.Controllers
{
    public class ProductoController: Controller
    {
        [HttpGet]
        public IActionResult Index()
            => View(Repositorio.Productos);
        [HttpGet("{id}:int")]
        public IActionResult Index(int id)
        {
            var producto = Repositorio.GetProducto(id);
            if (producto is null)
            {
                return NotFound();
            }
            return View(producto);
        }
    }
}