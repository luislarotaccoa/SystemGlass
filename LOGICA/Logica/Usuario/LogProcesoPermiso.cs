using DATOS;
using System;
using System.Collections.Generic;
using VERTICAL.Modelo.Usuario;

namespace LOGICA.Logica.Usuario
{
    public class LogProcesoPermiso : IRepositorio<ModelProcesoPermiso>
    {
        Conexion C = new Conexion();
        public List<ModelProcesoPermiso> Buscar(List<ModelProcesoPermiso> list, string dato)
        {
            throw new System.NotImplementedException();
        }

        public ModelProcesoPermiso Consulta(int id)
        {
            throw new System.NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            throw new System.NotImplementedException();
        }

        public List<ModelProcesoPermiso> Listar(object f1, object f2)
        {
            List<Parametros> lst = new List<Parametros>();
            var lista = new List<ModelProcesoPermiso>();
            try
            {
                lst.Add(new Parametros("@" + ColProcesoPermiso.IdProceso, f1));
                var dt = C.Listado(ProcProcesoPermiso.ListarProcesoPermiso.ToString(), lst).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelProcesoPermiso
                    {
                        IdProceso = Convert.ToInt32(dt.Rows[i][ColProcesoPermiso.IdProceso.ToString()]),
                        IdPermiso = Convert.ToInt32(dt.Rows[i][ColProcesoPermiso.IdPermiso.ToString()]),
                        Permiso = dt.Rows[i][ColProcesoPermiso.Permiso.ToString()].ToString(),
                        Proceso = dt.Rows[i][ColProcesoPermiso.Proceso.ToString()].ToString()
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
        public List<ModelProcesoPermiso> Listar()
        {

            var lista = new List<ModelProcesoPermiso>();
            try
            {
                var dt = C.Listado("ListProcesoPermiso", null).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelProcesoPermiso
                    {
                        IdProceso = Convert.ToInt32(dt.Rows[i][ColProcesoPermiso.IdProceso.ToString()]),
                        IdPermiso = Convert.ToInt32(dt.Rows[i][ColProcesoPermiso.IdPermiso.ToString()]),
                        Permiso = dt.Rows[i][ColProcesoPermiso.Permiso.ToString()].ToString(),
                        Proceso = dt.Rows[i][ColProcesoPermiso.Proceso.ToString()].ToString()
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
        public string Modificar(ModelProcesoPermiso entity)
        {
            throw new System.NotImplementedException();
        }

        public string Registrar(ModelProcesoPermiso entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
