using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using VERTICAL.Modelos.Producto;

namespace LOGICA.Logica.Producto
{
    public class LogColorCategoria : IRepositorio<ModelColor>
    {
        Conexion C = new Conexion();
        public string Modificar(ModelColor entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                lst.Add(new Parametros(ColColor.IdCategoria.ToString(), entity.IdCategoria));
                lst.Add(new Parametros(ColColor.IdColor.ToString(), entity.IdColor));
                C.EjecutarSP(ProcColor.ModificarColorCategoria.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public List<ModelColor> Buscar(List<ModelColor> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelColor Consulta(int Id)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {

            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                lst.Add(new Parametros(ColColor.IdColor.ToString(), Id));
                lst.Add(new Parametros(ColColor.IdColor.ToString(), Id));
                C.EjecutarSP(ProcColor.EliminarColorCategoria.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public List<ModelColor> Listar(object f1, object f2)
        {
            var lista = new List<ModelColor>();
            
            try
            {
                var dt = C.Listado(ProcColor.ListarColor.ToString(), null).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelColor
                    {
                        IdCategoria = Convert.ToInt32(dt.Rows[i][ColColor.IdCategoria.ToString()]),
                        NomColor = dt.Rows[i][ColColor.NomColor.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dt.Rows[i][ColColor.Estado.ToString()])
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

        public string Registrar(ModelColor entity)
        {

            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColColor.IdCategoria.ToString(), entity.IdCategoria));
                lst.Add(new Parametros(ColColor.IdColor.ToString(), entity.IdColor));
                C.EjecutarSP(ProcColor.RegistrarCategoriaColor.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public List<ModelColor> Listar(int idCategoria)
        {
            var lista = new List<ModelColor>();
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros(ColColor.IdCategoria.ToString(), idCategoria));
                var dt = C.Listado(ProcColor.ListarCategoriaColor.ToString(), listParam).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelColor
                    {
                        IdCategoria = Convert.ToInt32(dt.Rows[i][ColColor.IdCategoria.ToString()]),
                        IdColor = Convert.ToInt32(dt.Rows[i][ColColor.IdColor.ToString()]),
                        NomCategoria= dt.Rows[i][ColColor.NomCategoria.ToString()].ToString(),
                        Bilateral = Convert.ToBoolean(dt.Rows[i][ColColor.Bilateral.ToString()]),
                        NomColor = dt.Rows[i][ColColor.NomColor.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dt.Rows[i][ColColor.Estado.ToString()])
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
    }
}
