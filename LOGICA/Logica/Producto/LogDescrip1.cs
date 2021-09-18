using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VERTICAL.Modelos.Producto;

namespace LOGICA.Logica.Producto
{
    public class LogDescrip1 : IRepositorio<ModelDescrip1>
    {
        Conexion C = new Conexion();

        public List<ModelDescrip1> Buscar(List<ModelDescrip1> list, string dato)
        {
            List<ModelDescrip1> result = list.Where(d =>
            d.Descripcion.ToLower().Contains(dato.ToLower())).ToList();
            return result;
        }

        public ModelDescrip1 Consulta(int id)
        {
            List<Parametros> listParam = new List<Parametros>();
            ModelDescrip1 MDescrip1 = null;
            try
            {
                listParam.Add(new Parametros(ColDescrip1.IdDescrip1.ToString(), id));
                var dt = C.Listado(ProcDescrip1.ConsultarDescrip1.ToString(), listParam).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var dtr = dt.Rows[0];
                    MDescrip1 = new ModelDescrip1
                    {
                        IdDescrip1 = Convert.ToInt32(dtr[ColDescrip1.IdDescrip1.ToString()]),
                        Descripcion = dtr[ColDescrip1.Descripcion.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dtr[ColCategoria.Estado.ToString()])
                    };
                }
                return MDescrip1;
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
                listParam.Add(new Parametros(ColDescrip1.IdDescrip1.ToString(), Id));
                listParam.Add(new Parametros(ColDescrip1.Estado.ToString(), act));
                C.EjecutarSP(ProcDescrip1.EliminarDescrip1.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelDescrip1> Listar(object f1, object f2)
        {
            List<ModelDescrip1> list = new List<ModelDescrip1>();
            try
            {
                var dt = C.Listado(ProcDescrip1.ListarDescrip1.ToString(), null).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var rw = dt.Rows[i];
                        var MDescrip1 = new ModelDescrip1
                        {
                            IdDescrip1 = Convert.ToInt32(rw[ColDescrip1.IdDescrip1.ToString()]),
                            Descripcion = rw[ColDescrip1.Descripcion.ToString()].ToString(),
                            Estado = Convert.ToBoolean(rw[ColDescrip1.Estado.ToString()])
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
        public List<ModelDescrip1> Listar(int IdFamilia)
        {
            List<ModelDescrip1> list = new List<ModelDescrip1>();
            List<Parametros> listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros(ColDescrip1.IdFamilia.ToString(), IdFamilia));
                var dt = C.Listado(ProcDescrip1.ListarDescrip1.ToString(), listParam).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var rw = dt.Rows[i];
                        var MDescrip1 = new ModelDescrip1
                        {
                            IdDescrip1 = Convert.ToInt32(rw[ColDescrip1.IdDescrip1.ToString()]),
                            IdFamilia = Convert.ToInt32(rw[ColDescrip1.IdFamilia.ToString()]),
                            Descripcion = rw[ColDescrip1.Descripcion.ToString()].ToString(),
                            NomFamilia = rw[ColDescrip1.NomFamilia.ToString()].ToString(),
                            Estado = Convert.ToBoolean(rw[ColDescrip1.Estado.ToString()])
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
        public string Modificar(ModelDescrip1 entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColDescrip1.IdDescrip1.ToString(), entity.IdDescrip1));
                listParam.Add(new Parametros(ColDescrip1.Descripcion.ToString(), entity.Descripcion));
                C.EjecutarSP(ProcDescrip1.ModificarDescrip1.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Registrar(ModelDescrip1 entity)
        {
            var ListParam = new List<Parametros>();
            try
            {
                ListParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                ListParam.Add(new Parametros(ColDescrip1.IdFamilia.ToString(), entity.IdFamilia));
                ListParam.Add(new Parametros(ColDescrip1.Descripcion.ToString(), entity.Descripcion));
                C.EjecutarSP(ProcDescrip1.RegistrarDescrip1.ToString(), ref ListParam);
                string mensaje = ListParam[0].m_Valor.ToString();
                return mensaje;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
