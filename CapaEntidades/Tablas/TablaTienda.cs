using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Tablas
{
    [Serializable]
    public class TablaTienda
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

        private string m_nombre;
        public string nombre
        {
            get
            {
                return m_nombre;
            }
            set
            {
                m_nombre = value;
            }
        }
    }
}
