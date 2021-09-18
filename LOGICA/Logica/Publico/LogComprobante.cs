using DATOS;
using System;
using System.Collections.Generic;
using VERTICAL.Modelos.Publico;

namespace LOGICA.Logica.Publico
{
    public class LogComprobante : IRepositorio<ModelComprobante>
    {
        Conexion C = new Conexion();

        public List<ModelComprobante> Buscar(List<ModelComprobante> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelComprobante Consulta(int id)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            throw new NotImplementedException();
        }

        public List<ModelComprobante> Listar(object f1, object f2)
        {
            throw new NotImplementedException();
        }

        public string Modificar(ModelComprobante entity)
        {
            throw new NotImplementedException();
        }

        public string Registrar(ModelComprobante entity)
        {
            throw new NotImplementedException();
        }
    }
}
