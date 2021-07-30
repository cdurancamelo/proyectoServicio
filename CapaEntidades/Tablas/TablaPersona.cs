using System;

[Serializable()]
public class TablaPersona
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


    private string m_pri_nombre;
    public string pri_nombre
    {
        get
        {
            return m_pri_nombre;
        }
        set
        {
            m_pri_nombre = value;
        }
    }

    private string m_seg_nombre;
    public string seg_nombre
    {
        get
        {
            return m_seg_nombre;
        }
        set
        {
            m_seg_nombre = value;
        }
    }

    private string m_pri_apellido;
    public string pri_apellido
    {
        get
        {
            return m_pri_apellido;
        }
        set
        {
            m_pri_apellido = value;
        }
    }

    private string m_seg_apellido;
    public string seg_apellido
    {
        get
        {
            return m_seg_apellido;
        }
        set
        {
            m_seg_apellido = value;
        }
    }

    private int m_con_tipoDocumento;
    public int con_tipoDocumento
    {
        get
        {
            return m_con_tipoDocumento;
        }
        set
        {
            m_con_tipoDocumento = value;
        }
    }

    private string m_documento;
    public string documento
    {
        get
        {
            return m_documento;
        }
        set
        {
            m_documento = value;
        }
    }

    private string m_celular;
    public string celular
    {
        get
        {
            return m_celular;
        }
        set
        {
            m_celular = value;
        }
    }

    private string m_direccion;
    public string direccion
    {
        get
        {
            return m_direccion;
        }
        set
        {
            m_direccion = value;
        }
    }

    private string m_correoElectronico;
    public string correoElectronico
    {
        get
        {
            return m_correoElectronico;
        }
        set
        {
            m_correoElectronico = value;
        }
    }


}
