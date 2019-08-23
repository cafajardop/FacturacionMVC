using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Dal.Entidades
{
    public class UltimaFchCompra
    {
        public string numDocumento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int Dias { get; set; }
        public DateTime UltimaFechaCompra { get; set; }
    }
}
