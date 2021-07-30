using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Tablas
{
    [Serializable()]
    public class TablaServicio
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

        private int m_con_tipoServicio;
        public int con_tipoServicio
        {
            get
            {
                return m_con_tipoServicio;
            }
            set
            {
                m_con_tipoServicio = value;
            }
        }

        private decimal m_precioManoObra;
        public decimal precioManoObra
        {
            get
            {
                return m_precioManoObra;
            }
            set
            {
                m_precioManoObra = value;
            }
        }

        private decimal m_descuento;
        public decimal descuento
        {
            get
            {
                return m_descuento;
            }
            set
            {
                m_descuento = value;
            }
        }

        private int m_con_estado;
        public int con_estado
        {
            get
            {
                return m_con_estado;
            }
            set
            {
                m_con_estado = value;
            }
        }

        private int m_con_cliente;
        public int con_cliente
        {
            get
            {
                return m_con_cliente;
            }
            set
            {
                m_con_cliente = value;
            }
        }


    }
}
