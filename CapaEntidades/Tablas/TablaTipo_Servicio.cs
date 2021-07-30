using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Tablas
{
    [Serializable()]
    public class TablaTipo_Servicio
    {
        private int m_consecutivo;
        public int consecutivo
        {
            get
            {
                return m_consecutivo;
            }
            set
            {
                m_consecutivo = value;
            }
        }

        private decimal m_valor_minimo;
        public decimal valor_minimo
        {
            get
            {
                return m_valor_minimo;
            }
            set
            {
                m_valor_minimo = value;
            }
        }

        private decimal m_valor_maximo;
        public decimal valor_maximo
        {
            get
            {
                return m_valor_maximo;
            }
            set
            {
                m_valor_maximo = value;
            }
        }

        private string m_descripcion;
        public string descripcion
        {
            get
            {
                return m_descripcion;
            }
            set
            {
                m_descripcion = value;
            }
        }
    }
}
