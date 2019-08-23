using _01_Dal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiDigital.Controllers
{
    [RoutePrefix("vTotales")]
    public class VentasTotalesController : ApiController
    {
        [HttpPost]
        [Route("VentaTot")]
        public IHttpActionResult VentaTotales(vTotales usr)
        {
            try
            {
                var resp = new _01_Dal.Dal.Metodos().BuscarVentaTotales(usr);

                return Ok(resp);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
