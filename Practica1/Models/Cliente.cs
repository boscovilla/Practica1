using System.Collections.Generic;

namespace Practica1.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int SoporteId { get; set; }
        public Empleado Empleado { get; set; }
        public ICollection<Factura> Facturas { get; set; }
    }
}
