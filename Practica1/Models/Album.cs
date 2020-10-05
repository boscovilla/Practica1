using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica1.Models
{
    public class Album
    {

        public int AlbumId { get; set; }
        public string Titulo  { get; set; }

        public int ArtistaId { get; set; }
        //Relacion con la tabla Artista, llave foranea
        public Artista Artista { get; set; }
        public ICollection<Cancion> CancionLista { get; set; }
    }
}
