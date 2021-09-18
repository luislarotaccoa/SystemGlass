using DATOS;
using LOGICA.Entidades.Producto;
using System;
using System.Collections.Generic;
using System.Data;
using VERTICAL.Modelos.Producto;

namespace LOGICA.Logica.Producto
{
    public class LogColor : IRepositorio<ModelColor>
    {
        Conexion C = new Conexion();
        public string Eliminar(int IdColor, bool Estado)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColColor.IdColor.ToString(), IdColor));
                listParam.Add(new Parametros(ColColor.Estado.ToString(), Estado));
                C.EjecutarSP(ProcColor.EliminarColor.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message,e);
            }
        }

        public string Modificar(ModelColor entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", System.Data.SqlDbType.VarChar, System.Data.ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColColor.IdColor.ToString(), entity.IdColor));
                listParam.Add(new Parametros(ColColor.NomColor.ToString(), entity.NomColor));
                C.EjecutarSP(ProcColor.ModificarColor.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelColor> Buscar(List<ModelColor> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelColor Consulta(int IdColor)
        {
            List<Parametros> listParam = new List<Parametros>();
            ModelColor MColor = null;
            try
            {
                listParam.Add(new Parametros(ColColor.IdColor.ToString(), IdColor));
                var dt = C.Listado(ProcColor.ConsultarColor.ToString(), listParam).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var dtr = dt.Rows[0];
                    MColor = new ModelColor
                    {
                        IdColor = Convert.ToInt32(dtr[ColColor.IdColor.ToString()]),
                        NomColor = dtr[ColColor.NomColor.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dtr[ColColor.Estado.ToString()])
                    };
                }
                return MColor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelColor> Listar(object f1, object f2)
        {
            List<ModelColor> list = new List<ModelColor>();
            try
            {
                var dt = C.Listado(ProcColor.ListarColor.ToString(), null).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var dtr = dt.Rows[i];
                        var MColor = new ModelColor
                        {
                            IdColor = Convert.ToInt32(dtr[ColColor.IdColor.ToString()]),
                            NomColor = dtr[ColColor.NomColor.ToString()].ToString(),
                            Estado = Convert.ToBoolean(dtr[ColColor.Estado.ToString()])
                        };
                        list.Add(MColor);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Registrar(ModelColor entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColColor.IdColor.ToString(), 0, SqlDbType.Int, ParameterDirection.Output, 11));
                listParam.Add(new Parametros(ColColor.NomColor.ToString(), entity.NomColor));
                C.EjecutarSP(ProcColor.RegistrarColor.ToString(), ref listParam);
                string result = listParam[0].m_Valor.ToString();
                if (result=="1")
                {
                    entity.IdColor = Convert.ToInt32(listParam[1].m_Valor);
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        //Carga masivo
        public string Registrar(List<ModelColor> listaGrabar)
        {
            List<Color> list = new List<Color>();
            for (int j = 0; j < listaGrabar.Count; j++)
            {
                var u = new Color();
                u.IdColor = 0;
                u.NomColor = listaGrabar[j].NomColor;
                u.Estado = listaGrabar[j].Estado;
                list.Add(u);
            }
            //tabla propia
            DataTable table = VERTICAL.Ayudas.Convertir.ConvertToDataTable(list);
            try
            {
                return C.CargaMasiva("Color", table);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
