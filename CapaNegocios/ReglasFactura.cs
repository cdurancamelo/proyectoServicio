
using System.ComponentModel;
using CapaDatos;
using CapaEntidades.Tablas;

[DataObject()]
public class ReglasFactura
{
    //utilizamos el select de factura
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaFactura GetListFacturaAll()
    {
            return SqlFactura.GetListFacturaAll();
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaFactura GetListFacturaConsecutivo(int con)
    {
        return SqlFactura.GetListFacturaConsecutivo(con);
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaFactura GetListFacturaconpersonaMecanico(int con)
    {
        return SqlFactura.GetListFacturaconpersonaMecanico(con);
    }

    [DataObjectMethod(DataObjectMethodType.Select, false)]
    public static ListaFactura GetListFacturaPorCliente(int con)
    {
        return SqlFactura.GetListFacturaPorCliente(con);
    }

   
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public static int Insertar(TablaFactura myTabla)
    {
        return SqlFactura.Insertar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static int Actualizar(TablaFactura myTabla)
    {
        return SqlFactura.Actualizar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public static ListaFactura GetListFacturaEliminar(int con)
    {
        return SqlFactura.GetListFacturaEliminar(con);
    }


}
