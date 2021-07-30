using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Tablas
{
    [Serializable()]
    public class TablaFactura
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

        private int m_con_mecanico;
        public int con_mecanico
        {
            get
            {
                return m_con_mecanico;
            }
            set
            {
                m_con_mecanico = value;
            }
        }

        private int m_con_tienda;
        public int con_tienda
        {
            get
            {
                return m_con_tienda;
            }
            set
            {
                m_con_tienda = value;
            }
        }

        private DateTime m_fecha;
        public DateTime fecha
        {
            get
            {
                return m_fecha;
            }
            set
            {
                m_fecha = value;
            }
        }




    }
}
