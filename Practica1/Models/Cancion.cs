using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica1.Models
{
    public class Cancion
    {
        public int CancionId { get; set; }
        public string NombreId { get; set; }

        public int AlbumId { get; set; }
        public int GeneroId { get; set; }

        public Album Album { get; set; }
        public Genero Genero { get; set; }

        public ICollection<DetalleFactura> DetalleFacturaLista { get; set; }
    }
}
