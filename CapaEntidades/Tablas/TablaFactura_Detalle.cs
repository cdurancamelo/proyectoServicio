using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Tablas
{
    [Serializable()]
    public class TablaFactura_Detalle
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

        private int m_con_factura;
        public int con_factura
        {
            get
            {
                return m_con_factura;
            }
            set
            {
                m_con_factura = value;
            }
        }

        private int m_cantidad;
        public int cantidad
        {
            get
            {
                return m_cantidad;
            }
            set
            {
                m_cantidad = value;
            }
        }

        private string m_concepto;
        public string concepto
        {
            get
            {
                return m_concepto;
            }
            set
            {
                m_concepto = value;
            }
        }

        private decimal m_valor_unitario;
        public decimal valor_unitario
        {
            get
            {
                return m_valor_unitario;
            }
            set
            {
                m_valor_unitario = value;
            }
        }

        private decimal m_valor_total;
        public decimal valor_total
        {
            get
            {
                return m_valor_total;
            }
            set
            {
                m_valor_total = value;
            }
        }

        private decimal m_iva;
        public decimal iva
        {
            get
            {
                return m_iva;
            }
            set
            {
                m_iva = value;
            }
        }
    }
}
