using Microsoft.AspNetCore.Mvc;
using SuperSimple.Core;

namespace SuperSimple.Controllers
{
    public class CategoriaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
            => View(Repositorio.Categorias);

        [HttpGet]
        public IActionResult Index(int id)
        {
            var categoria = Repositorio.GetCategoria(id);
            if (categoria is null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        
    }
}
