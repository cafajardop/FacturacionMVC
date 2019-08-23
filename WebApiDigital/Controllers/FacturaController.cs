using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using _01_Dal.Entidades;

namespace WebApiDigital.Controllers

{
    [RoutePrefix("FacVentas")]
    public class FacturaController : ApiController
    {
        [HttpPost]
        [Route("IFac")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult InsertaFactura(FacVentas usr)
        {
            try
            {
                var resp = new _01_Dal.Dal.Metodos().InsertarFac(usr);

                return Ok(resp);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


    }
}
