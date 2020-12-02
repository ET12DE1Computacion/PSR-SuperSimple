using System.Collections.Generic;

namespace SuperSimple.Core
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float PrecioUnitario { get; private set; }
        public int Cantidad { get; set; }
        public List<PrecioHistorico> Precios { get; set; }
        public Producto() => Precios = new List<PrecioHistorico>();
        public void cambiarPrecio(float precio)
        {
            PrecioUnitario = precio;
            Precios.Add(new PrecioHistorico(precio));
        }
    }
}