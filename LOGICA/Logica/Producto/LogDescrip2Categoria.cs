using DATOS;
using System;
using System.Collections.Generic;
using VERTICAL.Modelos.Producto;

namespace LOGICA.Logica.Producto
{
    public class LogDescrip2Categoria : IRepositorio<ModelDescrip2>
    {
        Conexion C = new Conexion();
        public string Modificar(ModelDescrip2 entity)
        {
            throw new NotImplementedException();
        }

        public List<ModelDescrip2> Buscar(List<ModelDescrip2> list, string dato)
        {
            throw new NotImplementedException();
        }

        public ModelDescrip2 Consulta(int id)
        {
            throw new NotImplementedException();
        }

        public string Eliminar(int Id, bool act)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", System.Data.SqlDbType.VarChar, System.Data.ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColDescrip2.IdDescrip2.ToString(), Id));
                C.EjecutarSP(ProcDescrip2.EliminarDescrip2.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelDescrip2> Listar(object IdCategoria, object f2)
        {
            var listDescripcion = new List<ModelDescrip2>();
            try
            {
                var dt = C.Listado(ProcDescrip2.ListarDescrip2.ToString(), null).Tables[0];
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var rw = dt.Rows[i];
                        var descrip = new ModelDescrip2
                        {
                            IdDescrip2 = Convert.ToInt32(rw[ColDescrip2.IdDescrip2.ToString()]),
                            Descripcion = rw[ColDescrip2.Descripcion.ToString()].ToString(),
                            Estado = Convert.ToBoolean(rw[ColDescrip2.Estado.ToString()])
                        };
                        listDescripcion.Add(descrip);
                    }
                }
                return listDescripcion;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelDescrip2> Listar(int IdCategoria)
        {
            var listParam = new List<Parametros>();
            var listDescripcion = new List<ModelDescrip2>();
            try
            {
                listParam.Add(new Parametros(ColDescrip2.IdCategoria.ToString(), IdCategoria));
                var dt = C.Listado(ProcDescrip2.ListarCategoriaDescrip2.ToString(), listParam).Tables[0];
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var rw = dt.Rows[i];
                        var descrip = new ModelDescrip2
                        {
                            IdCategoria = Convert.ToInt32(rw[ColDescrip2.IdCategoria.ToString()]),
                            IdDescrip2 = Convert.ToInt32(rw[ColDescrip2.IdDescrip2.ToString()]),
                            Descripcion = rw[ColDescrip2.Descripcion.ToString()].ToString(),
                            NomCategoria = rw[ColDescrip2.NomCategoria.ToString()].ToString(),
                            Estado = Convert.ToBoolean(rw[ColDescrip2.Estado.ToString()])
                        };
                        listDescripcion.Add(descrip);
                    }
                }
                return listDescripcion;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public string Registrar(ModelDescrip2 entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje","",System.Data.SqlDbType.VarChar,System.Data.ParameterDirection.Output,100));
                listParam.Add(new Parametros(ColDescrip2.IdCategoria.ToString(),entity.IdCategoria));
                listParam.Add(new Parametros(ColDescrip2.IdDescrip2.ToString(),entity.IdDescrip2));
                C.EjecutarSP(ProcDescrip2.RegistrarCategoriaDescrip2.ToString(),ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message,e);
            }
        }
    }
}
