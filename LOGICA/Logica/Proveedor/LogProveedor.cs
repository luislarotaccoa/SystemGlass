using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using VERTICAL.Modelos.Proveedor;
using VERTICAL.Modelos.Publico;

namespace LOGICA.Logica.Proveedor
{
    public class LogProveedor : IRepositorio<ModelProveedor>
    {
        Conexion C = new Conexion();

        public List<ModelProveedor> Buscar(List<ModelProveedor> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelProveedor Consulta(int id)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            throw new NotImplementedException();
        }

        public List<ModelProveedor> Listar(object f1, object f2)
        {
            List<Parametros> lst = new List<Parametros>();
            List<ModelProveedor> lista = new List<ModelProveedor>();
            try
            {
                lst.Add(new Parametros(ColProveedor.CodDocumento.ToString(), f2));
                var dt = C.Listado(ProcProveedor.ListarProveedor.ToString(), lst).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelProveedor
                    {
                        IdProveedor = Convert.ToInt32(dt.Rows[i][ColProveedor.IdProveedor.ToString()]),
                        RazonSocial = dt.Rows[i][ColProveedor.RazonSocial.ToString()].ToString(),
                        //CodDocumento = (ModelDocumento)Convert.ToInt32(dt.Rows[i][ColCliente.CodDocumento.ToString()]),
                        Numero = dt.Rows[i][ColProveedor.Numero.ToString()].ToString(),
                        Direccion = dt.Rows[i][ColProveedor.Direccion.ToString()].ToString(),
                        Email = dt.Rows[i][ColProveedor.Email.ToString()].ToString(),
                        Telefono = dt.Rows[i][ColProveedor.Telefono.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dt.Rows[i][ColProveedor.Estado.ToString()]),
                        Departamento = dt.Rows[i][ColProveedor.Departamento.ToString()].ToString(),
                        Provincia = dt.Rows[i][ColProveedor.Provincia.ToString()].ToString(),
                        Distrito = dt.Rows[i][ColProveedor.Distrito.ToString()].ToString(),
                        Ubigeo = dt.Rows[i][ColProveedor.Ubigeo.ToString()].ToString(),
                        IdUbigeo = Convert.ToInt32(dt.Rows[i][ColProveedor.IdUbigeo.ToString()])
                    };
                    u.CodDocumento = (Documento)f2;
                    lista.Add(u);
                }
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Modificar(ModelProveedor entity)
        {
            throw new NotImplementedException();
        }

        public string Registrar(ModelProveedor entity)
        {

            var ListParam = new List<Parametros>();
            try
            {
                ListParam.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                ListParam.Add(new Parametros(ColProveedor.IdProveedor.ToString(), "", SqlDbType.Int, ParameterDirection.Output, 100));
                ListParam.Add(new Parametros(ColProveedor.RazonSocial.ToString(), entity.RazonSocial));
                ListParam.Add(new Parametros(ColProveedor.CodDocumento.ToString(), entity.CodDocumento));
                ListParam.Add(new Parametros(ColProveedor.Numero.ToString(), entity.Numero));
                ListParam.Add(new Parametros(ColProveedor.Direccion.ToString(), entity.Direccion));
                ListParam.Add(new Parametros(ColProveedor.IdUbigeo.ToString(), entity.IdUbigeo));
                ListParam.Add(new Parametros(ColProveedor.Email.ToString(), entity.Email));
                ListParam.Add(new Parametros(ColProveedor.Telefono.ToString(), entity.Telefono));
                C.EjecutarSP(ProcProveedor.RegistrarProveedor.ToString(), ref ListParam);
                string mensaje = ListParam[0].m_Valor.ToString();
                if (mensaje == "1")
                {
                    entity.IdProveedor = Convert.ToInt32(ListParam[1].m_Valor);
                }
                return mensaje;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public ModelProveedor Consulta(string numero, Documento CodDocumento)
        {
            List<Parametros> lst = new List<Parametros>();
            ModelProveedor MProveedor = null;
            try
            {
                lst.Add(new Parametros(ColProveedor.CodDocumento.ToString(), CodDocumento));
                lst.Add(new Parametros(ColProveedor.Numero.ToString(), numero));
                var dt = C.Listado(ProcProveedor.ConsultarProveedor.ToString(), lst).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var dtr = dt.Rows[0];
                    MProveedor = new ModelProveedor
                    {
                        IdProveedor = Convert.ToInt32(dtr[ColProveedor.IdProveedor.ToString()]),
                        RazonSocial = dtr[ColProveedor.RazonSocial.ToString()].ToString(),
                        CodDocumento = (Documento)dtr[ColProveedor.CodDocumento.ToString()],
                        Numero = dtr[ColProveedor.Numero.ToString()].ToString(),
                        Direccion = dtr[ColProveedor.Direccion.ToString()].ToString(),
                        Email = dtr[ColProveedor.Email.ToString()].ToString(),
                        Telefono = dtr[ColProveedor.Telefono.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dtr[ColProveedor.Estado.ToString()]),
                        Departamento = dtr[ColProveedor.Departamento.ToString()].ToString(),
                        Provincia = dtr[ColProveedor.Provincia.ToString()].ToString(),
                        Distrito = dtr[ColProveedor.Distrito.ToString()].ToString(),
                        Ubigeo = dtr[ColProveedor.Ubigeo.ToString()].ToString(),
                        IdUbigeo = Convert.ToInt32(dtr[ColProveedor.IdUbigeo.ToString()])
                    };
                }
                return MProveedor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
