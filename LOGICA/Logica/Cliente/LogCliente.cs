using DATOS;
using LOGICA.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VERTICAL.Modelos.Cliente;
using VERTICAL.Modelos.Publico;

namespace LOGICA.Logica.Cliente
{
    public class LogCliente : IRepositorio<ModelCliente>
    {
        Conexion C = new Conexion();

        public List<ModelCliente> Buscar(List<ModelCliente> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelCliente Consulta(int id)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColCliente.IdCliente.ToString(), Id));
                lst.Add(new Parametros(ColCliente.Estado.ToString(), !act));
                C.EjecutarSP(ProcCliente.EliminarCliente.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public List<ModelCliente> Listar(object f1, object f2)
        {
            List<Parametros> lst = new List<Parametros>();
            List<ModelCliente> lista = new List<ModelCliente>();
            try
            {
                lst.Add(new Parametros(ColCliente.CodDocumento.ToString(), (int)f1));
                var dt = C.Listado(ProcCliente.ListarCliente.ToString(), lst).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelCliente
                    {
                        IdCliente = Convert.ToInt32(dt.Rows[i][ColCliente.IdCliente.ToString()]),
                        RazSocial = dt.Rows[i][ColCliente.RazSocial.ToString()].ToString(),
                        //CodDocumento = (ModelDocumento)Convert.ToInt32(dt.Rows[i][ColCliente.CodDocumento.ToString()]),
                        NumDocumento = dt.Rows[i][ColCliente.NumDocumento.ToString()].ToString(),
                        Direccion = dt.Rows[i][ColCliente.Direccion.ToString()].ToString(),
                        Email = dt.Rows[i][ColCliente.Email.ToString()].ToString(),
                        Telefono = dt.Rows[i][ColCliente.Telefono.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dt.Rows[i][ColCliente.Estado.ToString()]),
                        Departamento = dt.Rows[i][ColCliente.Departamento.ToString()].ToString(),
                        Provincia = dt.Rows[i][ColCliente.Provincia.ToString()].ToString(),
                        Distrito = dt.Rows[i][ColCliente.Distrito.ToString()].ToString(),
                        Ubigeo = dt.Rows[i][ColCliente.Ubigeo.ToString()].ToString(),
                        IdUbigeo = Convert.ToInt32(dt.Rows[i][ColCliente.IdUbigeo.ToString()])
                    };
                    u.CodDocumento = (Documento)f1;
                    lista.Add(u);
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Modificar(ModelCliente entity)
        {
            var ListParam = new List<Parametros>();
            try
            {
                ListParam.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                ListParam.Add(new Parametros(ColCliente.IdCliente.ToString(), entity.IdCliente));
                ListParam.Add(new Parametros(ColCliente.RazSocial.ToString(), entity.RazSocial));
                ListParam.Add(new Parametros(ColCliente.CodDocumento.ToString(), entity.CodDocumento));
                ListParam.Add(new Parametros(ColCliente.NumDocumento.ToString(), entity.NumDocumento));
                ListParam.Add(new Parametros(ColCliente.Direccion.ToString(), entity.Direccion));
                ListParam.Add(new Parametros(ColCliente.IdUbigeo.ToString(), entity.IdUbigeo));
                ListParam.Add(new Parametros(ColCliente.Email.ToString(), entity.Email));
                ListParam.Add(new Parametros(ColCliente.Telefono.ToString(), entity.Telefono));
                C.EjecutarSP(ProcCliente.ModificarCliente.ToString(), ref ListParam);
                string mensaje = ListParam[0].m_Valor.ToString();
                return mensaje;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Registrar(ModelCliente entity)
        {

            var ListParam = new List<Parametros>();
            try
            {
                ListParam.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                ListParam.Add(new Parametros(ColCliente.IdCliente.ToString(), "", SqlDbType.Int, ParameterDirection.Output, 100));
                ListParam.Add(new Parametros(ColCliente.RazSocial.ToString(), entity.RazSocial));
                ListParam.Add(new Parametros(ColCliente.CodDocumento.ToString(), entity.CodDocumento));
                ListParam.Add(new Parametros(ColCliente.NumDocumento.ToString(), entity.NumDocumento));
                ListParam.Add(new Parametros(ColCliente.Direccion.ToString(), entity.Direccion));
                ListParam.Add(new Parametros(ColCliente.IdUbigeo.ToString(), entity.IdUbigeo));
                ListParam.Add(new Parametros(ColCliente.Email.ToString(), entity.Email));
                ListParam.Add(new Parametros(ColCliente.Telefono.ToString(), entity.Telefono));
                C.EjecutarSP(ProcCliente.RegistrarCliente.ToString(), ref ListParam);
                string mensaje = ListParam[0].m_Valor.ToString();
                if (mensaje == "1")
                {
                    entity.IdCliente = Convert.ToInt32(ListParam[1].m_Valor);
                }
                return mensaje;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public ModelCliente Consulta(string numero, int CodDocumento)
        {
            List<Parametros> lst = new List<Parametros>();
            ModelCliente cModel = null;
            try
            {
                lst.Add(new Parametros(ColCliente.CodDocumento.ToString(), CodDocumento));
                lst.Add(new Parametros(ColCliente.NumDocumento.ToString(), numero));
                var dt = C.Listado(ProcCliente.ConsultarCliente.ToString(), lst).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var dtr = dt.Rows[0];
                    cModel = new ModelCliente
                    {
                        IdCliente = Convert.ToInt32(dtr[ColCliente.IdCliente.ToString()]),
                        RazSocial = dtr[ColCliente.RazSocial.ToString()].ToString(),
                        CodDocumento = (Documento)dtr[ColCliente.CodDocumento.ToString()],
                        NumDocumento = dtr[ColCliente.NumDocumento.ToString()].ToString(),
                        Direccion = dtr[ColCliente.Direccion.ToString()].ToString(),
                        Email = dtr[ColCliente.Email.ToString()].ToString(),
                        Telefono = dtr[ColCliente.Telefono.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dtr[ColCliente.Estado.ToString()]),
                        Departamento = dtr[ColCliente.Departamento.ToString()].ToString(),
                        Provincia = dtr[ColCliente.Provincia.ToString()].ToString(),
                        Distrito = dtr[ColCliente.Distrito.ToString()].ToString(),
                        Ubigeo = dtr[ColCliente.Ubigeo.ToString()].ToString(),
                        IdUbigeo = Convert.ToInt32(dtr[ColCliente.IdUbigeo.ToString()])
                    };
                }
                return cModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
