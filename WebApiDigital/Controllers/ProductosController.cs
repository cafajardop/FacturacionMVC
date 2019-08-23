using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _01_Dal.Entidades;

namespace WebApiDigital.Controllers
{
    [RoutePrefix("Productos")]
    public class ProductosController : ApiController
    {
        [HttpPost]
        [Route("InsrtProd")]
        public IHttpActionResult InsertaCat(Productos usr)
        {
            try
            {
                var resp = new _01_Dal.Dal.Metodos().InsertarProducto(usr);

                return Ok(resp);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("GetTipoProducto")]
        public IHttpActionResult GetTipoProducto()
        {
            try
            {
                var resp = new _01_Dal.Dal.Metodos().ConsultarProducto();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
