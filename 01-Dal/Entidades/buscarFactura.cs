using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Dal.Entidades
{
    public class buscarFactura
    {
        public int NroFacturaId { get; set; }
        public string FchaVenta { get; set; }
        public string numDocumento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int Edad { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public DateTime fchInicioVenta { get; set; }
        public DateTime fchFinVenta { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int ValUnitario { get; set; }
        public int Total { get; set; }

    }
}
