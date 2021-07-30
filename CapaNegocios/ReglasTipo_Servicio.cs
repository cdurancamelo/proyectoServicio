
using System.ComponentModel;
using CapaDatos;
using CapaEntidades.Tablas;

[DataObject()]
public class ReglasTipo_Servicio
{
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaTipo_Servicio GetListPersonaAll()
    {
        return SqlTipo_Servicio.GetListTipo_ServicioAll();
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaTipo_Servicio GetListTipo_ServicioConsecutivo(int con)
    {
        return SqlTipo_Servicio.GetListTipo_ServicioConsecutivo(con);
    }

 
   
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public static int Insertar(TablaTipo_Servicio myTabla)
    {
        return SqlTipo_Servicio.Insertar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static int Actualizar(TablaTipo_Servicio myTabla)
    {
        return SqlTipo_Servicio.Actualizar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public static ListaTipo_Servicio GetListTipo_ServicioEliminar(int con)
    {
        return SqlTipo_Servicio.GetListTipo_ServicioEliminar(con);
    }


}
