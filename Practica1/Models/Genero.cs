using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica1.Models
{
    public class Genero
    {

        public int GeneroId { get; set; }

        public string Nombre { get; set; }

        public ICollection<Cancion> CancionLista { get; set; }

    }
}
