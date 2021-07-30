using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Tablas
{
    [Serializable()]
    public class Tabla_tipo_documento
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
    }
}
