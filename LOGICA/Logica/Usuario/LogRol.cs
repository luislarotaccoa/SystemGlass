using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using VERTICAL.Modelo.Usuario;


namespace LOGICA.Logica.Usuario
{

    public class LogRol : IRepositorio<ModelRol>
    {
        Conexion C = new Conexion();
        public List<ModelRol> Buscar(List<ModelRol> list, string dato)
        {
            throw new System.NotImplementedException();
        }

        public ModelRol Consulta(int id)
        {
            List<Parametros> lst = new List<Parametros>();

            try
            {
                lst.Add(new Parametros(ColRol.IdRol.ToString(), id));
                var dt = C.Listado(ProcRol.ConsultarRol.ToString(), lst).Tables[0];
                var r = dt.Rows[0];
                return new ModelRol
                {
                    IdRol = Convert.ToInt32(r[ColRol.IdRol.ToString()]),
                    Rol = r[ColRol.Rol.ToString()].ToString(),
                    Estado = Convert.ToBoolean(r[ColRol.Estado.ToString()])
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Eliminar(int Id, bool act)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                lst.Add(new Parametros(ColRol.IdRol.ToString(), Id));
                lst.Add(new Parametros(ColRol.Estado.ToString(), !act));
                C.EjecutarSP(ProcRol.EliminarRol.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public List<ModelRol> Listar(object f1, object f2)
        {
            var lista = new List<ModelRol>();
            try
            {
                var dt = C.Listado(ProcRol.ListarRol.ToString(), null).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelRol
                    {
                        IdRol = Convert.ToInt32(dt.Rows[i][ColRol.IdRol.ToString()]),
                        Rol = dt.Rows[i][ColRol.Rol.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dt.Rows[i][ColRol.Estado.ToString()])
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

        public string Modificar(ModelRol entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                lst.Add(new Parametros(ColRol.IdRol.ToString(), entity.IdRol));
                lst.Add(new Parametros(ColRol.Rol.ToString(), entity.Rol));
                C.EjecutarSP(ProcRol.ModificarRol.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public string Registrar(ModelRol entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColRol.Rol.ToString(), entity.Rol));
                C.EjecutarSP(ProcRol.RegistrarRol.ToString(), ref lst);
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
