
using System.ComponentModel;
using CapaDatos;
using CapaEntidades.Tablas;

[DataObject()]
public class ReglasFactura_Detalle
{
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaFactura_Detalle GetListFactura_DetalleAll()
    {
        return SqlFactura_Detalle.GetListFactura_DetalleAll();
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaFactura_Detalle GetListFactura_DetalleConsecutivo(int con)
    {
        return SqlFactura_Detalle.GetListFactura_DetalleConsecutivo(con);
    }

    [DataObjectMethod(DataObjectMethodType.Select, false)]
    public static ListaFactura_Detalle GetListFactura_DetalleCon_Factura(int con)
    {
        return SqlFactura_Detalle.GetListFactura_DetalleCon_Factura(con);
    }

   
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public static int Insertar(TablaFactura_Detalle myTabla)
    {
        return SqlFactura_Detalle.Insertar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static int Actualizar(TablaFactura_Detalle myTabla)
    {
        return SqlFactura_Detalle.Actualizar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public static ListaFactura_Detalle GetListPersonaEliminar(int con)
    {
        return SqlFactura_Detalle.GetListFactura_DetalleEliminar(con);
    }


}
