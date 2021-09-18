using DATOS;
using System;
using System.Collections.Generic;
using VERTICAL.Modelos.Publico;

namespace LOGICA.Logica.Publico
{
    public class LogBanco : IRepositorio<ModelBanco>
    {
        Conexion C = new Conexion();

        public List<ModelBanco> Buscar(List<ModelBanco> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelBanco Consulta(int id)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            throw new NotImplementedException();
        }

        public List<ModelBanco> Listar(object f1, object f2)
        {
            throw new NotImplementedException();
        }

        public string Modificar(ModelBanco entity)
        {
            throw new NotImplementedException();
        }

        public string Registrar(ModelBanco entity)
        {
            throw new NotImplementedException();
        }
    }
}
