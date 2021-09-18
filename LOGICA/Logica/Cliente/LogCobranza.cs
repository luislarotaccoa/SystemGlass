using DATOS;
using LOGICA.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VERTICAL.Modelos.Cliente;

namespace LOGICA.Logica.Cliente { 
    public class LogicaCobranza : IRepositorio<ModelCobranza>
    {
        Conexion C = new Conexion();

        public List<ModelCobranza> Buscar(List<ModelCobranza> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelCobranza Consulta(int id)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            throw new NotImplementedException();
        }

        public List<ModelCobranza> Listar(object f1, object f2)
        {
            throw new NotImplementedException();
        }

        public string Modificar(ModelCobranza entity)
        {
            throw new NotImplementedException();
        }

        public string Registrar(ModelCobranza entity)
        {
            throw new NotImplementedException();
        }
        public List<ModelCobranza> ConsultaDeudaCliente(int idCliente)
        {
            List<Parametros> lst = new List<Parametros>();
            List<ModelCobranza> list = new List<ModelCobranza>();
            try
            {
                lst.Add(new Parametros(ColCobranza.IdCliente.ToString(), idCliente));
                var ds = C.Listado(ProcCobranza.ConsultaDeudaCliente.ToString(), lst);
                var dtTodos = ds.Tables[0];
                var dtAcuenta = ds.Tables[1];
                var listaTodos = from row in dtTodos.AsEnumerable()
                                 group row by row.Field<int>(ColCobranza.IdVentas.ToString()) into g
                                 select new
                                 {
                                     IdVentas = g.Key,
                                     Monto = g.Sum(x => x.Field<decimal>(ColCobranza.Importe.ToString()))
                                 };
                var listaAcuenta = from row in dtAcuenta.AsEnumerable()
                                   group row by row.Field<int>(ColCobranza.IdVentas.ToString()) into g
                                   select new
                                   {
                                       IdVentas = g.Key,
                                       Monto = g.Sum(x => x.Field<decimal>(ColCobranza.Importe.ToString()))
                                   };
                for (int i = 0; i < listaTodos.Count(); i++)
                {
                    var todas = listaTodos.ToList()[i];
                    var cm = new ModelCobranza();
                    cm.IdVentas = todas.IdVentas;
                    cm.Importe = todas.Monto;
                    if (listaAcuenta.ToList().Exists(d => d.IdVentas == todas.IdVentas))
                    {
                        var acuenta = listaAcuenta.ToList().Find(d => d.IdVentas == todas.IdVentas);
                        cm.Saldo = todas.Monto - acuenta.Monto;
                        cm.ACuenta = acuenta.Monto;
                    }
                    else
                    {
                        cm.Saldo = todas.Monto;
                        cm.ACuenta = 0;
                    }
                    list.Add(cm);
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
