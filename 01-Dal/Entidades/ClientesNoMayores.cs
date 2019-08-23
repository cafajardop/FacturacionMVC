using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Dal.Entidades
{
    public class ClientesNoMayores
    {
        public int NroFacturaId { get; set; }
        public DateTime FchaVenta { get; set; }
        public string numDocumento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int Edad { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public DateTime fchInicioVenta { get; set; }
        public DateTime fchFinVenta { get; set; }
    }
}
