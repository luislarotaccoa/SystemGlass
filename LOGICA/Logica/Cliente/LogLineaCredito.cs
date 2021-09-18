using DATOS;
using LOGICA.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using VERTICAL.Modelos.Cliente;

namespace LOGICA.Logica.Cliente
{
    public class LogLineaCredito : IRepositorio<ModelLineaCredito>
    {
        Conexion C = new Conexion();

        public List<ModelLineaCredito> Buscar(List<ModelLineaCredito> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelLineaCredito Consulta(int id)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            throw new NotImplementedException();
        }

        public List<ModelLineaCredito> Listar(object f1, object f2)
        {
            List<Parametros> lst = new List<Parametros>();
            List<ModelLineaCredito> lista = new List<ModelLineaCredito>();
            try
            {
                lst.Add(new Parametros(ColLineaCredito.IdCliente.ToString(), f1));
                var dt = C.Listado(ProcLineaCredito.ListarLineaCredito.ToString(), lst).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelLineaCredito
                    {
                        IdLineaCredito = Convert.ToInt32(dt.Rows[i][ColLineaCredito.IdLineaCredito.ToString()]),
                        IdCliente = Convert.ToInt32(dt.Rows[i][ColLineaCredito.IdCliente.ToString()]),
                        DiasMax = Convert.ToInt32(dt.Rows[i][ColLineaCredito.DiasMax.ToString()]),
                        MontoMax = Convert.ToDecimal(dt.Rows[i][ColLineaCredito.MontoMax.ToString()]),
                        IdCalificacion = Convert.ToInt32(dt.Rows[i][ColLineaCredito.IdCalificacion.ToString()]),
                        Nota = dt.Rows[i][ColLineaCredito.Nota.ToString()].ToString(),
                        Descripcion = dt.Rows[i][ColLineaCredito.Descripcion.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dt.Rows[i][ColLineaCredito.Estado.ToString()])
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

        public string Modificar(ModelLineaCredito entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColLineaCredito.IdLineaCredito.ToString(), entity.IdLineaCredito));
                lst.Add(new Parametros(ColLineaCredito.DiasMax.ToString(), entity.DiasMax));
                lst.Add(new Parametros(ColLineaCredito.MontoMax.ToString(), entity.MontoMax));
                lst.Add(new Parametros(ColLineaCredito.IdCalificacion.ToString(), entity.IdCalificacion));
                C.EjecutarSP(ProcLineaCredito.ModificarLineaCredito.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public string Registrar(ModelLineaCredito entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColLineaCredito.IdCliente.ToString(), entity.IdCliente));
                lst.Add(new Parametros(ColLineaCredito.IdCalificacion.ToString(), entity.IdCalificacion));
                lst.Add(new Parametros(ColLineaCredito.DiasMax.ToString(), entity.DiasMax));
                lst.Add(new Parametros(ColLineaCredito.MontoMax.ToString(), entity.MontoMax));
                C.EjecutarSP(ProcLineaCredito.RegistrarLineaCredito.ToString(), ref lst);
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
