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
        public IActionResult Detalle(int id)
        {
            var categoria = Repositorio.GetCategoria(id);
            if (categoria is null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult FormAlta() => View();

        [HttpPost]
        public IActionResult FormAlta(Categoria categoria)
        {
            Repositorio.AgregarCategoria(categoria);
            return View("Index", Repositorio.Categorias);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var categoria = Repositorio.GetCategoria(id);
            if (categoria is null)
            {
                return NotFound();
            }
            Repositorio.EliminarCategoria(categoria);
            return View("Index", Repositorio.Categorias);
        }

        [HttpGet]
        public IActionResult Modificar(int id)
        {
            var categoria = Repositorio.GetCategoria(id);
            if (categoria is null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Modificar(Categoria categoria)
        {
            Repositorio.ActualizarCategoria(categoria);
            return View("Index", Repositorio.Categorias);
        }
    }
}