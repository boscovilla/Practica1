using System.Collections.Generic;

namespace Practica1.Models
{
    public class Artista
    {
        public int ArtistaId { get; set; }

        public string Nombre { get; set; }

        public ICollection<Album> AlbumLista { get; set; }
    }
}
