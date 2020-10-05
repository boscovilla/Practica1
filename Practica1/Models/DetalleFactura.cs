using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica1.Models
{
    public class DetalleFactura
    {

        public int DetFacturaId { get; set; }
        //fk
        public int FacturaId { get; set; }
        public Factura factura { get; set; }

        public ICollection<Factura> Factura { get; set; }

        //fk
        public int CancionId { get; set; }
        public Cancion Cancion { get; set; }

        public float PrecioUnidad { get; set; }

        public int Cantidad {get; set; }

       

    }
}
