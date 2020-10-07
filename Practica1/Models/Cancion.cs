using System.Collections.Generic;

namespace Practica1.Models
{
    public class Cancion
    {
        public int CancionId { get; set; }
        public string Nombre { get; set; }
        public int AlbumId { get; set; }
        public int GeneroId { get; set; }
        public Album Album { get; set; }
        public Genero Genero { get; set; }
        public ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
