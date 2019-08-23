using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _01_Dal.Entidades;

namespace WebApiDigital.Controllers
{
    [RoutePrefix("UltimaFchCompra")]
    public class UltimaCompraController : ApiController
    {
        [HttpGet]
        [Route("TraeUltimaCompra")]
        public IHttpActionResult ListaCompra()
        {
            try
            {
                var resp = new _01_Dal.Dal.Metodos().ListarUltimaCompra();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
