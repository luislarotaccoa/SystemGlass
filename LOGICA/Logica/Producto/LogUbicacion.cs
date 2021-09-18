using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VERTICAL.Modelos.Producto;

namespace LOGICA.Logica.Producto
{
    public class LogUbicacion : IRepositorio<ModelUbicacion>
    {
        Conexion C = new Conexion();
        public string Eliminar(int IdUbicacion, bool Estado)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColUbicacion.IdUbicacion.ToString(), IdUbicacion));
                listParam.Add(new Parametros(ColUbicacion.Estado.ToString(), Estado));
                C.EjecutarSP(ProcUbicacion.EliminarUbicacion.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Modificar(ModelUbicacion entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColUbicacion.IdUbicacion.ToString(), entity.IdUbicacion));
                listParam.Add(new Parametros(ColUbicacion.NomUbicacion.ToString(), entity.NomUbicacion));
                C.EjecutarSP(ProcUbicacion.ModificarUbicacion.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelUbicacion> Buscar(List<ModelUbicacion> list, string dato)
        {
            throw new NotImplementedException();
        }

        public string RegistrarCombinacion(ModelUbicacion entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColUbicacion.IdAlmacen.ToString(), entity.IdAlmacen));
                lst.Add(new Parametros(ColUbicacion.IdUbicacion.ToString(), entity.IdUbicacion));
                C.EjecutarSP("RegistrarAlmacenUbicacion", ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public ModelUbicacion Consulta(int IdUbicacion)
        {
            List<Parametros> listParam = new List<Parametros>();
            ModelUbicacion MUbicacion = null;
            try
            {
                listParam.Add(new Parametros(ColUbicacion.IdUbicacion.ToString(), IdUbicacion));
                var dt = C.Listado(ProcUbicacion.ConsultarUbicacion.ToString(), listParam).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var dtr = dt.Rows[0];
                    MUbicacion = new ModelUbicacion
                    {
                        IdUbicacion = Convert.ToInt32(dtr[ColUbicacion.IdUbicacion.ToString()]),
                        NomUbicacion = dtr[ColUbicacion.NomUbicacion.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dtr[ColUbicacion.Estado.ToString()])
                    };
                }
                return MUbicacion;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelUbicacion> Listar(object f1, object f2)
        {
            List<ModelUbicacion> list = new List<ModelUbicacion>();
            try
            {
                var dt = C.Listado(ProcUbicacion.ListarUbicacion.ToString(), null).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var dtr = dt.Rows[i];
                        var MUbicacion = new ModelUbicacion
                        {
                            IdUbicacion = Convert.ToInt32(dtr[ColUbicacion.IdUbicacion.ToString()]),
                            NomUbicacion = dtr[ColUbicacion.NomUbicacion.ToString()].ToString(),
                            Estado = Convert.ToBoolean(dtr[ColUbicacion.Estado.ToString()])
                        };
                        list.Add(MUbicacion);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Registrar(ModelUbicacion entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColUbicacion.IdUbicacion.ToString(), 0, SqlDbType.Int, ParameterDirection.Output, 11));
                listParam.Add(new Parametros(ColUbicacion.NomUbicacion.ToString(), entity.NomUbicacion));
                C.EjecutarSP(ProcUbicacion.RegistrarUbicacion.ToString(), ref listParam);
                string result = listParam[0].m_Valor.ToString();
                if (result == "1")
                {
                    entity.IdUbicacion = Convert.ToInt32(listParam[1].m_Valor);
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelUbicacion> Listar(int idAlmacen)
        {
            List<ModelUbicacion> lista = new List<ModelUbicacion>();
            try
            {
                var lisparametros = new List<Parametros>();
                lisparametros.Add(new Parametros(ColUbicacion.IdAlmacen.ToString(), idAlmacen));
                var dtd = C.Listado(ProcUbicacion.ListarAlmacenUbicacion.ToString(), lisparametros).Tables[0];
                for (int i = 0; i < dtd.Rows.Count; i++)
                {
                    var u = new ModelUbicacion
                    {
                        IdAlmacen = Convert.ToInt32(dtd.Rows[i][ColUbicacion.IdAlmacen.ToString()]),
                        Serie = dtd.Rows[i][ColUbicacion.Serie.ToString()].ToString(),
                        Nombre = dtd.Rows[i][ColUbicacion.Nombre.ToString()].ToString(),
                        Direccion = dtd.Rows[i][ColUbicacion.Direccion.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dtd.Rows[i][ColUbicacion.Estado.ToString()]),
                        IdUbicacion = Convert.ToInt32(dtd.Rows[i][ColUbicacion.IdUbicacion.ToString()]),
                        NomUbicacion = dtd.Rows[i][ColUbicacion.NomUbicacion.ToString()].ToString()
                    };
                    lista.Add(u);
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Eliminar(int idAlmacen, int idUbicacion)
        {
            throw new NotImplementedException();
        }
    }
}
