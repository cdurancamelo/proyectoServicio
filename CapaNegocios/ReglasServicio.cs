
using System.ComponentModel;
using CapaDatos;
using CapaEntidades.Tablas;

[DataObject()]
public class ReglasServicio
{
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaServicio GetListServicioAll()
    {
        return SqlServicio.GetListServicioAll();
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaServicio GetListServicioConCliente(int con)
    {
        return SqlServicio.GetListServicioConCliente(con);
    }

    [DataObjectMethod(DataObjectMethodType.Select, false)]
    public static ListaServicio GetListServicioConsecutivo(int con)
    {
        return SqlServicio.GetListServicioConsecutivo(con);
    }

   
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public static int Insertar(TablaServicio myTabla)
    {
        return SqlServicio.Insertar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static int Actualizar(TablaServicio myTabla)
    {
        return SqlServicio.Actualizar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public static ListaServicio GetListServicioEliminar(int con)
    {
        return SqlServicio.GetListServicioEliminar(con);
    }


}
