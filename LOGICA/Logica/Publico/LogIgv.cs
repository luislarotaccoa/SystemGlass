using DATOS;
using System;
using System.Collections.Generic;
using VERTICAL.Modelos.Publico;

namespace LOGICA.Logica.Publico
{
    public class LogIgv : IRepositorio<ModelIgv>
    {
        Conexion C = new Conexion();

        public List<ModelIgv> Buscar(List<ModelIgv> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelIgv Consulta(int id)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            throw new NotImplementedException();
        }

        public List<ModelIgv> Listar(object f1, object f2)
        {
            throw new NotImplementedException();
        }

        public string Modificar(ModelIgv entity)
        {
            throw new NotImplementedException();
        }

        public string Registrar(ModelIgv entity)
        {
            throw new NotImplementedException();
        }
    }
}
