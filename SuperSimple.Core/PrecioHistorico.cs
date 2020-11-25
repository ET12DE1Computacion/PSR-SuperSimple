using System;

namespace SuperSimple.Core
{
    public class PrecioHistorico
    {
        public float PrecioUnitario { get; set; }
        public DateTime FechaHora { get; set; }
        public PrecioHistorico(float precioUnitario)
        {
            PrecioUnitario = precioUnitario;
            FechaHora = DateTime.Now;
        }
    }
}
