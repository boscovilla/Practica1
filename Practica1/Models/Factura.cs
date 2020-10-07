using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Practica1.Models
{
    public class Factura
    {
        public int FacturaId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaFactura { get; set; }
        public float Total { get; set; }
        public ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
