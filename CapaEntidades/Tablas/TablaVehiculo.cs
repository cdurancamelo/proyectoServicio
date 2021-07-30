using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Tablas
{
    [Serializable]
    public class TablaVehiculo
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


        private string m_marca;
        public string marca
        {
            get
            {
                return m_marca;
            }
            set
            {
                m_marca = value;
            }
        }

        private string m_modelo;
        public string modelo
        {
            get
            {
                return m_modelo;
            }
            set
            {
                m_modelo = value;
            }
        }

        private string m_placa;
        public string placa
        {
            get
            {
                return m_placa;
            }
            set
            {
                m_placa = value;
            }
        }
    }
}
