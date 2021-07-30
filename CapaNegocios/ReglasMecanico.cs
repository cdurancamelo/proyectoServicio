
using System.ComponentModel;
using CapaDatos;
using CapaEntidades.Tablas;

[DataObject()]
public class ReglasMecanico
{
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaMecanico GetListMecanicoAll()
    {
        return SqlMecanico.GetListMecanicoAll();
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaMecanico GetListMecanicoConPersona(int con)
    {
        return SqlMecanico.GetListMecanicoConPersona(con);
    }

    [DataObjectMethod(DataObjectMethodType.Select, false)]
    public static ListaMecanico GetListMecanicoConsecutivo(int con)
    {
        return SqlMecanico.GetListMecanicoConsecutivo(con);
    }

   
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public static int Insertar(TablaMecanico myTabla)
    {
        return SqlMecanico.Insertar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static int Actualizar(TablaMecanico myTabla)
    {
        return SqlMecanico.Actualizar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public static ListaMecanico GetListMecanicoEliminar(int con)
    {
        return SqlMecanico.GetListMecanicoEliminar(con);
    }


}
