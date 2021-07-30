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
    public partial class Empleado : System.Web.UI.Page
    {
        [WebMethod()]
        public static ArrayList LlenarComboRepuesto()
        {

            List<TablaRepuesto> li = new List<TablaRepuesto>();
            li.AddRange(ReglasRepuesto.GetListRepuestoAll());

            ArrayList arr = new ArrayList();

            for (var a = 0; a <= li.Count - 1; a++)
            {
                arr.Add(li[a].consecutivo);
                arr.Add(li[a].descripcion);
                arr.Add(li[a].unidad);
                arr.Add(li[a].precioUnitario);
                arr.Add(li[a].descuento);
                arr.Add(ReglasTienda.GetListTiendaConsecutivo(li[a].con_tienda)[0].nombre);
  
            }

            li.Clear();
            li = null;

            return arr;
        }

           [WebMethod()]
        public static ArrayList LlenarComboTipoServicio()
        {
            List<TablaTipo_Servicio> lits = new List<TablaTipo_Servicio>();
            lits.AddRange(ReglasTipo_Servicio.GetListPersonaAll());

            ArrayList arr = new ArrayList();

            for (var a = 0; a <= lits.Count - 1; a++)
            {
                arr.Add(lits[a].consecutivo);
                arr.Add(lits[a].descripcion);
                arr.Add(lits[a].valor_minimo);
                arr.Add(lits[a].valor_maximo);
                
  
            }

            lits.Clear();
            lits = null;

            return arr;
        }

        [WebMethod()]
        public static ArrayList LlenarComboTienda()
        {
            List<TablaTienda> liti = new List<TablaTienda>();
            liti.AddRange(ReglasTienda.GetListTiendaAll());

            ArrayList arr = new ArrayList();

            for (var a = 0; a <= liti.Count - 1; a++)
            {
                arr.Add(liti[a].consecutivo);
                arr.Add(liti[a].nombre);
    
            }

            liti.Clear();
            liti = null;

            return arr;
        }

        [WebMethod()]
        public static ArrayList LlenarComboEstado()
        {

            List<TablaEstado> lie = new List<TablaEstado>();
            lie.AddRange(ReglasEstado.GetListEstadoAll());

            ArrayList arr = new ArrayList();

            for (var a = 0; a <= lie.Count - 1; a++)
            {
                arr.Add(lie[a].consecutivo);
                arr.Add(lie[a].estado);
               

            }

            lie.Clear();
            lie = null;

            return arr;
        }


        [WebMethod()]
        public static ArrayList HistorialFactura(string iden)
        {
            var conper = ReglasPersona.GetListPersonaConDocumento(iden)[0].consecutivo;
            var conmeca = ReglasMecanico.GetListMecanicoConPersona(conper)[0].consecutivo;
            List<TablaFactura> lifa = new List<TablaFactura>();
            lifa.AddRange(ReglasFactura.GetListFacturaconpersonaMecanico(conmeca));

            ArrayList arr = new ArrayList();
            for (var a = 0; a <= lifa.Count - 1; a++)
            {

                var conPerMec = ReglasMecanico.GetListMecanicoConsecutivo(lifa[a].con_mecanico)[0].con_persona;
                var concliente = ReglasCliente.GetListClienteConsecutivo(lifa[a].con_cliente)[0].con_persona;




                arr.Add(lifa[a].consecutivo);
                arr.Add(lifa[a].con_cliente);
                arr.Add(lifa[a].con_mecanico);
                arr.Add(lifa[a].fecha.ToString());
                arr.Add(lifa[a].con_tienda);
                arr.Add(iden);
                arr.Add(ReglasPersona.GetListPersonaConsecutivo(concliente)[0].pri_nombre+"   "+ ReglasPersona.GetListPersonaConsecutivo(concliente)[0].pri_apellido);
                arr.Add(ReglasPersona.GetListPersonaConsecutivo(conPerMec)[0].pri_nombre+ "  "+ ReglasPersona.GetListPersonaConsecutivo(conPerMec)[0].pri_apellido);
                arr.Add(lifa[a].fecha.ToString());
                arr.Add(ReglasTienda.GetListTiendaConsecutivo(lifa[a].con_tienda)[0].nombre);

            }

            lifa.Clear();
            lifa = null;

            return arr;
        }



        [WebMethod()]
        public static ArrayList GrabarFactura(string vIdentificacionCli, string idmecanico, int vtienda)
        {
            ArrayList arrf = new ArrayList();
            var valPer = false;
            if(ReglasPersona.GetListPersonaConDocumento(vIdentificacionCli).Count > 0)
            {
                valPer = true;
            }


            var vconMecanico = GrabarMecanico(idmecanico);
            var vconCliente = InformacionClienteValidar(vIdentificacionCli);


            int i = 0;
           
            try
            {
                if (vconMecanico != 0 && vconCliente!=0) {
                    TablaFactura tabFactura = new TablaFactura();
                    tabFactura.con_cliente = vconCliente;
                    tabFactura.con_mecanico = vconMecanico;
                    tabFactura.fecha = DateTime.Now;
                    tabFactura.con_tienda = vtienda;
                   
                    i = ReglasFactura.Insertar(tabFactura);
                    if (i != 0)
                    {
                        arrf.Add("OK");
                        arrf.Add(vconCliente);
                        arrf.Add(vconMecanico);
                    }
                    else
                    {
                        arrf.Add("NOK");
                      
                    }
                        
                  


                 
                       
                }
                else
                {
                    arrf.Add("NOK");
                }

            }
            catch
            {
                arrf.Add("NOK");
                return arrf;
            }

            return arrf;
        }

        [WebMethod()]
        public static ArrayList GrabarDetalleFactura(int conFact, string vcmbRepuestos, string vcmbTipoServicio, string vtxtPresioMObra, string vtxtDescuento)
        {
            ArrayList arrf = new ArrayList();
            int vconfac = grabarServicioAD(conFact, vcmbTipoServicio, vtxtPresioMObra, vtxtDescuento);

            if (vconfac > 0)
            {

            }



            int i = 0;
            string varConse = "";





            //try
            //{
               
            //        TablaFactura tabFactura = new TablaFactura();
            //        tabFactura.con_cliente = ReglasPersona.GetListPersonaConDocumento(vIdentificacionCli)[0].consecutivo;
            //        tabFactura.con_mecanico = conse;
            //        tabFactura.fecha = DateTime.Now;
            //        tabFactura.con_tienda = vtienda;

            //        i = ReglasFactura.Insertar(tabFactura);
            //        if (i != 0)

            //            arrf.Add("OK");

            //        else
            //            arrf.Add("NOK");
            

            //}
            //catch
            //{
            //    arrf.Add("NOK");
            //    return arrf;
            //}

            return arrf;
        }

        private static int grabarServicioAD(int conFact, string vcmbTipoServicio,string vtxtPresioMObra,string vtxtDescuento)
        {
            int i = 0;
            int respuesta = 0;
            TablaServicio tabServicio = new TablaServicio();
            tabServicio.con_tipoServicio = Convert.ToInt32( vcmbTipoServicio);
            tabServicio.con_cliente = ReglasFactura.GetListFacturaConsecutivo(conFact)[0].con_cliente;
            tabServicio.precioManoObra = Convert.ToDecimal(vtxtPresioMObra);
            tabServicio.descuento = Convert.ToDecimal(vtxtDescuento);

            i = ReglasServicio.Insertar(tabServicio);
            if (i != 0)

                respuesta = Convert.ToInt32(vcmbTipoServicio);

            else
                respuesta = 0;

            return respuesta;

        }

       
        private static int GrabarMecanico(string iden)
        {
            int i = 0;
            int varConse = 0;
            try
            {

                TablaMecanico tabMecanico = new TablaMecanico();
                tabMecanico.con_persona=ReglasPersona.GetListPersonaConDocumento(iden)[0].consecutivo;
                tabMecanico.con_estado = 1;
              
                i = ReglasMecanico.Insertar(tabMecanico);
                if (i != 0)
                    varConse = ReglasMecanico.GetListMecanicoConPersona(ReglasPersona.GetListPersonaConDocumento(iden)[0].consecutivo)[0].consecutivo;
                else
                    varConse = 0;

            }
            catch
            {
                return varConse;
            }

            return varConse;
        }
       

      [WebMethod()]
        public static int Detalle(string[] arrayCol2)
         {


            var vConCliente = ReglasFactura.GetListFacturaConsecutivo( Convert.ToInt32(arrayCol2[0]))[0].con_cliente;
            var vGraServicio = GrabarServicio(Convert.ToInt32(arrayCol2[1]), vConCliente, Convert.ToInt32(arrayCol2[2]), Convert.ToInt32(arrayCol2[3]), Convert.ToInt32(arrayCol2[4]));

            int i = 0;
            int varConse = 0;
            decimal vuni = 0;
            decimal viva = 0;
            decimal vtota = 0;
            try
            {
                if (ReglasEstado.GetListEstadoConsecutivo(Convert.ToInt32(arrayCol2[4]))[0].estado == "terminado" && vGraServicio == 0)
                {
                    List<TablaServicio> lifa = new List<TablaServicio>();
                    lifa.AddRange(ReglasServicio.GetListServicioConCliente(vConCliente));
                    ArrayList arr = new ArrayList();
                    if (lifa.Count > 0)
                    {
                        foreach (var element in lifa)
                        {
                            vuni += (element.precioManoObra - element.descuento);
                            viva += (vuni + (vuni * 19) ) / 100;
                            vtota += vuni + viva;
                        }

                    }

                    TablaFactura_Detalle tabFactura_Det = new TablaFactura_Detalle();
                    tabFactura_Det.con_factura = Convert.ToInt32(arrayCol2[0]);
                    tabFactura_Det.cantidad = 1;
                    tabFactura_Det.concepto = arrayCol2[5];
                    tabFactura_Det.valor_unitario = vuni;
                    tabFactura_Det.iva = viva;
                    //tabFactura_Det.valor_total = vtota;
                    i = ReglasFactura_Detalle.Insertar(tabFactura_Det);
                    if (i != 0)
                        varConse = Convert.ToInt32(arrayCol2[0]);
                    else
                        varConse = 0;
                }


            }
            catch
            {
                return varConse;
            }

            return varConse;
        }
        private static int GrabarServicio(int vcmbTipoServicio, int vConCliente, decimal vtxtManoObra, decimal vtxtDescuento, int vcmbEstado)
        {
            int i = 0;
            var varConse = 0;
            try
            {
                if (ReglasEstado.GetListEstadoConsecutivo(Convert.ToInt32(vcmbEstado))[0].estado == "iniciado")
                {
                    TablaServicio tabServicio = new TablaServicio();
                    tabServicio.con_tipoServicio = Convert.ToInt32(vcmbTipoServicio);
                    tabServicio.con_cliente = vConCliente;

                    tabServicio.precioManoObra = Convert.ToDecimal(vtxtManoObra);
                    tabServicio.descuento = Convert.ToDecimal(vtxtDescuento);
                    tabServicio.con_estado = Convert.ToInt32(vcmbEstado);

                    i = ReglasServicio.Insertar(tabServicio);
                    if (i != 0)
                        varConse = Convert.ToInt32(vConCliente);
                    else
                        varConse = 0;
                }
                else
                {
                    varConse = 0;
                }
           


            }
            catch
            {
                varConse = 0;
                return varConse;
            }

            return varConse;


        }

        private static int InformacionClienteValidar(string iden)
        {
          var  consulCli = 0;
             var conPersona = ReglasPersona.GetListPersonaConDocumento(iden)[0].consecutivo;
            if (ReglasCliente.GetListClienteConPersona(conPersona).Count > 0) {
                 consulCli = ReglasCliente.GetListClienteConPersona(conPersona)[0].consecutivo;
            }
            else
            {
                 consulCli = 0;
            }
           

            return consulCli;
        }



    }
}