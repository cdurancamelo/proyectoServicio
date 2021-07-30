
using System.ComponentModel;
using CapaDatos;
using CapaEntidades.Tablas;

[DataObject()]
public class Reglas_tipo_documento
{
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static Lista_tipo_documento GetList_tipo_documentoAll()
    {
        return Sql_tipo_documento.GetList_tipo_documentoAll();
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static Lista_tipo_documento GetList_tipo_documentoPorConsecutivo(int con)
    {
        return Sql_tipo_documento.GetList_tipo_documentoPorConsecutivo(con);
    }


   
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public static int Insertar(Tabla_tipo_documento myTabla)
    {
        return Sql_tipo_documento.Insertar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static int Actualizar(Tabla_tipo_documento myTabla)
    {
        return Sql_tipo_documento.Actualizar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public static Lista_tipo_documento GetList_tipo_documentoEliminar(int con)
    {
        return Sql_tipo_documento.GetList_tipo_documentoEliminar(con);
    }


}
