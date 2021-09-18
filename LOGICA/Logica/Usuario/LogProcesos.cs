using DATOS;
using System;
using System.Collections.Generic;
using VERTICAL.Modelo.Usuario;

namespace LOGICA.Logica.Usuario
{
    public class LogProcesos : IRepositorio<ModelProcesos>
    {
        Conexion C = new Conexion();
        public List<ModelProcesos> Buscar(List<ModelProcesos> list, string dato)
        {
            throw new System.NotImplementedException();
        }

        public ModelProcesos Consulta(int id)
        {
            throw new System.NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            throw new System.NotImplementedException();
        }

        public List<ModelProcesos> Listar(object f1, object f2)
        {
            var lista = new List<ModelProcesos>();
            try
            {
                var dt = C.Listado(ProcProceso.ListarProceso.ToString(), null).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelProcesos
                    {
                        IdProceso = Convert.ToInt32(dt.Rows[i][ColProcesos.IdProceso.ToString()]),
                        Proceso = dt.Rows[i][ColProcesos.Proceso.ToString()].ToString(),
                        Nodo = Convert.ToInt32(dt.Rows[i][ColProcesos.Nodo.ToString()])
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

        public string Modificar(ModelProcesos entity)
        {
            throw new System.NotImplementedException();
        }

        public string Registrar(ModelProcesos entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
