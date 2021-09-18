using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using VERTICAL.Modelos.ESProducto;
using VERTICAL.Modelos.Producto;

namespace LOGICA.Logica.Producto
{
    public class LogProducto : IRepositorio<ModelProducto>
    {
        Conexion C = new Conexion();
        public string Eliminar(int IdProducto, bool Estado)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColProducto.IdProducto.ToString(), IdProducto));
                listParam.Add(new Parametros(ColProducto.Estado.ToString(), Estado));
                C.EjecutarSP(ProcProducto.EliminarProducto.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public string Modificar(ModelProducto entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColProducto.IdProducto.ToString(), entity.IdProducto));
                listParam.Add(new Parametros(ColProducto.Serie2.ToString(), entity.Serie2));
                listParam.Add(new Parametros(ColProducto.Modelo.ToString(), entity.Modelo));
                listParam.Add(new Parametros(ColProducto.IdDescrip1.ToString(), entity.IdDescrip1));
                listParam.Add(new Parametros(ColProducto.IdDescrip2.ToString(), entity.IdDescrip2));
                listParam.Add(new Parametros(ColProducto.IdColor.ToString(), entity.IdColor));
                listParam.Add(new Parametros(ColProducto.Peso.ToString(), entity.Peso));
                listParam.Add(new Parametros(ColProducto.Estado.ToString(), entity.Estado));
                C.EjecutarSP(ProcProducto.ModificarProducto.ToString(), ref listParam);
                return listParam[0].m_Valor.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelProducto> Buscar(List<ModelProducto> list, string dato)
        {
            string[] texto = dato.Trim().Split(',');
            List<ModelProducto> result = list.Where(d =>
            d.Modelo.ToLower().Contains(texto[0].ToLower())
            || d.Descripcion.ToLower().Contains(texto[0].ToLower())
            || d.Categoria.ToLower().Contains(texto[0].ToLower())
            || d.Color.ToLower().Contains(texto[0].ToLower())
            ).ToList();
            if (texto.Length > 1)
            {
                for (int i = 0; i < texto.Length; i++)
                {
                    if (!string.IsNullOrEmpty(texto[i]))
                    {
                        result = result.Where(d =>
                        d.Modelo.Contains(texto[i])
                        || d.Descripcion.Contains(texto[i])
                        || d.Categoria.Contains(texto[i])
                        || d.Color.Contains(texto[i])
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

        public ModelProducto Consulta(int IdProducto)
        {
            List<Parametros> listParam = new List<Parametros>();
            ModelProducto MProducto = null;
            try
            {
                listParam.Add(new Parametros(ColProducto.IdProducto.ToString(), IdProducto));
                var dt = C.Listado(ProcProducto.ConsultaProducto.ToString(), listParam).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    var dtr = dt.Rows[0];
                    MProducto = new ModelProducto
                    {
                        IdProducto = Convert.ToInt32(dtr[ColProducto.IdProducto.ToString()]),
                        IdCategoria = Convert.ToInt32(dtr[ColProducto.IdCategoria.ToString()]),
                        IdDescrip1 = Convert.ToInt32(dtr[ColProducto.IdDescrip1.ToString()]),
                        IdDescrip2 = Convert.ToInt32(dtr[ColProducto.IdDescrip2.ToString()]),
                        IdColor = Convert.ToInt32(dtr[ColProducto.IdColor.ToString()]),
                        Categoria = dtr[ColProducto.Categoria.ToString()].ToString(),
                        Bilateral = Convert.ToBoolean(dtr[ColProducto.Bilateral.ToString()]),
                        Color = dtr[ColProducto.Color.ToString()].ToString(),
                        Modelo = dtr[ColProducto.Modelo.ToString()].ToString(),
                        Descripcion1 = dtr[ColProducto.Descripcion1.ToString()].ToString(),
                        Descripcion2 = dtr[ColProducto.Descripcion2.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dtr[ColProducto.Estado.ToString()])
                    };
                }
                return MProducto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelProducto> Consulta(int idCategoria, int serie2, int idColor)
        {
            var lst = new List<Parametros>();
            DataTable dt;
            var list = new List<ModelProducto>();
            try
            {
                lst.Add(new Parametros(ColProducto.IdCategoria.ToString(), idCategoria));
                lst.Add(new Parametros(ColProducto.Serie2.ToString(), serie2));
                lst.Add(new Parametros(ColProducto.IdColor.ToString(), idColor));
                dt = C.Listado(ProcProducto.ConsultaProducto.ToString(),lst).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelProducto
                    {
                        IdProducto = Convert.ToInt32(dt.Rows[i][ColProducto.IdProducto.ToString()]),
                        IdDescrip1 = Convert.ToInt32(dt.Rows[i][ColProducto.IdDescrip1.ToString()]),
                        IdDescrip2 = Convert.ToInt32(dt.Rows[i][ColProducto.IdDescrip2.ToString()]),
                        IdColor = Convert.ToInt32(dt.Rows[i][ColProducto.IdColor.ToString()]),
                        IdUnidad = Convert.ToInt32(dt.Rows[i][ColProducto.IdUnidad.ToString()]),
                        IdCategoria = Convert.ToInt32(dt.Rows[i][ColProducto.IdCategoria.ToString()]),
                        IdFamilia = Convert.ToInt32(dt.Rows[i][ColProducto.IdFamilia.ToString()]),
                        Peso = Convert.ToDecimal(dt.Rows[i][ColProducto.Peso.ToString()]),
                        Unidad = dt.Rows[i][ColProducto.Unidad.ToString()].ToString(),
                        Categoria = dt.Rows[i][ColProducto.Categoria.ToString()].ToString(),
                        Familia = dt.Rows[i][ColProducto.Familia.ToString()].ToString(),
                        Descripcion1 = dt.Rows[i][ColProducto.Descripcion1.ToString()].ToString(),
                        Descripcion2 = dt.Rows[i][ColProducto.Descripcion2.ToString()].ToString(),
                        Serie2 = Convert.ToInt32(dt.Rows[i][ColProducto.Serie2.ToString()]),
                        Modelo = dt.Rows[i][ColProducto.Modelo.ToString()].ToString(),
                        Color = dt.Rows[i][ColProducto.Color.ToString()].ToString(),
                        Estado = Convert.ToBoolean(dt.Rows[i][ColProducto.Estado.ToString()]),
                        Bilateral = Convert.ToBoolean(dt.Rows[i][ColProducto.Bilateral.ToString()]),
                    };
                    list.Add(u);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        
        public List<ModelProducto> Listar(object f1, object f2)
        {
            List<ModelProducto> list = new List<ModelProducto>();
            try
            {
                var dt = C.Listado(ProcProducto.ListarProductos.ToString(), null).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var dtr = dt.Rows[i];
                        var p = new ModelProducto
                        {
                            IdProducto = Convert.ToInt32(dtr[ColProducto.IdProducto.ToString()]),
                            IdCategoria = Convert.ToInt32(dtr[ColProducto.IdCategoria.ToString()]),
                            IdDescrip1 = Convert.ToInt32(dtr[ColProducto.IdDescrip1.ToString()]),
                            IdDescrip2 = Convert.ToInt32(dtr[ColProducto.IdDescrip2.ToString()]),
                            IdColor = Convert.ToInt32(dtr[ColProducto.IdColor.ToString()]),
                            Categoria = dtr[ColProducto.Categoria.ToString()].ToString(),
                            Bilateral = Convert.ToBoolean(dtr[ColProducto.Bilateral.ToString()]),
                            Color = dtr[ColProducto.Color.ToString()].ToString(),
                            Modelo = dtr[ColProducto.Modelo.ToString()].ToString(),
                            Descripcion1 = dtr[ColProducto.Descripcion1.ToString()].ToString(),
                            Descripcion2 = dtr[ColProducto.Descripcion2.ToString()].ToString(),
                            //Estado = Convert.ToBoolean(dtr[ColProducto.Estado.ToString()])
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
        public List<ModelProducto> ListaConsulta()
        {
            var lista = new List<ModelProducto>();
            try
            {
                var dt = C.Listado(ProcProducto.ListarProductoConsulta.ToString(), null).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelProducto
                    {
                        IdProducto = Convert.ToInt32(dt.Rows[i][ColProducto.IdProducto.ToString()]),
                        IdCategoria = Convert.ToInt32(dt.Rows[i][ColProducto.IdCategoria.ToString()]),
                        Serie2 = Convert.ToInt32(dt.Rows[i][ColProducto.Serie2.ToString()]),
                        IdColor = Convert.ToInt32(dt.Rows[i][ColProducto.IdColor.ToString()]),
                        Modelo = dt.Rows[i][ColProducto.Modelo.ToString()].ToString(),
                        Bilateral = Convert.ToBoolean(dt.Rows[i][ColProducto.Bilateral.ToString()]),
                        Descripcion1 = dt.Rows[i][ColProducto.Descripcion1.ToString()].ToString(),
                        Descripcion2 = dt.Rows[i][ColProducto.Descripcion2.ToString()].ToString(),
                        Color = dt.Rows[i][ColProducto.Color.ToString()].ToString(),
                        Categoria = dt.Rows[i][ColProducto.Categoria.ToString()].ToString(),
                        IdUnidad = Convert.ToInt32(dt.Rows[i][ColProducto.IdUnidad.ToString()]),
                        Unidad = dt.Rows[i][ColProducto.Unidad.ToString()].ToString(),
                        Precio = Convert.ToDecimal(dt.Rows[i][ColProducto.Precio.ToString()]),
                        Factor = Convert.ToDecimal(dt.Rows[i][ColProducto.Factor.ToString()])
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
        public string Registrar(ModelProducto entity)
        {
            var listParam = new List<Parametros>();
            try
            {
                listParam.Add(new Parametros("Mensaje", "", SqlDbType.VarChar, ParameterDirection.Output, 100));
                listParam.Add(new Parametros(ColProducto.IdProducto.ToString(),"",SqlDbType.Int,ParameterDirection.Output,11));
                listParam.Add(new Parametros(ColProducto.Serie2.ToString(), entity.Serie2));
                listParam.Add(new Parametros(ColProducto.Modelo.ToString(), entity.Modelo));
                listParam.Add(new Parametros(ColProducto.IdDescrip1.ToString(), entity.IdDescrip1));
                listParam.Add(new Parametros(ColProducto.IdDescrip2.ToString(), entity.IdDescrip2));
                listParam.Add(new Parametros(ColProducto.IdColor.ToString(), entity.IdColor));
                listParam.Add(new Parametros(ColProducto.IdUnidad.ToString(), entity.IdUnidad));
                listParam.Add(new Parametros(ColProducto.Peso.ToString(), entity.Peso));
                C.EjecutarSP(ProcProducto.RegistrarProducto.ToString(), ref listParam);
                string mensaje= listParam[0].m_Valor.ToString();
                if (mensaje=="1")
                {
                    entity.IdProducto = Convert.ToInt32(listParam[1].m_Valor);
                }
                return mensaje;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<ModelEstadoProducto> ListarEstados(int idProducto, decimal factor)
        {
            var listParam = new List<Parametros>();
            var lista = new List<ModelEstadoProducto>();
            try
            {
                listParam.Add(new Parametros(ColProducto.IdProducto.ToString(), idProducto));
                var dt = C.Listado(ProcProducto.ListarEstados.ToString(), listParam).Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelEstadoProducto(factor)
                    {
                        IdAlmacen = Convert.ToInt32(dt.Rows[i][ColEstados.IdAlmacen.ToString()]),
                        IdUnidad = Convert.ToInt32(dt.Rows[i][ColEstados.IdUnidad.ToString()]),
                        Cantidad = Convert.ToDecimal(dt.Rows[i][ColEstados.Cantidad.ToString()]),
                        Factor = Convert.ToDecimal(dt.Rows[i][ColEstados.Factor.ToString()]),
                        Movimiento = Convert.ToInt32(dt.Rows[i][ColEstados.Movimiento.ToString()]),
                        Direccion = Convert.ToBoolean(dt.Rows[i][ColEstados.Direccion.ToString()]),
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

        public bool Existe(ModelProducto p)
        {
            try
            {
                var dt = C.Listado(ProcProducto.ListarProducto.ToString(), null).Tables[0];
                int idCat = p.IdCategoria;
                DataRow[] dr = dt.Select(ColCategoria.IdCategoria + " = " + idCat);
                if (dr != null)
                {
                    if (dr.Length > 0)
                    {
                        DataTable dt2 = dt.Clone();
                        dt2 = dr.CopyToDataTable();
                        //Si ya existe el producto
                        DataRow[] dr1 = dt2.Select(ColProducto.IdDescrip1 + " = " + p.IdDescrip1 + " and " + ColProducto.IdDescrip2 + " = " + p.IdDescrip2 + " and " + ColProducto.IdColor + " = " + p.IdColor);
                        if (dr1 != null && dr1.Length > 0)
                        {
                            p.Serie2 = Convert.ToInt32(dr1[0][ColProducto.Serie2.ToString()]);
                            return true;
                        }
                        else
                        {
                            //Si se encuentra des1 and des2 pero color es distinto
                            DataRow[] dr2 = dt2.Select(ColProducto.IdDescrip1 + " = " + p.IdDescrip1 + " and " + ColProducto.IdDescrip2 + " = " + p.IdDescrip2 + " and " + ColColor.IdColor + " <> " + p.IdColor);
                            if (dr2 != null && dr2.Length > 0)
                            {
                                p.Serie2 = Convert.ToInt32(dr2[0][ColProducto.Serie2.ToString()]);
                                return false;
                            }
                            else
                            {
                                int serie2 = Convert.ToInt32(dt2.Compute("Max(" + ColProducto.Serie2 + ")", "")) + 1;
                                p.Serie2 = serie2;
                                return false;
                            }
                        }
                    }
                    else
                    {
                        p.Serie2 = 1;
                        return false;
                    }
                }
                else
                {
                    p.Serie2 = 1;
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public List<ModelEstadoProducto> Estados(int idProducto, decimal factor)
        {
            var listParam = new List<Parametros>();
            var lista = new List<ModelEstadoProducto>();
            try
            {
                listParam.Add(new Parametros("@" + ColProducto.IdProducto.ToString(), idProducto));

                var dt = C.Listado(ProcProducto.ListarEstados.ToString(), listParam).Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new ModelEstadoProducto(factor)
                    {
                        IdAlmacen = Convert.ToInt32(dt.Rows[i][ColEstados.IdAlmacen.ToString()]),
                        IdUnidad = Convert.ToInt32(dt.Rows[i][ColEstados.IdUnidad.ToString()]),
                        Cantidad = Convert.ToDecimal(dt.Rows[i][ColEstados.Cantidad.ToString()]),
                        Factor = Convert.ToDecimal(dt.Rows[i][ColEstados.Factor.ToString()]),
                        Movimiento = Convert.ToInt32(dt.Rows[i][ColEstados.Movimiento.ToString()]),
                        Direccion = Convert.ToBoolean(dt.Rows[i][ColEstados.Direccion.ToString()]),
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
        public List<CompraModel> ListaCompra(int idProducto, decimal factor)
        {
            var listParam = new List<Parametros>();
            var lista = new List<CompraModel>();
            try
            {
                listParam.Add(new Parametros(ColCompra.IdProducto.ToString(), idProducto));

                var dt = C.Listado(ProcCompra.ListarCompra.ToString(), listParam).Tables[0];//ConsultaIngreso_Compra

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var u = new CompraModel(factor)
                    {
                        IdIngreso = Convert.ToInt32(dt.Rows[i][ColCompra.IdIngreso.ToString()]),
                        Fecha = Convert.ToDateTime(dt.Rows[i][ColCompra.Fecha.ToString()]),
                        Cantidad = Convert.ToDecimal(dt.Rows[i][ColCompra.Cantidad.ToString()]),
                        Unidad = dt.Rows[i][ColCompra.Unidad.ToString()].ToString(),
                        IdContenido = Convert.ToInt32(dt.Rows[i][ColCompra.IdContenido.ToString()]),
                        Factor = Convert.ToDecimal(dt.Rows[i][ColCompra.Factor.ToString()]),
                        Moneda = dt.Rows[i][ColCompra.Moneda.ToString()].ToString(),
                        Costo = Convert.ToDecimal(dt.Rows[i][ColCompra.Costo.ToString()]),
                        TCambio = Convert.ToDecimal(dt.Rows[i][ColCompra.TCambio.ToString()]),
                        Almacen = dt.Rows[i][ColCompra.Almacen.ToString()].ToString(),
                        Serie = Convert.ToInt32(dt.Rows[i][ColCompra.Serie.ToString()]),
                        Numero = Convert.ToInt32(dt.Rows[i][ColCompra.Numero.ToString()]),
                        Tipo = dt.Rows[i][ColCompra.Tipo.ToString()].ToString(),
                        Proveedor = dt.Rows[i][ColCompra.Proveedor.ToString()].ToString(),
                        NumDocumento = dt.Rows[i][ColCompra.NumDocumento.ToString()].ToString()
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
    }
}
