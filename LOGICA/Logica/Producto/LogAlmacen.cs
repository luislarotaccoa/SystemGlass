using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VERTICAL.Modelos.Producto;

namespace LOGICA.Logica.Producto
{
    public class LogAlmacen : IRepositorio<ModelAlmacen>
    {
        Conexion C = new Conexion();
        public string Eliminar(int IdAlmacen, bool Estado)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", System.Data.SqlDbType.VarChar, System.Data.ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColAlmacen.IdAlmacen.ToString(), IdAlmacen));
                listParam.Add(new Parametros(ColAlmacen.Estado.ToString(), Estado));
                C.EjecutarSP(ProcAlmacen.EliminarAlmacen.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Modificar(ModelAlmacen entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColAlmacen.IdAlmacen.ToString(), entity.IdAlmacen));
                listParam.Add(new Parametros(ColAlmacen.Serie.ToString(), entity.Serie));
                listParam.Add(new Parametros(ColAlmacen.Nombre.ToString(), entity.Nombre));
                listParam.Add(new Parametros(ColAlmacen.Direccion.ToString(), entity.Direccion));
                C.EjecutarSP(ProcCategoria.ModificarCategoria.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelAlmacen> Buscar(List<ModelAlmacen> list, string dato)
        {
            List<ModelAlmacen> result = list.Where(d =>
            d.Nombre.ToLower().Contains(dato.ToLower())).ToList();
            return result;
        }

        public ModelAlmacen Consulta(int IdAlmacen)
        {
            List<Parametros> listParam = new List<Parametros>();
            ModelAlmacen MAlmacen = null;
            try
            {
                listParam.Add(new Parametros(ColAlmacen.IdAlmacen.ToString(), IdAlmacen));
                var dt = C.Listado(ProcAlmacen.ConsultarAlmacen.ToString(), listParam).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var dtr = dt.Rows[0];
                    MAlmacen = new ModelAlmacen
                    {
                        IdAlmacen = Convert.ToInt32(dtr[ColAlmacen.IdAlmacen.ToString()]),
                        Serie = Convert.ToInt32(dtr[ColAlmacen.Serie.ToString()]),
                        Nombre = dtr[ColAlmacen.Nombre.ToString()].ToString(),
                        Direccion = dtr[ColAlmacen.Direccion.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dtr[ColAlmacen.Estado.ToString()])
                    };
                }
                return MAlmacen;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelAlmacen> Listar(object f1, object f2)
        {
            List<ModelAlmacen> list = new List<ModelAlmacen>();
            try
            {
                var dt = C.Listado(ProcAlmacen.ListarAlmacen.ToString(), null).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var rw = dt.Rows[i];
                        var MAlmacen = new ModelAlmacen
                        {
                            IdAlmacen = Convert.ToInt32(rw[ColAlmacen.IdAlmacen.ToString()]),
                            Serie = Convert.ToInt32(rw[ColAlmacen.Serie.ToString()]),
                            Nombre = rw[ColAlmacen.Nombre.ToString()].ToString(),
                            Direccion = rw[ColAlmacen.Direccion.ToString()].ToString(),
                            Estado = Convert.ToBoolean(rw[ColAlmacen.Estado.ToString()])
                        };
                        list.Add(MAlmacen);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Registrar(ModelAlmacen entity)
        {
            var ListParam = new List<Parametros>();
            try
            {
                ListParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                ListParam.Add(new Parametros(ColAlmacen.Serie.ToString(), entity.Serie));
                ListParam.Add(new Parametros(ColAlmacen.Nombre.ToString(), entity.Nombre));
                ListParam.Add(new Parametros(ColAlmacen.Direccion.ToString(), entity.Direccion));
                C.EjecutarSP(ProcAlmacen.RegistrarAlmacen.ToString(), ref ListParam);
                string mensaje = ListParam[0].m_Valor.ToString();
                return mensaje;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public object Listar(int idAlmacen)
        {
            throw new NotImplementedException();
        }
    }
}
