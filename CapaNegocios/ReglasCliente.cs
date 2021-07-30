
using System.ComponentModel;
using CapaDatos;
using CapaEntidades.Tablas;

[DataObject()]
public class ReglasCliente
{
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaCliente GetListClienteAll()
    {
        return SqlCliente.GetListClienteAll();
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaCliente GetListClienteConPersona(int con)
    {
        return SqlCliente.GetListClienteConPersona(con);
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaCliente GetListClienteConPersonaLatest(int con)
    {
        return SqlCliente.GetListClienteConPersonaLatest(con);
    }

    [DataObjectMethod(DataObjectMethodType.Select, false)]
    public static ListaCliente GetListClienteConsecutivo(int con)
    {
        return SqlCliente.GetListClienteConsecutivo(con);
    }

   
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public static int Insertar(TablaCliente myTabla)
    {
        return SqlCliente.Insertar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static int Actualizar(TablaCliente myTabla)
    {
        return SqlCliente.Actualizar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public static ListaCliente GetListClienteEliminar(int con)
    {
        return SqlCliente.GetListClienteEliminar(con);
    }


}
