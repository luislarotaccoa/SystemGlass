using DATOS;
using LOGICA.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VERTICAL.Modelos.Cliente;

namespace LOGICA.Logica.Cliente
{
    public class LogCalificacion : IRepositorio<ModelCalificacion>
    {
        Conexion C = new Conexion();

        public List<ModelCalificacion> Buscar(List<ModelCalificacion> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelCalificacion Consulta(int id)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            throw new NotImplementedException();
        }

        public List<ModelCalificacion> Listar(object f1, object f2)
        {
            List<ModelCalificacion> lista = new List<ModelCalificacion>();
            try
            {
                var dt = C.Listado(ProcCalificacion.ListarCalificacion.ToString(), null).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelCalificacion
                    {
                        IdCalificacion = Convert.ToInt32(dt.Rows[i][ColCalificacion.IdCalificacion.ToString()]),
                        Nota = dt.Rows[i][ColCalificacion.Nota.ToString()].ToString(),
                        Descripcion = dt.Rows[i][ColCalificacion.Descripcion.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dt.Rows[i][ColCalificacion.Estado.ToString()])
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

        public string Modificar(ModelCalificacion entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColCalificacion.IdCalificacion.ToString(), entity.IdCalificacion));
                lst.Add(new Parametros(ColCalificacion.Nota.ToString(), entity.Nota));
                lst.Add(new Parametros(ColCalificacion.Descripcion.ToString(), entity.Descripcion));
                C.EjecutarSP(ProcCalificacion.ModificarCalificacion.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public string Registrar(ModelCalificacion entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColCalificacion.Nota.ToString(), entity.Nota));
                lst.Add(new Parametros(ColCalificacion.Descripcion.ToString(), entity.Descripcion));
                C.EjecutarSP(ProcCalificacion.RegistrarCalificacion.ToString(), ref lst);
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
