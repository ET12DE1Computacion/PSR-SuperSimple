using SuperSimple.Core;
using System.Collections.Generic;

namespace SuperSimple.ViewModels
{
    // Esta clase es una contenedora 
    public class VMProducto
    {
        public IEnumerable<Categoria> Categorias { get; set; }
        public Producto Producto { get; set; }
        public float PrecioNuevo { get; set; }
        public int? IdCategoriaSeleccionado { get; set; }
        public VMProducto() => Producto = new Producto();
        public VMProducto(IEnumerable<Categoria> categorias) : this()
            => Categorias = categorias;
        public VMProducto(Producto producto)
        {
            Producto = producto;            
        }
        //Este método podria estar en otra casa que se suele llamar como "capa de servicio"
        //Ej: https://qastack.mx/programming/14887871/creating-a-service-layer-for-my-mvc-application
        internal void Actualizar(Producto producto)
        {
            producto.Nombre = Producto.Nombre;
            if (producto.PrecioUnitario!=PrecioNuevo)
            {
                producto.CambiarPrecio(PrecioNuevo);
            }
            producto.Cantidad = Producto.Cantidad;
        }
    }
}