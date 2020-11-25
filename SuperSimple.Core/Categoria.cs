using System;
using System.Collections.Generic;

namespace SuperSimple.Core
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Producto> Productos { get; set; }
        public Categoria() => Productos = new List<Producto>();
        public void AgregarProducto(Producto producto)
            => Productos.Add(producto);
        public void EliminarProducto(Producto producto)
            => Productos.Remove(producto);
    }
}