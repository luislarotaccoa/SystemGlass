using DATOS;
using LOGICA.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using VERTICAL.Modelos.Cliente;

namespace LOGICA.Logica.Cliente
{
    public class LogDireccion : IRepositorio<ModelDireccion>
    {
        Conexion C = new Conexion();

        public List<ModelDireccion> Buscar(List<ModelDireccion> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelDireccion Consulta(int id)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            throw new NotImplementedException();
        }

        public List<ModelDireccion> Listar(object f1, object f2)
        {
            List<Parametros> lst = new List<Parametros>();
            var list = new List<ModelDireccion>();
            try
            {
                lst.Add(new Parametros(ColDireccion.IdCliente.ToString(), f1));
                var dt = C.Listado(ProcDireccion.ListarDireccion.ToString(), lst).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var dr = dt.Rows[i];
                    var d = new ModelDireccion()
                    {
                        IdDireccion = Convert.ToInt32(dr[ColDireccion.IdDireccion.ToString()]),
                        IdUbigeo = Convert.ToInt32(dr[ColDireccion.IdUbigeo.ToString()]),
                        NombreDireccion = dr[ColDireccion.NombreDireccion.ToString()].ToString(),
                        Departamento = dr[ColDireccion.Departamento.ToString()].ToString(),
                        Provincia = dr[ColDireccion.Provincia.ToString()].ToString(),
                        Distrito = dr[ColDireccion.Distrito.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dr[ColDireccion.Estado.ToString()])
                    };
                    list.Add(d);
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Modificar(ModelDireccion entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColDireccion.IdDireccion.ToString(), entity.IdDireccion));
                lst.Add(new Parametros(ColDireccion.NombreDireccion.ToString(), entity.NombreDireccion));
                lst.Add(new Parametros(ColDireccion.IdUbigeo.ToString(), entity.IdUbigeo));
                C.EjecutarSP(ProcDireccion.ModificarDireccion.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public string Registrar(ModelDireccion entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColDireccion.NombreDireccion.ToString(), entity.NombreDireccion));
                lst.Add(new Parametros(ColDireccion.IdUbigeo.ToString(), entity.IdUbigeo));
                lst.Add(new Parametros(ColDireccion.IdCliente.ToString(), entity.IdCliente));
                C.EjecutarSP(ProcDireccion.RegistrarDireccion.ToString(), ref lst);
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
