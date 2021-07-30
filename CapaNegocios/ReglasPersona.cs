
using System.ComponentModel;
using CapaDatos;

[DataObject()]
public class ReglasPersona
{
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaPersona GetListPersonaAll()
    {
        return SqlPersona.GetListPersonaAll();
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaPersona GetListPersonaConsecutivo(int con)
    {
        return SqlPersona.GetListPersonaConsecutivo(con);
    }

    [DataObjectMethod(DataObjectMethodType.Select, false)]
    public static ListaPersona GetListPersonaConPersona(int con)
    {
        return SqlPersona.GetListPersonaConPersona(con);
    }

    [DataObjectMethod(DataObjectMethodType.Select, false)]
    public static ListaPersona GetListPersonaConDocumento(string con)
    {
        return SqlPersona.GetListPersonaConDocumento(con);
    }


    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public static int Insertar(TablaPersona myTabla)
    {
        return SqlPersona.Insertar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static int Actualizar(TablaPersona myTabla)
    {
        return SqlPersona.Actualizar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static ListaPersona GetListPersonaEliminar(int con)
    {
        return SqlPersona.GetListPersonaEliminar(con);
    }


}
