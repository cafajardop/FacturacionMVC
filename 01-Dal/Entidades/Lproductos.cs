using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Dal.Entidades
{
    public class Lproductos
    {
        public string NombreCategoria { get; set; }
        public string Nombre { get; set; }
        public decimal stock { get; set; }
        public decimal precio_compra { get; set; }
        public decimal precio_venta { get; set; }
    }
}
