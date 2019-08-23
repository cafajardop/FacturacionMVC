using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _01_Dal.Entidades;

namespace WebApiDigital.Controllers
{
    [RoutePrefix("buscarFactura")]
    public class buscarFacturaController : ApiController
    {

        [HttpPost]
        [Route("TraeFactura")]
        public IHttpActionResult TraeFacturaClientes(buscarFactura usr)
        {
            try
            {
                var resp = new _01_Dal.Dal.Metodos().BuscaFacturaClientes(usr);

                return Ok(resp);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}

