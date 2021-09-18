using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using VERTICAL.Modelos.Empleado;
using VERTICAL.Modelos.Publico;

namespace LOGICA.Logica.Empleado
{
    public class LogEmpleado : IRepositorio<ModelEmpleado>
    {
        Conexion C = new Conexion();
        public List<ModelEmpleado> Buscar(List<ModelEmpleado> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelEmpleado Consulta(int id)
        {
            List<Parametros> lst = new List<Parametros>();
            ModelEmpleado eModel = null;
            try
            {
                lst.Add(new Parametros(ColEmpleado.IdEmpleado.ToString(), id));
                var dt = C.Listado(ProcEmpleado.ConsultarEmpleado.ToString(), lst).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var dtr = dt.Rows[0];
                    eModel = new ModelEmpleado
                    {
                        IdEmpleado = Convert.ToInt32(dtr[ColEmpleado.IdEmpleado.ToString()]),
                        Nombres = dtr[ColEmpleado.Nombres.ToString()].ToString(),
                        Apellidos = dtr[ColEmpleado.Apellidos.ToString()].ToString(),
                        CodDocumento = (Documento)dtr[ColEmpleado.CodDocumento.ToString()],
                        NumDocumento = dtr[ColEmpleado.NumDocumento.ToString()].ToString(),
                        Sexo = (Sexo)dtr[ColEmpleado.Sexo.ToString()],
                        FechaNacimiento = Convert.ToDateTime(dtr[ColEmpleado.FechaNacimiento.ToString()].ToString()),
                        Direccion = dtr[ColEmpleado.Direccion.ToString()].ToString(),
                        IdUbigeo = Convert.ToInt32(dtr[ColEmpleado.IdUbigeo.ToString()]),
                        Departamento = dtr[ColEmpleado.Departamento.ToString()].ToString(),
                        Provincia = dtr[ColEmpleado.Provincia.ToString()].ToString(),
                        Distrito = dtr[ColEmpleado.Distrito.ToString()].ToString(),
                        Ubigeo = dtr[ColEmpleado.Ubigeo.ToString()].ToString(),
                        EstCivil = dtr[ColEmpleado.EstCivil.ToString()].ToString(),
                        Email = dtr[ColEmpleado.Email.ToString()].ToString(),
                        Especialidad = dtr[ColEmpleado.Especialidad.ToString()].ToString(),
                        Telefono = dtr[ColEmpleado.Telefono.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dtr[ColEmpleado.Estado.ToString()])
                    };
                }
                return eModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Eliminar(int Id, bool act)
        {
            throw new NotImplementedException();
        }

        public List<ModelEmpleado> Listar(object f1, object f2)
        {
            List<Parametros> lst = new List<Parametros>();
            List<ModelEmpleado> lista = new List<ModelEmpleado>();
            try
            {
                lst.Add(new Parametros(ColEmpleado.CodDocumento.ToString(), (int)f1));
                var dt = C.Listado(ProcEmpleado.ListarEmpleado.ToString(), lst).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var dtr = dt.Rows[i];
                    var u = new ModelEmpleado
                    {
                        IdEmpleado = Convert.ToInt32(dtr[ColEmpleado.IdEmpleado.ToString()]),
                        Nombres = dtr[ColEmpleado.Nombres.ToString()].ToString(),
                        Apellidos = dtr[ColEmpleado.Apellidos.ToString()].ToString(),
                        NumDocumento = dtr[ColEmpleado.NumDocumento.ToString()].ToString(),
                        Sexo = (Sexo)dtr[ColEmpleado.Sexo.ToString()],
                        FechaNacimiento = Convert.ToDateTime(dtr[ColEmpleado.FechaNacimiento.ToString()].ToString()),
                        Direccion = dtr[ColEmpleado.Direccion.ToString()].ToString(),
                        IdUbigeo = Convert.ToInt32(dtr[ColEmpleado.IdUbigeo.ToString()]),
                        Departamento = dtr[ColEmpleado.Departamento.ToString()].ToString(),
                        Provincia = dtr[ColEmpleado.Provincia.ToString()].ToString(),
                        Distrito = dtr[ColEmpleado.Distrito.ToString()].ToString(),
                        Ubigeo = dtr[ColEmpleado.Ubigeo.ToString()].ToString(),
                        EstCivil = dtr[ColEmpleado.EstCivil.ToString()].ToString(),
                        Email = dtr[ColEmpleado.Email.ToString()].ToString(),
                        Especialidad = dtr[ColEmpleado.Especialidad.ToString()].ToString(),
                        Telefono = dtr[ColEmpleado.Telefono.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dtr[ColEmpleado.Estado.ToString()])
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
        public ModelEmpleado Consulta(string numero, Documento CodDocumento)
        {
            List<Parametros> lst = new List<Parametros>();
            ModelEmpleado eModel = null;
            try
            {
                lst.Add(new Parametros(ColEmpleado.CodDocumento.ToString(), CodDocumento));
                lst.Add(new Parametros(ColEmpleado.NumDocumento.ToString(), numero));
                var dt = C.Listado(ProcEmpleado.ConsultaEmpleado.ToString(), lst).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var dtr = dt.Rows[0];
                    eModel = new ModelEmpleado
                    {
                        IdEmpleado = Convert.ToInt32(dtr[ColEmpleado.IdEmpleado.ToString()])
                    };
                }
                return eModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public string Modificar(ModelEmpleado entity)
        {
            var ListParam = new List<Parametros>();
            try
            {
                ListParam.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                ListParam.Add(new Parametros(ColEmpleado.IdEmpleado.ToString(), entity.IdEmpleado));
                ListParam.Add(new Parametros(ColEmpleado.Apellidos.ToString(), entity.Apellidos));
                ListParam.Add(new Parametros(ColEmpleado.Nombres.ToString(), entity.Nombres));
                ListParam.Add(new Parametros(ColEmpleado.CodDocumento.ToString(), entity.CodDocumento));
                ListParam.Add(new Parametros(ColEmpleado.NumDocumento.ToString(), entity.NumDocumento));
                ListParam.Add(new Parametros(ColEmpleado.Sexo.ToString(), entity.Sexo));
                ListParam.Add(new Parametros(ColEmpleado.FechaNacimiento.ToString(), entity.FechaNacimiento));
                ListParam.Add(new Parametros(ColEmpleado.Direccion.ToString(), entity.Direccion));
                ListParam.Add(new Parametros(ColEmpleado.IdUbigeo.ToString(), entity.IdUbigeo));
                ListParam.Add(new Parametros(ColEmpleado.EstCivil.ToString(), entity.EstCivil));
                ListParam.Add(new Parametros(ColEmpleado.Email.ToString(), entity.Email));
                ListParam.Add(new Parametros(ColEmpleado.Especialidad.ToString(), entity.Especialidad));
                ListParam.Add(new Parametros(ColEmpleado.Telefono.ToString(), entity.Telefono));
                C.EjecutarSP(ProcEmpleado.ModificarEmpleado.ToString(), ref ListParam);
                string mensaje = ListParam[0].m_Valor.ToString();
                
                return mensaje;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Registrar(ModelEmpleado entity)
        {
            var ListParam = new List<Parametros>();
            try
            {
                ListParam.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                ListParam.Add(new Parametros(ColEmpleado.IdEmpleado.ToString(), "", SqlDbType.Int, ParameterDirection.Output, 100));
                ListParam.Add(new Parametros(ColEmpleado.Apellidos.ToString(), entity.Apellidos));
                ListParam.Add(new Parametros(ColEmpleado.Nombres.ToString(), entity.Nombres));
                ListParam.Add(new Parametros(ColEmpleado.CodDocumento.ToString(), entity.CodDocumento));
                ListParam.Add(new Parametros(ColEmpleado.NumDocumento.ToString(), entity.NumDocumento));
                ListParam.Add(new Parametros(ColEmpleado.Sexo.ToString(), entity.Sexo));
                ListParam.Add(new Parametros(ColEmpleado.FechaNacimiento.ToString(), entity.FechaNacimiento));
                ListParam.Add(new Parametros(ColEmpleado.Direccion.ToString(), entity.Direccion));
                ListParam.Add(new Parametros(ColEmpleado.IdUbigeo.ToString(), entity.IdUbigeo));
                ListParam.Add(new Parametros(ColEmpleado.EstCivil.ToString(), entity.EstCivil));
                ListParam.Add(new Parametros(ColEmpleado.Email.ToString(), entity.Email));
                ListParam.Add(new Parametros(ColEmpleado.Especialidad.ToString(), entity.Especialidad));
                ListParam.Add(new Parametros(ColEmpleado.Telefono.ToString(), entity.Telefono));
                C.EjecutarSP(ProcEmpleado.RegistrarEmpleado.ToString(), ref ListParam);
                string mensaje = ListParam[0].m_Valor.ToString();
                if (mensaje == "1")
                {
                    entity.IdEmpleado = Convert.ToInt32(ListParam[1].m_Valor);
                }
                return mensaje;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
