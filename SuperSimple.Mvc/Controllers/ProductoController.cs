using Microsoft.AspNetCore.Mvc;
using SuperSimple.Core;
using SuperSimple.ViewModels;

namespace SuperSimple.Controllers
{
    public class ProductoController: Controller
    {
        public IActionResult Index()
            => View(Repositorio.Productos);
        
        public IActionResult Detalle(int id)
        {
            var producto = Repositorio.GetProducto(id);
            if (producto is null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpGet]
        public IActionResult FormAlta(int? idCategoria)
        {
            var vmProducto = new VMProducto(Repositorio.Categorias);
            vmProducto.idCategoriaSeleccionado = idCategoria;
            return View(vmProducto);
        }

        [HttpPost]
        public IActionResult FormAlta(VMProducto vMProducto)
        {
            if (Validar(vMProducto))
            {
                var categoria = Repositorio.GetCategoria(vMProducto.idCategoriaSeleccionado.Value);
                vMProducto.Producto.cambiarPrecio(vMProducto.PrecioNuevo);
                categoria.AgregarProducto(vMProducto.Producto);
                Repositorio.AgregarProducto(vMProducto.Producto);
            }
            return View("Index", Repositorio.Productos);
        }
        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var producto = Repositorio.GetProducto(id);
            if (producto is null)
            {
                return NotFound();
            }
            Repositorio.EliminarProducto(producto);
            return View("Index", Repositorio.Categorias);
        }

        [HttpGet]
        public IActionResult Modificar(int id)
        {
            var producto = Repositorio.GetProducto(id);
            if (producto is null)
            {
                return NotFound();
            }
            var vmProducto = new VMProducto(producto);
            vmProducto.Categorias = Repositorio.Categorias;
            vmProducto.PrecioNuevo = producto.PrecioUnitario;
            return View(vmProducto);
        }

        [HttpPost]
        public IActionResult Modificar(VMProducto vmProducto)
        {
            if (Validar(vmProducto))
            {
                var producto = Repositorio.GetProducto(vmProducto.Producto.Id);
                if (producto is null)
                {
                    return NotFound();
                }
                vmProducto.Actualizar(producto);
            }
            return View("Index", Repositorio.Productos);
        }
        private bool Validar(VMProducto vMProducto)
            => (vMProducto.idCategoriaSeleccionado.HasValue) || (vMProducto.PrecioNuevo > 0);
    }
}