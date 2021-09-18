using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VERTICAL.Modelos.Producto;

namespace LOGICA.Logica.Producto
{
    public class LogCategoria : IRepositorio<ModelCategoria>
    {
        Conexion C = new Conexion();
        public string Eliminar(int IdCategoria, bool Estado)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", System.Data.SqlDbType.VarChar, System.Data.ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColCategoria.IdCategoria.ToString(), IdCategoria));
                listParam.Add(new Parametros(ColCategoria.Estado.ToString(), Estado));
                C.EjecutarSP(ProcCategoria.EliminarCategoria.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Modificar(ModelCategoria entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColCategoria.IdCategoria.ToString(), entity.IdCategoria));
                listParam.Add(new Parametros(ColCategoria.NomCategoria.ToString(), entity.NomCategoria));
                listParam.Add(new Parametros(ColCategoria.Bilateral.ToString(), entity.Bilateral));
                C.EjecutarSP(ProcCategoria.ModificarCategoria.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelCategoria> Buscar(List<ModelCategoria> list, string dato)
        {
            List<ModelCategoria> result = list.Where(d =>
            d.NomCategoria.ToLower().Contains(dato.ToLower())).ToList();
            return result;
        }

        public ModelCategoria Consulta(int IdCategoria)
        {
            List<Parametros> listParam = new List<Parametros>();
            ModelCategoria MCategoria = null;
            try
            {
                listParam.Add(new Parametros(ColCategoria.IdCategoria.ToString(), IdCategoria));
                var dt = C.Listado(ProcCategoria.ConsultarCategoria.ToString(), listParam).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var dtr = dt.Rows[0];
                    MCategoria = new ModelCategoria
                    {
                        IdCategoria = Convert.ToInt32(dtr[ColCategoria.IdCategoria.ToString()]),
                        NomCategoria = dtr[ColCategoria.NomCategoria.ToString()].ToString(),
                        Bilateral = Convert.ToBoolean(dtr[ColCategoria.Bilateral.ToString()]),
                        Estado = Convert.ToBoolean(dtr[ColCategoria.Estado.ToString()])
                    };
                }
                return MCategoria;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelCategoria> Listar(object f1, object f2)
        {
            List<ModelCategoria> list = new List<ModelCategoria>();
            try
            {
                var dt = C.Listado(ProcCategoria.ListarCategoria.ToString(), null).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var rw = dt.Rows[i];
                        var MCategoria = new ModelCategoria
                        {
                            IdCategoria = Convert.ToInt32(rw[ColCategoria.IdCategoria.ToString()]),
                            NomCategoria = rw[ColCategoria.NomCategoria.ToString()].ToString(),
                            Bilateral = Convert.ToBoolean(rw[ColCategoria.Bilateral.ToString()]),
                            Estado = Convert.ToBoolean(rw[ColCategoria.Estado.ToString()])
                        };
                        list.Add(MCategoria);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Registrar(ModelCategoria entity)
        {
            var ListParam = new List<Parametros>();
            try
            {
                ListParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                ListParam.Add(new Parametros(ColCategoria.NomCategoria.ToString(), entity.NomCategoria));
                ListParam.Add(new Parametros(ColCategoria.Bilateral.ToString(), entity.Bilateral));
                C.EjecutarSP(ProcCategoria.RegistrarCategoria.ToString(), ref ListParam);
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
