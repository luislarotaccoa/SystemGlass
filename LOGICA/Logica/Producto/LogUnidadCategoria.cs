using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using VERTICAL.Modelos.Producto;

namespace LOGICA.Logica.Producto
{
    public class LogUnidadCategoria:IRepositorio<ModelUnidad>
    {
        Conexion C = new Conexion();
        public string Modificar(ModelUnidad entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                lst.Add(new Parametros(ColUnidad.IdUnidadCategoria.ToString(), entity.IdUnidadCategoria));
                lst.Add(new Parametros(ColUnidad.IdCategoria.ToString(), entity.IdCategoria));
                lst.Add(new Parametros(ColUnidad.IdUnidad.ToString(), entity.IdUnidad));
                C.EjecutarSP(ProcUnidad.ModificarUnidadCategoria.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public List<ModelUnidad> Buscar(List<ModelUnidad> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelUnidad Consulta(int Id)
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
                lst.Add(new Parametros(ColUnidad.IdUnidadCategoria.ToString(), Id));
                C.EjecutarSP(ProcUnidad.EliminarUnidadCategoria.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public List<ModelUnidad> Listar(object idCategoria, object f2)
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
                        IdUnidadCategoria = Convert.ToInt32(dt.Rows[i][ColUnidad.IdUnidadCategoria.ToString()]),
                        //IdCategoria = Convert.ToInt32(dt.Rows[i][ColUnidad.IdCategoria.ToString()]),
                        IdUnidad = Convert.ToInt32(dt.Rows[i][ColUnidad.IdUnidad.ToString()]),
                        NomCategoria = dt.Rows[i][ColUnidad.NomCategoria.ToString()].ToString(),
                        AUnidad= dt.Rows[i][ColUnidad.AUnidad.ToString()].ToString(),
                        CodUnidad= dt.Rows[i][ColUnidad.CodUnidad.ToString()].ToString(),
                        Factor = Convert.ToDecimal(dt.Rows[i][ColUnidad.Factor.ToString()]),
                        Estado = Convert.ToBoolean(dt.Rows[i][ColUnidad.Estado.ToString()])
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

            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColUnidad.IdCategoria.ToString(), entity.IdCategoria));
                lst.Add(new Parametros(ColUnidad.IdUnidad.ToString(), entity.IdUnidad));
                C.EjecutarSP(ProcUnidad.RegistrarUnidadCategoria.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }
    }
}
