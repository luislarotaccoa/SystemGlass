using System;
using System.Data;

namespace DATOS
{
    public class Parametros
    {
        public String m_Nombre { get; set; }
        public Object m_Valor { get; set; }
        public SqlDbType m_TipoDato { get; set; }
        public ParameterDirection m_Direccion { get; set; }
        public int m_Tamaño { get; set; }

        public Parametros(String objNombre, Object objValor)
        {
            m_Nombre = objNombre;
            m_Valor = objValor;
            m_Direccion = ParameterDirection.Input;
        }

        public Parametros(String objNombre, Object objValor, SqlDbType objTipoDato, ParameterDirection objDireccion, int objTamaño)
        {
            m_Nombre = objNombre;
            m_Valor = objValor;
            m_TipoDato = objTipoDato;
            m_Direccion = objDireccion;
            m_Tamaño = objTamaño;
        }
    }
}
