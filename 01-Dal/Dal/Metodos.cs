using _01_Dal.Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _01_Dal.Dal
{
    public class Metodos
    {
        public IEnumerable<TipoDocumento> ConsultarTipo()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    return conn.Query<TipoDocumento>("spTipDocumento", new { }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Productos> ConsultarProducto()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    return conn.Query<Productos>("spListarProducto", new { }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Usuarios> InsertarUsu(Usuarios ObjUser)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    var p = new DynamicParameters();

                    p.Add("@TipDoc", ObjUser.TipDoc, dbType: DbType.Int16, direction: ParameterDirection.Input);
                    p.Add("@Num", ObjUser.NumDoc, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Nombres", ObjUser.Nombres, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Apellidos", ObjUser.Apellidos, dbType: DbType.String, direction: ParameterDirection.Input);

                    return db.Query<Usuarios>("spInsertarUsuario ", p, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo Inserta producto
        /// </summary>
        /// <param name="ObjUser"></param>
        /// <returns></returns>
        public IEnumerable<Productos> InsertarProducto(Productos ObjUser)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    var p = new DynamicParameters();

                    p.Add("@idCategoria", ObjUser.idCategoria, dbType: DbType.Int16, direction: ParameterDirection.Input);
                    p.Add("@Nombre", ObjUser.Nombre, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@descripcion", ObjUser.descripcion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@stock", ObjUser.stok, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add("@precio_compra", ObjUser.precio_compra, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add("@precio_venta", ObjUser.precio_venta, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    //p.Add("@fchVencimiento", ObjUser.fchVencimiento, dbType: DbType.DateTime, direction: ParameterDirection.Input);

                   return db.Query<Productos>("spInsertarProducto ", p, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Inserta Categoria
        /// </summary>
        /// <param name="ObjUser"></param>
        /// <returns></returns>

        public IEnumerable<categoria> InsertarCategoria(categoria ObjUser)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    var p = new DynamicParameters();
                    p.Add("@nombre_categoria", ObjUser.nombreCategoria, dbType: DbType.String, direction: ParameterDirection.Input);

                    return db.Query<categoria>("insertar_categoria", p, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Listar categoria
        /// </summary>
        /// <returns></returns>

        public IEnumerable<categoria> ConsultarCategoria()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    return conn.Query<categoria>("spListarCategoria", new { }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuarios> GetAllusr(string tipDoc, int numDoc)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                List<Usuarios> getResult = new List<Usuarios>();
                using (IDbConnection db = conn)
                {
                    var p = new DynamicParameters();

                    p.Add("@TipDoc", tipDoc, dbType: DbType.Int16, direction: ParameterDirection.Input);
                    p.Add("@Num", numDoc, dbType: DbType.String, direction: ParameterDirection.Input);

                    getResult = db.Query<Usuarios>("spConsultarUsuario ", p, commandType: CommandType.StoredProcedure).AsList();

                    if (getResult.Count == 0)
                    {
                        getResult = null;
                    }
                    return getResult;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Listar Productos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Lproductos> ListarProductos()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    return conn.Query<Lproductos>("spConsultarProductoPrecio", new { }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Trae usuarios ultima compra
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UltimaFchCompra> ListarUltimaCompra()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    return conn.Query<UltimaFchCompra>("spUltimaFechaCompra", new { }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Listar productos minimos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Lproductos> ListarProductosMin()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    return conn.Query<Lproductos>("spConsultarProductoMinimoPermitido", new { }, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ActualizarCategoria(categoria con)
        {
            bool resp = false;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    var p = new DynamicParameters();

                    p.Add("@idCategoria", con.idCategoria, dbType: DbType.Int16, direction: ParameterDirection.Input);
                    p.Add("@NombreCategoria", con.nombreCategoria, dbType: DbType.String, direction: ParameterDirection.Input);

                    var RS = db.Execute("spActualizarCategoria", p, commandType: CommandType.StoredProcedure);

                    if (RS == 1)
                    {
                        resp = true;
                    }
                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DelCatergoria(categoria con)
        {
            bool resp = false;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    var p = new DynamicParameters();
                    p.Add("@idCategoria", con.idCategoria, dbType: DbType.Int16, direction: ParameterDirection.Input);

                    var RS = db.Execute("spEliminarCategoria", p, commandType: CommandType.StoredProcedure);

                    if (RS == 1)
                    {
                        resp = true;
                    }
                    return resp;

                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public bool DelUsr(Usuarios con)
        {
            bool resp = false;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    var p = new DynamicParameters();

                    p.Add("@TipDoc", con.TipDoc, dbType: DbType.Int16, direction: ParameterDirection.Input);
                    p.Add("@NumDoc", con.NumDoc, dbType: DbType.String, direction: ParameterDirection.Input);

                    var RS = db.Execute("spElimnarUsuario", p, commandType: CommandType.StoredProcedure);

                    if (RS == 1)
                    {
                        resp = true;
                    }
                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<FacVentas> InsertarFac(FacVentas ObjUser)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    var p = new DynamicParameters();

                    p.Add("@tipDocumento", ObjUser.tipDocumento, dbType: DbType.Int16, direction: ParameterDirection.Input);
                    p.Add("@NumDocumento", ObjUser.NumDocumento, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Nombres", ObjUser.Nombres, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Apellidos", ObjUser.Apellidos, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@fchNacimiento", ObjUser.fchNacimiento, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add("@Direccion", ObjUser.Direccion, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@Telefono", ObjUser.Telefono, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add("@ProductoId", ObjUser.ProductoId, dbType: DbType.Int16, direction: ParameterDirection.Input);
                    p.Add("@Cantidad", ObjUser.Cantidad, dbType: DbType.Int16, direction: ParameterDirection.Input);
                    p.Add("@ValUnitario", ObjUser.ValUnitario, dbType: DbType.Int32, direction: ParameterDirection.Input);


                    return db.Query<FacVentas>("spGrabarVentaCab", p, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ClientesNoMayores> BuscarUsuarioNoMayores(ClientesNoMayores ObjUser)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    var p = new DynamicParameters();

                    p.Add("@fchInicioVenta", ObjUser.fchInicioVenta, dbType: DbType.Date, direction: ParameterDirection.Input);
                    p.Add("@fchFinVenta", ObjUser.fchFinVenta, dbType: DbType.Date, direction: ParameterDirection.Input);


                    return db.Query<ClientesNoMayores>("spConsultaClientesNoMayores", p, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<buscarFactura> BuscaFacturaClientes(buscarFactura ObjUser)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    var p = new DynamicParameters();

                    p.Add("@NroFacturaId", ObjUser.NroFacturaId, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    return db.Query<buscarFactura>("spConsultaClienteXFactura", p, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<vTotales> BuscarVentaTotales(vTotales ObjUser)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConCC"].ToString());
            try
            {
                using (IDbConnection db = conn)
                {
                    var p = new DynamicParameters();

                    p.Add("@FchaVenta", ObjUser.FchaVenta, dbType: DbType.Date, direction: ParameterDirection.Input);


                    return db.Query<vTotales>("spConsultaTotalVentas", p, commandType: CommandType.StoredProcedure).AsList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
