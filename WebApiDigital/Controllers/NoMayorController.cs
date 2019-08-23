using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _01_Dal.Entidades;

namespace WebApiDigital.Controllers
{
    [RoutePrefix("ClientesNoMayores")]
    public class NoMayorController : ApiController
    {
        [HttpPost]
        [Route("BMayores")]
        public IHttpActionResult ClientesNoMayores(ClientesNoMayores usr)
        {
            try
            {
                var resp = new _01_Dal.Dal.Metodos().BuscarUsuarioNoMayores(usr);

                return Ok(resp);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
