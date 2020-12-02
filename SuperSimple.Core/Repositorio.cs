using System.Collections.Generic;
using System.Linq;

namespace SuperSimple.Core
{
    public static class Repositorio
    {
        static int idCategoria = 1;
        static int idProducto = 1;
        static List<Categoria> categorias = new List<Categoria>();
        public static IEnumerable<Categoria> Categorias
            => categorias;
        public static Categoria GetCategoria(int id)
            => categorias.Find(c => c.Id == id);
        public static void AgregarCategoria(Categoria categoria)
        {
            categoria.Id = idCategoria++;
            categorias.Add(categoria);
        }

        public static void EliminarCategoria(Categoria categoria)
            => categorias.RemoveAll(c => c.Id == categoria.Id);
        public static void ActualizarCategoria(Categoria categoria)
        {
            var indice = categorias.FindIndex(c => c.Id == categoria.Id);
            if (indice!=-1)
            {
                categorias[indice] = categoria;
            }            
        }
        public static void AgregarProducto(Producto producto)
        {
            producto.Id = idProducto++;
        }
        public static IEnumerable<Producto> Productos
            => categorias.SelectMany(c => c.Productos);
        public static IEnumerable<Producto> ProductosDe(int idCategoria)
        {
            var categoria = GetCategoria(idCategoria);
            if (categoria is null)
            {
                return null;
            }
            return categoria.Productos;
        }
        public static Producto GetProducto(int id)
            => Productos.First(p => p.Id == id);
        public static IEnumerable<PrecioHistorico> GetPreciosDe(int id)
            => GetProducto(id).Precios;
        public static void EliminarProducto(Producto producto)
        {
            var categoria = categorias.Find(c => c.Productos.Exists(p => p.Id==producto.Id));
            categoria.Productos.RemoveAll(p => p.Id == producto.Id);
        }
    }
}