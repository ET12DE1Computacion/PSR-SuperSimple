using SuperSimple.Core;
using System;
using System.Collections.Generic;

namespace SuperSimple.ViewModels
{
    public class VMProducto
    {
        public IEnumerable<Categoria> Categorias { get; set; }
        public Producto Producto { get; set; }
        public float PrecioNuevo { get; set; }
        public int? idCategoriaSeleccionado { get; set; }
        public VMProducto() => Producto = new Producto();
        public VMProducto(IEnumerable<Categoria> categorias) : this()
            => Categorias = categorias;
        public VMProducto(Producto producto)
        {
            Producto = producto;            
        }

        internal void Actualizar(Producto producto)
        {
            producto.Nombre = Producto.Nombre;
            if (producto.PrecioUnitario!=PrecioNuevo)
            {
                producto.cambiarPrecio(PrecioNuevo);
            }
            producto.Cantidad = Producto.Cantidad;
        }
    }
}