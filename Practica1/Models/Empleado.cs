using System.Collections.Generic;

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
        public ICollection<Cliente> Clientes { get; set; }
        public ICollection<Empleado> Empleados { get; set; }
    }
}
