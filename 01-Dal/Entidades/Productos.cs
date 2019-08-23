using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Dal.Entidades
{
    public class Productos
    {
        public int idCategoria { get; set; }
        public string Nombre { get; set; }
        public string descripcion { get; set; }
        public decimal stok { get; set; }
        public decimal precio_compra { get; set; }
        public decimal precio_venta { get; set; }
        public int ProductoId { get; set; }
        public string DesNombreProducto { get; set; }
        public int idRpt { get; set; }
        //public DateTime fchVencimiento { get; set; }        
    }
}
