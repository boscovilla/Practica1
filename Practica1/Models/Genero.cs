using System.Collections.Generic;

namespace Practica1.Models
{
    public class Genero
    {

        public int GeneroId { get; set; }

        public string Nombre { get; set; }

        public ICollection<Cancion> Canciones { get; set; }

    }
}
