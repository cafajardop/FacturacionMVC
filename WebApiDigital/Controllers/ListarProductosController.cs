using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiDigital.Controllers
{
    [RoutePrefix("Lproductos")]
    public class ListarProductosController : ApiController
    {
        [HttpGet]
        [Route("TraeProductos")]
        public IHttpActionResult ListaPro()
        {
            try
            {
                var resp = new _01_Dal.Dal.Metodos().ListarProductos();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("TraeProductosMin")]
        public IHttpActionResult ListaProMin()
        {
            try
            {
                var resp = new _01_Dal.Dal.Metodos().ListarProductosMin();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
