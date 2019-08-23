using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Dal.Entidades
{
    public class FacVentas
    {
        public int tipDocumento { get; set; }
        public string NumDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime fchNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int ValUnitario { get; set; }
        public int Id { get; set; }
    }
}
