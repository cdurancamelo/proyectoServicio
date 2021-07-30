
using System.ComponentModel;
using CapaDatos;

[DataObject()]
public class ReglasTienda
{
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaTienda GetListTiendaAll()
    {
        return SqlTienda.GetListTiendaAll();
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaTienda GetListTiendaConsecutivo(int con)
    {
        return SqlTienda.GetListTiendaConsecutivo(con);
    }

   

}
