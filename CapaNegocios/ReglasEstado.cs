
using System.ComponentModel;
using CapaDatos;

[DataObject()]
public class ReglasEstado
{
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaEstado GetListEstadoAll()
    {
        return SqlEstado.GetListEstadoAll();
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaEstado GetListEstadoConsecutivo(int con)
    {
        return SqlEstado.GetListEstadoConsecutivo(con);
    }

  

   



}
