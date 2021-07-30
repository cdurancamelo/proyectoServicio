using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaEntidades.Tablas
{
    [Serializable()]
   public class TablaMecanico
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


        private string m_identificador;
        public string identificador
        {
            get
            {
                return m_identificador;
            }
            set
            {
                m_identificador = value;
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


    }
}
