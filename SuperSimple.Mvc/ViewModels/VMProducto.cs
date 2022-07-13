using Microsoft.AspNetCore.Mvc.Rendering;
using SuperSimple.Core;

namespace SuperSimple.Mvc.ViewModels;

// Esta clase es una contenedora 
public class VMProducto
{
    public SelectList CategoriasList { get; set; }
    public Producto Producto { get; set; }
    public float PrecioNuevo { get; set; }
    public int? IdCategoriaSeleccionado { get; set; }
    public VMProducto(){}
    public VMProducto(IEnumerable<Categoria> categorias, Producto? producto = null)
    {
        CategoriasList =
            new SelectList(items: categorias, dataValueField: nameof(Categoria.Id), dataTextField: nameof(Categoria.Nombre));
        if (producto is null)
        {
            Producto = new Producto();
            PrecioNuevo = 0;
        }
        else
        {
            Producto = producto;
            PrecioNuevo = producto.PrecioUnitario;
        }
    }

    //Este método podria estar en otra casa que se suele llamar como "capa de servicio"
    //Ej: https://qastack.mx/programming/14887871/creating-a-service-layer-for-my-mvc-application
    internal void Actualizar(Producto producto)
    {
        producto.Nombre = Producto.Nombre;
        if (producto.PrecioUnitario != PrecioNuevo)
        {
            producto.CambiarPrecio(PrecioNuevo);
        }
        producto.Cantidad = Producto.Cantidad;
    }
}