using DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using VERTICAL.Modelos.Publico;

namespace LOGICA.Logica.Publico
{
    public class LogUbigeo
    {
        Conexion C = new Conexion();
        public DataTable Listar()
        {
            var list = new List<ModelUbigeo>();
            try
            {
                return C.Listado("ListarUbigeo", null).Tables[0];
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    var dr = dt.Rows[i];
                //    var u = new UbigeoModel
                //    {
                //        IdUbigeo = Convert.ToInt32(dr[ColUbigeo.IdUbigeo.ToString()]),
                //        Codigo = dr[ColUbigeo.IdUbigeo.ToString()].ToString(),
                //        Departamento = dr[ColUbigeo.Departamento.ToString()].ToString(),
                //        Provincia = dr[ColUbigeo.Provincia.ToString()].ToString(),
                //        Distrito = dr[ColUbigeo.Distrito.ToString()].ToString(),
                //        X = float.Parse(dr[ColUbigeo.X.ToString()].ToString()),
                //        Y = float.Parse(dr[ColUbigeo.Y.ToString()].ToString())
                //    };
                //list.Add(u);
                //}
                //return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
