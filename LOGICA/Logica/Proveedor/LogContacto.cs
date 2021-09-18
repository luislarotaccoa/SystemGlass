using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using VERTICAL.Modelos.Proveedor;

namespace LOGICA.Logica.Proveedor
{
    public class LogContacto : IRepositorio<ModelContacto>
    {
        Conexion C = new Conexion();

        public List<ModelContacto> Buscar(List<ModelContacto> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelContacto Consulta(int id)
        {
            throw new NotImplementedException();
            //implementar
        }

        public string Eliminar(int Id, bool act)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColContacto.IdContacto.ToString(), Id));
                C.EjecutarSP(ProcContacto.EliminarContacto.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public List<ModelContacto> Listar(object f1, object f2)
        {
            List<Parametros> lst = new List<Parametros>();
            var list = new List<ModelContacto>();
            try
            {
                lst.Add(new Parametros(ColContacto.IdProveedor.ToString(), f1));
                var dt = C.Listado(ProcContacto.ListarContacto.ToString(), lst).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var dr = dt.Rows[i];
                    var d = new ModelContacto()
                    {
                        IdContacto = Convert.ToInt32(dr[ColContacto.IdContacto.ToString()]),
                        IdProveedor = Convert.ToInt32(dr[ColContacto.IdProveedor.ToString()]),
                        Nombres = dr[ColContacto.Nombres.ToString()].ToString(),
                        Area = dr[ColContacto.Area.ToString()].ToString(),
                        Email = dr[ColContacto.Email.ToString()].ToString(),
                        Telefono = dr[ColContacto.Telefono.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dr[ColContacto.Estado.ToString()])
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

        public string Modificar(ModelContacto entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColContacto.IdContacto.ToString(), entity.IdContacto));
                lst.Add(new Parametros(ColContacto.IdProveedor.ToString(), entity.IdProveedor));
                lst.Add(new Parametros(ColContacto.Nombres.ToString(), entity.Nombres));
                lst.Add(new Parametros(ColContacto.Area.ToString(), entity.Area));
                lst.Add(new Parametros(ColContacto.Email.ToString(), entity.Email));
                lst.Add(new Parametros(ColContacto.Telefono.ToString(), entity.Telefono));
                C.EjecutarSP(ProcContacto.ModificarContacto.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Mensaje;
        }

        public string Registrar(ModelContacto entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColContacto.IdProveedor.ToString(), entity.IdProveedor));
                lst.Add(new Parametros(ColContacto.Nombres.ToString(), entity.Nombres));
                lst.Add(new Parametros(ColContacto.Area.ToString(), entity.Area));
                lst.Add(new Parametros(ColContacto.Email.ToString(), entity.Email));
                lst.Add(new Parametros(ColContacto.Telefono.ToString(), entity.Telefono));
                C.EjecutarSP(ProcContacto.RegistrarContacto.ToString(), ref lst);
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
