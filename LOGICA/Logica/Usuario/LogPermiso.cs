using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using VERTICAL.Modelo.Usuario;

namespace LOGICA.Logica.Usuario
{
    public class LogPermiso : IRepositorio<ModelPermiso>
    {
        Conexion C = new Conexion();
        public List<ModelPermiso> Buscar(List<ModelPermiso> list, string dato)
        {
            throw new System.NotImplementedException();
        }

        public ModelPermiso Consulta(int id)
        {
            throw new System.NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            throw new System.NotImplementedException();
        }

        public List<ModelPermiso> Listar(object f1, object f2)
        {
            var lista = new List<ModelPermiso>();
            try
            {
                var dt = C.Listado(ProcPermiso.ListarPermiso.ToString(), null).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelPermiso
                    {
                        IdPermiso = Convert.ToInt32(dt.Rows[i][ColPermiso.IdPermiso.ToString()]),
                        Descripcion = dt.Rows[i][ColPermiso.Descripcion.ToString()].ToString()
                        //Estado = Convert.ToBoolean(dt.Rows[i][ColRolesModel.Estado.ToString()])
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

        public string Modificar(ModelPermiso entity)
        {
            throw new System.NotImplementedException();
        }
        public string Registrar(ModelPermiso entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColPermiso.Descripcion.ToString(), entity.Descripcion));
                C.EjecutarSP(ProcPermiso.RegistrarPermiso.ToString(), ref lst);
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
