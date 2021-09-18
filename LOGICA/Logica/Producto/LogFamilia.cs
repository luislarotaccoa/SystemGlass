using DATOS;
using LOGICA.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VERTICAL.Modelos.Producto;

namespace LOGICA.Logica.Producto
{
    public class LogFamilia : IRepositorio<ModelFamilia>
    {
        Conexion C = new Conexion();
        public string Modificar(ModelFamilia entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                lst.Add(new Parametros(ColFamilia.IdFamilia.ToString(), entity.IdFamilia));
                lst.Add(new Parametros(ColFamilia.NomFamilia.ToString(), entity.NomFamilia));
                lst.Add(new Parametros(ColFamilia.IdCategoria.ToString(), entity.IdCategoria));
                C.EjecutarSP(ProcFamilia.ModificarFamilia.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
                return Mensaje;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public string Eliminar(int Id, bool act)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 50));
                lst.Add(new Parametros(ColFamilia.IdFamilia.ToString(), Id));
                lst.Add(new Parametros(ColFamilia.Estado.ToString(), act));
                C.EjecutarSP(ProcFamilia.EliminarFamilia.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
                return Mensaje;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public ModelFamilia Consulta(int IdFamilia)
        {
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros("@" + ColFamilia.IdFamilia, IdFamilia));
                var dt = C.Listado(ProcFamilia.ConsultarFamilia.ToString(), lst).Tables[0];
                var r = dt.Rows[0];
                return new ModelFamilia
                {
                    IdFamilia = Convert.ToInt32(r[ColFamilia.IdFamilia.ToString()]),
                    NomFamilia = r[ColFamilia.NomFamilia.ToString()].ToString(),
                    Estado = Convert.ToBoolean(r[ColFamilia.Estado.ToString()]),
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public string Registrar(ModelFamilia entity)
        {
            List<Parametros> lst = new List<Parametros>();
            string Mensaje = "";
            try
            {
                lst.Add(new Parametros("@Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                lst.Add(new Parametros(ColFamilia.NomFamilia.ToString(), entity.NomFamilia));
                lst.Add(new Parametros(ColFamilia.IdCategoria.ToString(), entity.IdCategoria));
                C.EjecutarSP(ProcFamilia.RegistrarFamilia.ToString(), ref lst);
                Mensaje = lst[0].m_Valor.ToString();
                return Mensaje;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public List<ModelFamilia> Listar(object f1, object f2)
        {
            List<ModelFamilia> lista = new List<ModelFamilia>();
            try
            {
                var dt = C.Listado(ProcFamilia.ListarFamilia.ToString(), null).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelFamilia
                    {
                        IdFamilia = Convert.ToInt32(dt.Rows[i][ColFamilia.IdFamilia.ToString()]),
                        IdCategoria = Convert.ToInt32(dt.Rows[i][ColFamilia.IdCategoria.ToString()]),
                        NomFamilia = dt.Rows[i][ColFamilia.NomFamilia.ToString()].ToString(),
                        NomCategoria = dt.Rows[i][ColFamilia.NomCategoria.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dt.Rows[i][ColFamilia.Estado.ToString()]),
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
        public List<ModelFamilia> Listar(int IdCat)
        {
            List<ModelFamilia> lista = new List<ModelFamilia>();
            List<Parametros> lst = new List<Parametros>();
            try
            {
                lst.Add(new Parametros(ColFamilia.IdCategoria.ToString(), IdCat));
                var dt = C.Listado(ProcFamilia.ListarFamilia.ToString(), lst).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelFamilia
                    {
                        IdFamilia = Convert.ToInt32(dt.Rows[i][ColFamilia.IdFamilia.ToString()]),
                        IdCategoria = Convert.ToInt32(dt.Rows[i][ColFamilia.IdCategoria.ToString()]),
                        NomFamilia = dt.Rows[i][ColFamilia.NomFamilia.ToString()].ToString(),
                        NomCategoria = dt.Rows[i][ColFamilia.NomCategoria.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dt.Rows[i][ColFamilia.Estado.ToString()]),
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
        public List<ModelFamilia> Buscar(List<ModelFamilia> list, string dato)
        {
            List<ModelFamilia> result = list.Where(d =>
           d.NomFamilia.ToLower().Contains(dato.ToLower())).ToList();
            return result;
        }
    }
}
