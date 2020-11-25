using System.Collections.Generic;
using System.Linq;

namespace SuperSimple.Core
{
    public static class Repositorio
    {
        static List<Categoria> categorias = new List<Categoria>();
        public static IEnumerable<Categoria> Categorias
            => categorias;
        public static Categoria GetCategoria(int id)
            => categorias.Find(c => c.Id == id);
        public static void AgregarCategoria(Categoria categoria)
            => categorias.Add(categoria);
        public static IEnumerable<Producto> Productos
            => categorias.SelectMany(c => c.Productos);
        public static Producto GetProducto(int id)
            => Productos.First(p => p.Id == id);
        public static IEnumerable<PrecioHistorico> GetPreciosDe(int id)
            => GetProducto(id).Precios;
    }
}