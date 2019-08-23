using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _01_Dal.Entidades;

namespace WebApiDigital.Controllers
{
    [RoutePrefix("categoria")]
    public class CategoriaController : ApiController
    {
        [HttpPost]
        [Route("ICtg")]
        public IHttpActionResult InsertaCat(categoria usr)
        {
            try
            {
                var resp = new _01_Dal.Dal.Metodos().InsertarCategoria(usr);

                return Ok(resp);
            }

            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("GetCategoria")]
        public IHttpActionResult GetTipoCategoria()
        {
            try
            {
                var resp = new _01_Dal.Dal.Metodos().ConsultarCategoria();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("UCategoria")]
        public IHttpActionResult ActualizaCasoStore(categoria usr)
        {
            try
            {
                var resp = new _01_Dal.Dal.Metodos().ActualizarCategoria(usr);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("DelCategoria")]
        public IHttpActionResult EliminarCategoria(categoria usr)
        {
            try
            {
                var resp = new _01_Dal.Dal.Metodos().DelCatergoria(usr);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
