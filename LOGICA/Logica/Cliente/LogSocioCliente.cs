using DATOS;
using LOGICA.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using VERTICAL.Modelos.Cliente;
using VERTICAL.Modelos.Publico;

namespace LOGICA.Logica.Cliente
{
    public class LogSocioCliente : IRepositorio<ModelSocioCliente>
    {
        Conexion C = new Conexion();

        public List<ModelSocioCliente> Buscar(List<ModelSocioCliente> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelSocioCliente Consulta(int id)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            throw new NotImplementedException();
        }

        public List<ModelSocioCliente> Listar(object f1, object f2)
        {
            List<ModelSocioCliente> lista = new List<ModelSocioCliente>();
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros(ColSocioCliente.IdCliente1.ToString(), f1));
                DataTable dt = C.Listado(ProcSocioCliente.ListarSocioCliente.ToString(), lst).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelSocioCliente
                    {
                        IdCliente1 = Convert.ToInt32(dt.Rows[i][ColSocioCliente.IdCliente1.ToString()]),
                        IdCliente2 = Convert.ToInt32(dt.Rows[i][ColSocioCliente.IdCliente2.ToString()]),
                        CodDocumento = (Documento)Convert.ToInt32(dt.Rows[i][ColSocioCliente.CodDocumento.ToString()]),
                        RazSocial = dt.Rows[i][ColSocioCliente.RazSocial.ToString()].ToString(),
                        NumDocumento = dt.Rows[i][ColSocioCliente.NumDocumento.ToString()].ToString(),
                        Telefono = dt.Rows[i][ColSocioCliente.Telefono.ToString()].ToString(),
                        TipSocio = dt.Rows[i][ColSocioCliente.TipSocio.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dt.Rows[i][ColSocioCliente.Estado.ToString()])
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

        public string Modificar(ModelSocioCliente entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColSocioCliente.IdCliente1.ToString(), entity.IdCliente1));
                lst.Add(new Parametros(ColSocioCliente.IdCliente2.ToString(), entity.IdCliente2));
                lst.Add(new Parametros(ColSocioCliente.TipSocio.ToString(), entity.TipSocio));
                C.EjecutarSP(ProcSocioCliente.ModificarSocioCliente.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public string Registrar(ModelSocioCliente entity)
        {
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                lst.Add(new Parametros(ColSocioCliente.IdCliente1.ToString(), entity.IdCliente1));
                lst.Add(new Parametros(ColSocioCliente.IdCliente2.ToString(), entity.IdCliente2));
                lst.Add(new Parametros(ColSocioCliente.TipSocio.ToString(), entity.TipSocio));
                C.EjecutarSP(ProcSocioCliente.RegistrarSocioCliente.ToString(), ref lst);
                return lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idClientePrincipal, int idClienteSocio)
        {
            throw new NotImplementedException();
        }
    }
}
