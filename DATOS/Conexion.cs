using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DATOS
{
    public class Conexion
    {
        static string stringConnectio = ConfigurationManager.ConnectionStrings["SystemGlassDB"].ToString();

        public SqlConnection conexion = new SqlConnection(stringConnectio);
        private void Conectar()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
        }
        private void Desconectar()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
        }
        public DataSet Listado(String NombreSP, List<Parametros> lst)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da;
            try
            {
                Conectar();
                da = new SqlDataAdapter(NombreSP, conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(lst[i].m_Nombre, lst[i].m_Valor);
                    }
                }
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
            Desconectar();
            return ds;
        }
        public void EjecutarSP(String NombreSP, ref List<Parametros> lst)
        {
            SqlCommand cmd;
            try
            {
                Conectar();
                cmd = new SqlCommand(NombreSP, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lst != null)
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (lst[i].m_Direccion == ParameterDirection.Input)
                            cmd.Parameters.AddWithValue(lst[i].m_Nombre, lst[i].m_Valor);
                        if (lst[i].m_Direccion == ParameterDirection.Output)
                            cmd.Parameters.Add(lst[i].m_Nombre, lst[i].m_TipoDato, lst[i].m_Tamaño).Direction = ParameterDirection.Output;
                    }
                    cmd.ExecuteNonQuery();
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                            lst[i].m_Valor = cmd.Parameters[i].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Desconectar();
        }
        public string CargaMasiva(string tableName, DataTable table)
        {
            Conectar();
            string mensaje = "";
            using (SqlTransaction transaction = conexion.BeginTransaction())
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conexion, SqlBulkCopyOptions.Default, transaction))
                {
                    try
                    {
                        bulkCopy.DestinationTableName = tableName;
                        bulkCopy.WriteToServer(table);
                        transaction.Commit();
                        mensaje = "1";
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        mensaje = e.Message;
                    }
                }
            }
            Desconectar();
            return mensaje;
        }
        public void ConvertDateReadertoTableUsingLoad()
        {
            SqlConnection conn = null;
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["DBTINTAYA"].ConnectionString;
                conn = new SqlConnection(connString);
                string query = "SELECT * FROM Cliente";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(dr);
            }

            catch (SqlException ex)
            {
                // handle error 
            }

            catch (Exception ex)
            {
                // handle error 
            }

            finally
            {
                conn.Close();
            }
        }
        public int EjecutarF(String NombreF)
        {
            int SAIDA;
            SqlCommand cmd;
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT " + NombreF, conexion);
                SAIDA = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            Desconectar();
            return SAIDA;
        }
        public int EjecutarF(String NombreF, String NomParametro, Object Serie)
        {
            int SAIDA;
            SqlCommand cmd;
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT " + NombreF + "(" + NomParametro + ")", conexion);
                cmd.Parameters.AddWithValue(NomParametro, Serie);
                SAIDA = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            Desconectar();
            return SAIDA;
        }
        public int EjecutarF(String NombreF, String NomParametro1, String NomParametro2, Object Valor1, Object Valor2)
        {
            int SAIDA;
            SqlCommand cmd;
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT " + NombreF + "(" + NomParametro1 +", "+NomParametro2+ ")", conexion);
                cmd.Parameters.AddWithValue(NomParametro1, Valor1);
                cmd.Parameters.AddWithValue(NomParametro2, Valor2);
                SAIDA = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            Desconectar();
            return SAIDA;
        }
        public decimal EjecutarFD(String NombreF)
        {
            decimal SALIDA;
            SqlCommand cmd;
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT " + NombreF, conexion);
                SALIDA = Convert.ToDecimal(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            Desconectar();
            return SALIDA;
        }

    }
}
