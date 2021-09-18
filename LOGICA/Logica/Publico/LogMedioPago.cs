using DATOS;
using LOGICA.Logica;
using System;
using System.Collections.Generic;
using VERTICAL.Modelos.Publico;

namespace VERTICAL.Logica.Publico
{
    public class LogMedioPago : IRepositorio<ModelMedioPago>
    {
        Conexion C = new Conexion();

        public List<ModelMedioPago> Buscar(List<ModelMedioPago> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelMedioPago Consulta(int id)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            throw new NotImplementedException();
        }

        public List<ModelMedioPago> Listar(object f1, object f2)
        {
            throw new NotImplementedException();
        }

        public string Modificar(ModelMedioPago entity)
        {
            throw new NotImplementedException();
        }

        public string Registrar(ModelMedioPago entity)
        {
            throw new NotImplementedException();
        }
    }
}
