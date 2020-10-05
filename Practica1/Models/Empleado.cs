using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica1.Models
{
    public class Empleado
    {

        public int EmpleadoId { get; set; }
        
        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string Cargo { get; set; }

        public string JefeDirecto { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public ICollection<Cliente> ClienteLista { get; set; }
        public ICollection<Empleado> EmpleadoLista { get; set; }
    }
}
