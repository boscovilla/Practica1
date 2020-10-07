using System.Collections.Generic;

namespace Practica1.Models
{
    public class DetalleFactura
    {
        public int DetalleFacturaId { get; set; }
        //fk
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }
        //fk
        public int CancionId { get; set; }
        public Cancion Cancion { get; set; }
        public float PrecioUnidad { get; set; }
        public int Cantidad { get; set; }
    }
}
