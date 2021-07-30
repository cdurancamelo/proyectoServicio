using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

using CapaEntidades;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Xml;


using System.Web.Services;
using CapaEntidades.Tablas;

namespace WebMantenimiento.Form
{
    public partial class Cliente : System.Web.UI.Page
    {
       
      
        [WebMethod()]
        public static int ConsultaPersona(string txtTipoIdentificacion)
        {
             int varConse = 0;
            //var vprue = ReglasPersona.GetListPersonaConDocumento(txtTipoIdentificacion).Count;

            try
            {
                if (ReglasPersona.GetListPersonaConDocumento(txtTipoIdentificacion).Count > 0 || ReglasPersona.GetListPersonaConDocumento(txtTipoIdentificacion) != null)
                {
                    varConse = ReglasPersona.GetListPersonaConDocumento(txtTipoIdentificacion)[0].consecutivo;
                }
                else
                {
                    varConse = 0;
                }
            }
            catch
            {
                return varConse;
            }

            return varConse;
        }


        [WebMethod()]
        public static string GrabarPersona(string vcmbTdocumento, string vtxtIdentificacion, string vtxtSnombre, string vtxtSapellido, string vtxtPapellido, string vtxtDireccion, string vtxtCorreoElectronico, string vtxtPnombre)
        {
            int i = 0;
            string varConse = "";
            try
            {
               
                    TablaPersona tabPersona = new TablaPersona();
                    tabPersona.pri_nombre = vtxtPnombre;
                    tabPersona.seg_nombre = vtxtSnombre;
                    tabPersona.pri_apellido = vtxtPapellido;
                    tabPersona.seg_apellido = vtxtSapellido;
                    tabPersona.con_tipoDocumento = 1;

                    tabPersona.documento = vtxtIdentificacion;
                    tabPersona.celular = "3112525252";
                    tabPersona.direccion = vtxtDireccion;
                    tabPersona.correoElectronico = vtxtCorreoElectronico;

                    i = ReglasPersona.Insertar(tabPersona);
                    if (i != 0)
                        varConse = "vtxtIdentificacion";
                    else
                        varConse = "NOK";
               
            }
            catch
            {
                return varConse;
            }

            return varConse;
        }


        [WebMethod()]
        public static ArrayList Historial(string vcc)
        {

            
            List<TablaPersona> li = new List<TablaPersona>();
            li.AddRange(ReglasPersona.GetListPersonaConDocumento(vcc));

            ArrayList arr = new ArrayList();

            for (var a = 0; a <= li.Count - 1; a++)
            {
                arr.Add(li[a].consecutivo);
                arr.Add(li[a].documento);
                arr.Add(li[a].pri_nombre);
                arr.Add(li[a].seg_nombre);
                arr.Add(li[a].pri_apellido);
                arr.Add(li[a].seg_apellido);
                arr.Add(li[a].celular);
                arr.Add(li[a].direccion);
                arr.Add(li[a].correoElectronico);
               
            }

            li.Clear();
            li = null;

            return arr;
        }

        [WebMethod()]
        public static ArrayList GrabarVehiculo(int consePer, decimal vPresupuesto, string vMarca, string vModelo, string vPlaca)
        {
            int i = 0;
            int e = 0;
            int vVehicu = 0;
            string varConse = "";
            ArrayList arres = new ArrayList();
            try
            {
                if(ReglasCliente.GetListClienteConPersona(consePer).Count > 0 || ReglasCliente.GetListClienteConPersona(consePer) != null || ReglasCliente.GetListClienteConPersona(consePer) != null)
                {
                    TablaCliente tabCliente = new TablaCliente();
                    tabCliente.con_persona = consePer;
                    tabCliente.presupuesto = vPresupuesto;
                    i = ReglasCliente.Insertar(tabCliente);
                    if (i != 0)
                        vVehicu = ReglasCliente.GetListClienteConPersonaLatest(consePer)[0].consecutivo;


                    TablaVehiculo TablaVehiculo = new TablaVehiculo();
                    TablaVehiculo.con_cliente = vVehicu;
                    TablaVehiculo.marca = vMarca;
                    TablaVehiculo.modelo = vModelo;
                    TablaVehiculo.placa = vPlaca;
                    e = ReglasVehiculo.Insertar(TablaVehiculo);
                    if (e != 0)
                    {
                       
                        arres.Add("OK");
                        arres.Add(vVehicu);
                    }

                    else
                       
                    arres.Add("NOK");
                    arres.Add("Error al grabar la informacion");
                }
                else
                {
                    TablaCliente tabCliente = new TablaCliente();
                    tabCliente.con_persona = consePer;
                    tabCliente.presupuesto = vPresupuesto;
                    i = ReglasCliente.Insertar(tabCliente);
                    if (i != 0)
                        vVehicu = ReglasCliente.GetListClienteConPersona(consePer)[0].consecutivo;


                    TablaVehiculo TablaVehiculo = new TablaVehiculo();
                    TablaVehiculo.con_cliente = vVehicu;
                    TablaVehiculo.marca = vMarca;
                    TablaVehiculo.modelo = vModelo;
                    TablaVehiculo.placa = vPlaca;
                    e = ReglasVehiculo.Insertar(TablaVehiculo);
                    if (e != 0)
                    {
                        varConse = "OK";
                        arres.Add("OK");
                        arres.Add(vVehicu);
                    }

                    else
                      
                    arres.Add("NOK");
                        arres.Add("Error al grabar la informacion");
                   }
              

            }
            catch
            {
                TablaCliente tabCliente = new TablaCliente();
                tabCliente.con_persona = consePer;
                tabCliente.presupuesto = vPresupuesto;
                i = ReglasCliente.Insertar(tabCliente);
                if (i != 0)
                    vVehicu = ReglasCliente.GetListClienteConPersona(consePer)[0].consecutivo;


                TablaVehiculo TablaVehiculo = new TablaVehiculo();
                TablaVehiculo.con_cliente = vVehicu;
                TablaVehiculo.marca = vMarca;
                TablaVehiculo.modelo = vModelo;
                TablaVehiculo.placa = vPlaca;
                e = ReglasVehiculo.Insertar(TablaVehiculo);
                if (e != 0)
                {
                    
                    arres.Add("OK");
                    arres.Add(vVehicu);
                }

                else
                    
                arres.Add("NOK");
                arres.Add("Error al grabar la informacion");
            }

            return arres;
        }

        [WebMethod()]
        public static ArrayList HistorialVehiculo(string vcc)
        {
            var vconper=ReglasPersona.GetListPersonaConDocumento(vcc)[0].consecutivo;

            List<TablaVehiculo> li = new List<TablaVehiculo>();
            li.AddRange(ReglasVehiculo.GetListVehiculoConPersona(vconper));

            ArrayList arr = new ArrayList();

            for (var a = 0; a <= li.Count - 1; a++)
            {
                arr.Add(li[a].consecutivo);
                arr.Add(vcc);
                arr.Add(ReglasCliente.GetListClienteConsecutivo(li[a].con_cliente)[0].presupuesto);
                arr.Add(li[a].marca);
                arr.Add(li[a].modelo);
                arr.Add(li[a].placa);
               

            }

            li.Clear();
            li = null;

            return arr;
        }

    }
}