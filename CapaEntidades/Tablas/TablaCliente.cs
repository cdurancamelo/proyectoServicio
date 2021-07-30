using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Tablas
{
    [Serializable()]
    public class TablaCliente
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

        private int m_con_persona;
        public int con_persona
        {
            get
            {
                return m_con_persona;
            }
            set
            {
                m_con_persona = value;
            }
        }

        private decimal m_presupuesto;
        public decimal presupuesto
        {
            get
            {
                return m_presupuesto;
            }
            set
            {
                m_presupuesto = value;
            }
        }


    }
}
