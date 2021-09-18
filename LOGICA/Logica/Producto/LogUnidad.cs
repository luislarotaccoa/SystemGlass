using DATOS;
using System;
using System.Collections.Generic;
using VERTICAL.Modelos.Producto;

namespace LOGICA.Logica.Producto
{
    public class LogUnidad : IRepositorio<ModelUnidad>
    {
        Conexion C = new Conexion();
        public string Eliminar(int IdUnidad, bool Estado)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", System.Data.SqlDbType.VarChar, System.Data.ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColUnidad.IdUnidad.ToString(), IdUnidad));
                listParam.Add(new Parametros(ColUnidad.Estado.ToString(), Estado));
                C.EjecutarSP(ProcUnidad.EliminarUnidad.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Modificar(ModelUnidad entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", System.Data.SqlDbType.VarChar, System.Data.ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColUnidad.IdUnidad.ToString(), entity.IdUnidad));
                listParam.Add(new Parametros(ColUnidad.AUnidad.ToString(), entity.AUnidad));
                listParam.Add(new Parametros(ColUnidad.CodUnidad.ToString(), entity.CodUnidad));
                listParam.Add(new Parametros(ColUnidad.Factor.ToString(), entity.Factor));
                C.EjecutarSP(ProcUnidad.ModificarUnidad.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelUnidad> Buscar(List<ModelUnidad> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelUnidad Consulta(int IdUnidad)
        {
            List<Parametros> listParam = new List<Parametros>();
            ModelUnidad MUnidad = null;
            try
            {
                listParam.Add(new Parametros(ColUnidad.IdUnidad.ToString(), IdUnidad));
                var dt = C.Listado(ProcUnidad.ConsultarUnidad.ToString(), listParam).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var dtr = dt.Rows[0];
                    MUnidad = new ModelUnidad
                    {
                        IdUnidad = Convert.ToInt32(dtr[ColUnidad.IdUnidad.ToString()]),
                        AUnidad = dtr[ColUnidad.AUnidad.ToString()].ToString(),
                        CodUnidad = dtr[ColUnidad.CodUnidad.ToString()].ToString(),
                        Factor = Convert.ToDecimal(dtr[ColUnidad.Factor.ToString()]),
                        Estado = Convert.ToBoolean(dtr[ColUnidad.Estado.ToString()])
                    };
                }
                return MUnidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelUnidad> Listar(object f1, object f2)
        {
            List<ModelUnidad> ListUnidad = null;
            try
            {
                var dt = C.Listado(ProcUnidad.ListarUnidad.ToString(), null).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ListUnidad = new List<ModelUnidad>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var dtr = dt.Rows[i];
                        var MUnidad = new ModelUnidad
                        {
                            IdUnidad = Convert.ToInt32(dtr[ColUnidad.IdUnidad.ToString()]),
                            AUnidad = dtr[ColUnidad.AUnidad.ToString()].ToString(),
                            CodUnidad = dtr[ColUnidad.CodUnidad.ToString()].ToString(),
                            Factor = Convert.ToDecimal(dtr[ColUnidad.Factor.ToString()]),
                            Estado = Convert.ToBoolean(dtr[ColUnidad.Estado.ToString()])
                        };
                        ListUnidad.Add(MUnidad);
                    }
                }
                return ListUnidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public List<ModelUnidad> Listar(int idCategoria)
        {
            var lista = new List<ModelUnidad>();
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros(ColUnidad.IdCategoria.ToString(), idCategoria));
                var dt = C.Listado(ProcUnidad.ListarUnidadCategoria.ToString(), listParam).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelUnidad
                    {
                        IdCategoria = Convert.ToInt32(dt.Rows[i][ColUnidad.IdCategoria.ToString()]),
                        IdUnidad = Convert.ToInt32(dt.Rows[i][ColUnidad.IdUnidad.ToString()]),
                        NomCategoria = dt.Rows[i][ColUnidad.NomCategoria.ToString()].ToString(),
                        AUnidad = dt.Rows[i][ColUnidad.AUnidad.ToString()].ToString(),
                        Medible = Convert.ToBoolean(dt.Rows[i][ColUnidad.Medible.ToString()]),
                        IdUnidadMinima = Convert.ToInt32(dt.Rows[i][ColUnidad.IdUnidadMinima.ToString()]),
                        AUnidadMinima = dt.Rows[i][ColUnidad.AUnidadMinima.ToString()].ToString(),
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
        public string Registrar(ModelUnidad entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", System.Data.SqlDbType.VarChar, System.Data.ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColUnidad.IdUnidad.ToString(),0, System.Data.SqlDbType.Int, System.Data.ParameterDirection.Output, 11));
                listParam.Add(new Parametros(ColUnidad.AUnidad.ToString(), entity.AUnidad));
                listParam.Add(new Parametros(ColUnidad.CodUnidad.ToString(), entity.CodUnidad));
                listParam.Add(new Parametros(ColUnidad.Factor.ToString(), entity.Factor));
                C.EjecutarSP(ProcUnidad.RegistrarUnidad.ToString(), ref listParam);
                string result = listParam[0].m_Valor.ToString();
                if (result=="1")
                {
                    entity.IdUnidad = Convert.ToInt32(listParam[1].m_Valor.ToString());
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
