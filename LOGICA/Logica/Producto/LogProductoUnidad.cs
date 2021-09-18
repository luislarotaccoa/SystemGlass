using DATOS;
using LOGICA.Entidades.Producto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VERTICAL.Modelos.Producto;

namespace LOGICA.Logica.Producto
{
    public class LogProductoUnidad : IRepositorio<ModelProductoUnidad>
    {
        Conexion C = new Conexion();
        public string Eliminar(int IdProductoUnidad, bool Estado)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", System.Data.SqlDbType.VarChar, System.Data.ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColProductoUnidad.IdProductoUnidad.ToString(), IdProductoUnidad));
                listParam.Add(new Parametros(ColProductoUnidad.Estado.ToString(), Estado));
                C.EjecutarSP(ProcProductoUnidad.EliminarProductoUnidad.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Modificar(ModelProductoUnidad entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColProductoUnidad.IdProductoUnidad.ToString(), entity.IdProductoUnidad));
                listParam.Add(new Parametros(ColProductoUnidad.IdProducto.ToString(), entity.IdProducto));
                listParam.Add(new Parametros(ColProductoUnidad.IdUnidad.ToString(), entity.IdUnidad));
                listParam.Add(new Parametros(ColProductoUnidad.DescContado.ToString(), entity.DescContado));
                listParam.Add(new Parametros(ColProductoUnidad.DescCredito.ToString(), entity.DescCredito));
                listParam.Add(new Parametros(ColProductoUnidad.PContado.ToString(), entity.PContado));
                listParam.Add(new Parametros(ColProductoUnidad.PCredito.ToString(), entity.PCredito));
                listParam.Add(new Parametros(ColProductoUnidad.Factor.ToString(), entity.Factor));
                listParam.Add(new Parametros(ColProductoUnidad.UnidadBase.ToString(), entity.UnidadBase));
                listParam.Add(new Parametros(ColProductoUnidad.Estado.ToString(), entity.Estado));
                C.EjecutarSP(ProcProductoUnidad.ModificarProductoUnidad.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelProductoUnidad> Buscar(List<ModelProductoUnidad> list, string dato)
        {
            string[] texto = dato.Trim().Split(',');
            List<ModelProductoUnidad> result = list.Where(d =>
            d.Modelo.ToLower().Contains(texto[0].ToLower())
            ).ToList();
            if (texto.Length > 1)
            {
                for (int i = 0; i < texto.Length; i++)
                {
                    if (!string.IsNullOrEmpty(texto[i]))
                    {
                        result = result.Where(d =>
                       d.Modelo.Contains(texto[i])
                        ).ToList();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result;
        }

        public ModelProductoUnidad Consulta(int IdProductoUnidad)
        {
            List<Parametros> listParam = new List<Parametros>();
            ModelProductoUnidad MProductoUnidad = null;
            try
            {
                listParam.Add(new Parametros(ColProductoUnidad.IdProductoUnidad.ToString(), IdProductoUnidad));
                var dt = C.Listado(ProcProductoUnidad.ConsultarProductoUnidad.ToString(), listParam).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var dtr = dt.Rows[0];
                    MProductoUnidad = new ModelProductoUnidad
                    {
                        IdProductoUnidad = Convert.ToInt32(dtr[ColProductoUnidad.IdProductoUnidad.ToString()]),
                        IdProducto = Convert.ToInt32(dtr[ColProductoUnidad.IdProducto.ToString()]),
                        IdUnidad = Convert.ToInt32(dtr[ColProductoUnidad.IdUnidad.ToString()]),
                        Unidad = dtr[ColProductoUnidad.Unidad.ToString()].ToString(),
                        Factor = Convert.ToDecimal(dtr[ColProductoUnidad.Factor.ToString()]),
                        DescContado = Convert.ToDecimal(dtr[ColProductoUnidad.DescContado.ToString()]),
                        DescCredito = Convert.ToDecimal(dtr[ColProductoUnidad.DescCredito.ToString()]),
                        PContado = Convert.ToDecimal(dtr[ColProductoUnidad.PContado.ToString()]),
                        PCredito = Convert.ToDecimal(dtr[ColProductoUnidad.PCredito.ToString()]),
                        UnidadBase = Convert.ToBoolean(dtr[ColProductoUnidad.UnidadBase.ToString()]),
                        Estado = Convert.ToBoolean(dtr[ColProductoUnidad.Estado.ToString()])
                    };
                }
                return MProductoUnidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelProductoUnidad> Listar(object IdProducto, object f2)
        {
            List<Parametros> listParam = new List<Parametros>();
            List<ModelProductoUnidad> ListProductoUnidad = new List<ModelProductoUnidad>();
            try
            {
                listParam.Add(new Parametros(ColProductoUnidad.IdProducto.ToString(), IdProducto));
                var dt = C.Listado(ProcProductoUnidad.ListarProductoUnidad.ToString(), listParam).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var dtr = dt.Rows[i];
                        var MProductoUnidad = new ModelProductoUnidad
                        {
                            IdProductoUnidad = Convert.ToInt32(dtr[ColProductoUnidad.IdProductoUnidad.ToString()]),
                            IdProducto = Convert.ToInt32(dtr[ColProductoUnidad.IdProducto.ToString()]),
                            Modelo= dtr[ColProductoUnidad.Modelo.ToString()].ToString(),
                            IdUnidad = Convert.ToInt32(dtr[ColProductoUnidad.IdUnidad.ToString()]),
                            Unidad = dtr[ColProductoUnidad.Unidad.ToString()].ToString(),
                            Factor = Convert.ToDecimal(dtr[ColProductoUnidad.Factor.ToString()]),
                            DescContado= Convert.ToDecimal(dtr[ColProductoUnidad.DescContado.ToString()]),
                            DescCredito= Convert.ToDecimal(dtr[ColProductoUnidad.DescCredito.ToString()]),
                            PContado = Convert.ToDecimal(dtr[ColProductoUnidad.PContado.ToString()]),
                            PCredito = Convert.ToDecimal(dtr[ColProductoUnidad.PCredito.ToString()]),
                            UnidadBase = Convert.ToBoolean(dtr[ColProductoUnidad.UnidadBase.ToString()]),
                            Estado = Convert.ToBoolean(dtr[ColProductoUnidad.Estado.ToString()])
                        };
                        ListProductoUnidad.Add(MProductoUnidad);
                    }
                }
                return ListProductoUnidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public List<ModelProductoUnidad> Listar()
        {
            List<ModelProductoUnidad> list = new List<ModelProductoUnidad>();
            try
            {
                var dt = C.Listado(ProcProducto.ListarProductos.ToString(), null).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var dtr = dt.Rows[i];
                        var p = new ModelProductoUnidad
                        {
                            IdProducto = Convert.ToInt32(dtr[ColProductoUnidad.IdProducto.ToString()]),
                            Modelo = dtr[ColProductoUnidad.Modelo.ToString()].ToString(),
                            PContado = Convert.ToDecimal(dtr[ColProductoUnidad.PContado.ToString()]),
                            PCredito = Convert.ToDecimal(dtr[ColProductoUnidad.PCredito.ToString()]),
                            Unidad = dtr[ColProductoUnidad.Unidad.ToString()].ToString()
                        };
                        list.Add(p);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public string Registrar(ModelProductoUnidad entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColProductoUnidad.IdProducto.ToString(), entity.IdProducto));
                listParam.Add(new Parametros(ColProductoUnidad.IdUnidad.ToString(), entity.IdUnidad));
                listParam.Add(new Parametros(ColProductoUnidad.DescContado.ToString(), entity.DescContado));
                listParam.Add(new Parametros(ColProductoUnidad.DescCredito.ToString(), entity.DescCredito));
                listParam.Add(new Parametros(ColProductoUnidad.PContado.ToString(), entity.PContado));
                listParam.Add(new Parametros(ColProductoUnidad.PCredito.ToString(), entity.PCredito));
                listParam.Add(new Parametros(ColProductoUnidad.UnidadBase.ToString(), entity.UnidadBase));
                C.EjecutarSP(ProcProductoUnidad.RegistrarProductoUnidad.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        //Registro masivo
        public string Registrar(List<ModelProductoUnidad> lista, int idProducto)
        {
            List<ProductoUnidad> productoUnidadmasivo = new List<ProductoUnidad>();
            for (int j = 0; j < lista.Count; j++)
            {
                var p = new ProductoUnidad();
                p.IdProducto = idProducto;
                p.IdUnidad = lista[j].IdUnidad;
                p.DescContado = lista[j].DescContado;
                p.DescCredito = lista[j].DescCredito;
                p.PContado = lista[j].PContado;
                p.PCredito = lista[j].PCredito;
                p.UnidadBase = lista[j].UnidadBase;
                p.Factor = lista[j].Factor;
                p.Estado = true;
                productoUnidadmasivo.Add(p);

            }
            //Crear una tabla propia
            DataTable table = VERTICAL.Ayudas.Convertir.ConvertToDataTable(productoUnidadmasivo);
            try
            {
                return C.CargaMasiva("ProductoUnidad", table);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
