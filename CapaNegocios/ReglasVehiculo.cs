using CapaDatos;
using CapaEntidades.Tablas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
     [DataObject()]
    public class ReglasVehiculo
    {
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaVehiculo GetListClienteAll()
    {
        return SqlVehiculo.GetListClienteAll();
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaVehiculo GetListVehiculoConCliente(int con)
    {
        return SqlVehiculo.GetListVehiculoConCliente(con);
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static ListaVehiculo GetListVehiculoConPersona(int con)
    {
        return SqlVehiculo.GetListVehiculoConPersona(con);
    }

    [DataObjectMethod(DataObjectMethodType.Select, false)]
    public static ListaVehiculo GetListVehiculoConsecutivo(int con)
    {
        return SqlVehiculo.GetListVehiculoConsecutivo(con);
    }


    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public static int Insertar(TablaVehiculo myTabla)
    {
        return SqlVehiculo.Insertar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public static int Actualizar(TablaVehiculo myTabla)
    {
        return SqlVehiculo.Actualizar(myTabla);
    }

    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public static ListaVehiculo GetListVehiculoEliminar(int con)
    {
        return SqlVehiculo.GetListVehiculoEliminar(con);
    }

}

