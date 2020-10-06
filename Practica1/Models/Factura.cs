using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        public int DetalleFacturaId { get; set; }
        public DetalleFactura DetalleFactura { get; set; }
        


    }
}
