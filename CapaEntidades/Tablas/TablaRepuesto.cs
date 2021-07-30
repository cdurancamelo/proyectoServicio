using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Tablas
{
    [Serializable()]
    public class TablaRepuesto
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

        private int m_unidad;
        public int unidad
        {
            get
            {
                return m_unidad;
            }
            set
            {
                m_unidad= value;
            }
        }

        private decimal m_precioUnitario;
        public decimal precioUnitario
        {
            get
            {
                return m_precioUnitario;
            }
            set
            {
                m_precioUnitario = value;
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


    }
}
