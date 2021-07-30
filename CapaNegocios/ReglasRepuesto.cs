
using System.ComponentModel;
using CapaDatos;
using CapaEntidades.Tablas;

[DataObject()]
public class ReglasRepuesto
{
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaRepuesto GetListRepuestoAll()
    {
        return SqlRepuesto.GetListRepuestoAll();
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaRepuesto GetListRepuestoConsecutivo(int con)
    {
        return SqlRepuesto.GetListRepuestoConsecutivo(con);
    }

    [DataObjectMethod(DataObjectMethodType.Select, false)]
    public static ListaRepuesto GetListRepuestoConTienda(int con)
    {
        return SqlRepuesto.GetListRepuestoConTienda(con);
    }

   
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public static int Insertar(TablaRepuesto myTabla)
    {
        return SqlRepuesto.Insertar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static int Actualizar(TablaRepuesto myTabla)
    {
        return SqlRepuesto.Actualizar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public static ListaRepuesto GetListRepuestoEliminar(int con)
    {
        return SqlRepuesto.GetListRepuestoEliminar(con);
    }


}
