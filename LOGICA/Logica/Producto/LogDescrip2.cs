using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VERTICAL.Modelos.Producto;

namespace LOGICA.Logica.Producto
{
    public class LogDescrip2 : IRepositorio<ModelDescrip2>
    {
        Conexion C = new Conexion();

        public List<ModelDescrip2> Buscar(List<ModelDescrip2> list, string dato)
        {
            List<ModelDescrip2> result = list.Where(d =>
            d.Descripcion.ToLower().Contains(dato.ToLower())).ToList();
            return result;
        }

        public ModelDescrip2 Consulta(int id)
        {
            List<Parametros> listParam = new List<Parametros>();
            ModelDescrip2 MDescrip2 = null;
            try
            {
                listParam.Add(new Parametros(ColDescrip2.IdDescrip2.ToString(), id));
                var dt = C.Listado(ProcDescrip2.ConsultarDescrip2.ToString(), listParam).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var dtr = dt.Rows[0];
                    MDescrip2 = new ModelDescrip2
                    {
                        IdDescrip2 = Convert.ToInt32(dtr[ColDescrip2.IdDescrip2.ToString()]),
                        Descripcion = dtr[ColDescrip2.Descripcion.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dtr[ColDescrip2.Estado.ToString()])
                    };
                }
                return MDescrip2;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Eliminar(int Id, bool act)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColDescrip2.IdDescrip2.ToString(), Id));
                listParam.Add(new Parametros(ColDescrip2.Estado.ToString(), act));
                C.EjecutarSP(ProcDescrip2.EliminarDescrip2.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelDescrip2> Listar(object f1, object f2)
        {
            List<ModelDescrip2> list = new List<ModelDescrip2>();
            try
            {
                var dt = C.Listado(ProcDescrip2.ListarDescrip2.ToString(), null).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var rw = dt.Rows[i];
                        var MDescrip1 = new ModelDescrip2
                        {
                            IdDescrip2 = Convert.ToInt32(rw[ColDescrip2.IdDescrip2.ToString()]),
                            Descripcion = rw[ColDescrip2.Descripcion.ToString()].ToString(),
                            Estado = Convert.ToBoolean(rw[ColDescrip2.Estado.ToString()])
                        };
                        list.Add(MDescrip1);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Modificar(ModelDescrip2 entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColDescrip2.IdDescrip2.ToString(), entity.IdDescrip2));
                listParam.Add(new Parametros(ColDescrip2.Descripcion.ToString(), entity.Descripcion));
                C.EjecutarSP(ProcDescrip2.ModificarDescrip2.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Registrar(ModelDescrip2 entity)
        {
            var ListParam = new List<Parametros>();
            try
            {
                ListParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                ListParam.Add(new Parametros(ColDescrip2.IdDescrip2.ToString(), 0, SqlDbType.Int, ParameterDirection.Output, 11));
                ListParam.Add(new Parametros(ColDescrip2.Descripcion.ToString(), entity.Descripcion));
                C.EjecutarSP(ProcDescrip2.RegistrarDescrip2.ToString(), ref ListParam);
                string mensaje = ListParam[0].m_Valor.ToString();
                if (mensaje== "1")
                {
                    entity.IdDescrip2 = Convert.ToInt32(ListParam[1].m_Valor);
                }
                return mensaje;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelDescrip2> Listar(int idCategoria)
        {
            throw new NotImplementedException();
        }
    }
}

