function FormClienteIng(varcl) {

    sessionStorage["varIhc"] = varcl;

    var tds = "";

    tds += "<form style='text-align:center; width:450px;margin:0 auto' >";
    tds += "<br /><br />";
    tds += "<div class='form-group'>";
    tds += "<label >Tipo Documento</label>";
    tds += "<select class='form-control' id='cmbTdocumento'>";
    tds += "<option>CC</option>";
    tds += "<option>TI</option>";
    tds += "</select>";
    tds += "</div>";
    tds += "<br />";
    tds += "<div class='form-group'>";
    tds += "<label >No. Idintificacion</label>";
    tds += "<input type='text' class='form-control' id='txtIdentificacion' name='txtIdentificacion' aria-describedby='emailHelp' placeholder='Identificacion'>";
    tds += "</div>";
    tds += "<br /><br />";

    tds += "<div id='divDetalle' style='display:none'>";

    tds += "<div class='form-group'>";
    tds += "<label >Primer Nombre</label>";
    tds += "<input type='text' class='form-control' id='txtPnombre' aria-describedby='emailHelp' placeholder='Primer Nombre'>";
    tds += "</div>";
    tds += "<br />";
    tds += "<div class='form-group'>";
    tds += "<label >Segundo Nombre</label>";
    tds += "<input type='text' class='form-control' id='txtSnombre' aria-describedby='emailHelp' placeholder='Segundo Nombre'>";
    tds += "</div>";
    tds += "<br />";
    tds += "<div class='form-group'>";
    tds += "<label >Primer Apellido</label>";
    tds += "<input type='text' class='form-control' id='txtPapellido' aria-describedby='emailHelp' placeholder='Primer Apellido'>";
    tds += "</div>";
    tds += "<br />";
    tds += "<div class='form-group'>";
    tds += "<label >Segundo Apellido</label>";
    tds += "<input type='text' class='form-control' id='txtSapellido' aria-describedby='emailHelp' placeholder='Segundo Apellido'>";
    tds += "</div>";
    tds += "<br />";

    tds += "<br />";
    tds += "<div class='form-group'>";
    tds += "<label >Direccion</label>";
    tds += "<input type='text' class='form-control' id='txtDireccion' aria-describedby='emailHelp' placeholder='Direccion'>";
    tds += "</div>";
    tds += "<br />";
    tds += "<div class='form-group'>";
    tds += "<label >Correo Electronico</label>";
    tds += "<input type='email' class='form-control' id='txtCorreoElectronico' aria-describedby='emailHelp' placeholder='Correo Electronico'>";
    tds += "<small id='emailHelp' class='form-text text-muted'></small>";
    tds += "</div>";
    tds += "<br />";
    tds += "</div>";
    //tds += "<button type='button' class='btn btn-primary' onclick='javascript:verInfo()'>Consultar</button>";
    tds += "  <br/><button type='button' class='btn btn-submit'  style='background-color:Orange;color:White; display:block' id='btnAceptarFiltro1' onclick='javascript:verInfo()' >Busqueda</button>";
    tds += "  <br/><button type='button' class='btn btn-submit'  style='background-color:Orange;color:White; display:none' id='btnGrabar' onclick='javascript:InsertInfo()' >Aceptar</button>";
    tds += "</form>";

    $('#formCliente').append(tds);

}
function InsertInfo() {
    var grabar = true;
    // var txtTipoIdentificacion = $('#txtIdentificacion').val();

    if ($("#cmbTdocumento").val() == '') {
        grabar = false;
        alert("Tipo de Identificacion sin diligenciar");
        return false;
    }



    if ($("#txtIdentificacion").val() == '') {
        grabar = false;
        alert("Identificacion sin diligenciar");
        return false;
    }

    if ($("#txtPnombre").val() == '') {
        grabar = false;
        alert("Primer nombre sin diligenciar");
        return false;
    }

    if ($("#txtPapellido").val() == '') {
        grabar = false;
        alert("Primer apellido sin diligenciar");
        return false;
    }

    if ($("#txtDireccion").val() == '') {
        grabar = false;
        alert("Direccion sin diligenciar");
        return false;
    }

    if ($("#txtCorreoElectronico").val() == '') {
        grabar = false;
        alert("Correo sin diligenciar");
        return false;
    }


    if (grabar == true) {

        var vcmbTdocumento = $("#cmbTdocumento").val();
        var vtxtIdentificacion = $("#txtIdentificacion").val();
        var vtxtPnombre = $("#txtPnombre").val();

        if ($("#txtSnombre").val() == '') {
            var vtxtSnombre = "SD";
        } else {
            var vtxtSnombre = $("#txtSnombre").val();
        }

        if ($("#txtSapellido").val() == '') {
            var vtxtSapellido = "SD";
        } else {
            var vtxtSapellido = $("#txtSapellido").val();
        }

        var vtxtPapellido = $("#txtPapellido").val();
        var vtxtDireccion = $("#txtDireccion").val();
        var vtxtCorreoElectronico = $("#txtCorreoElectronico").val();


        $.ajax({
            type: "POST",
            url: "cliente.aspx/GrabarPersona",
            data: JSON.stringify({ vcmbTdocumento: vcmbTdocumento, vtxtIdentificacion: vtxtIdentificacion, vtxtSnombre: vtxtSnombre, vtxtSapellido: vtxtSapellido, vtxtPapellido: vtxtPapellido, vtxtDireccion: vtxtDireccion, vtxtCorreoElectronico: vtxtCorreoElectronico, vtxtPnombre: vtxtPnombre }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSucces,
            failure: function (response) {
                alert(response.d);
            }
        });
        function OnSucces(response) {


            if (response.d == 0) {
                alert("Registro sin informacion");
                Historial(vtxtIdentificacion);

            } else {
                alert("Registro guardado correctamente. " + vtxtIdentificacion);
                verInfo();

            }

        }
    }
}
function verInfo() {

    var txtTipoIdentificacion = $('#txtIdentificacion').val();
    $.ajax({
        type: "POST",
        url: "cliente.aspx/ConsultaPersona",
        data: JSON.stringify({ txtTipoIdentificacion: txtTipoIdentificacion }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSucces,
        failure: function (response) {
            alert(response.d);
        }
    });
    function OnSucces(response) {


        if (response.d == 0) {
            alert("Registro sin informacion")
            $("#divDetalle").css("display", "block");
            $("#btnAceptarFiltro1").css("display", "none");
            $("#btnGrabar").css("display", "block");
            $("#divHistorial").css("display", "none");


        } else {
            $("#divDetalle").css("display", "none");
            $("#btnAceptarFiltro1").css("display", "block");
            $("#btnGrabar").css("display", "none");
            Historial(txtTipoIdentificacion);
        }

    }
}
function Historial(vcc) {

    $("#divHistorial").empty();
    $.ajax({
        type: "POST",
        url: "Cliente.aspx/Historial",
        data: JSON.stringify({ vcc: vcc }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSucces,
        failure: function (response) {
            alert(response.d);
        }
    });
    function OnSucces(response) {
        var arreglo = response.d;
        var linea = (arreglo.length / 9);
        var tds = "";
        //////////////////////////////////////////////////
        //         tds += "<div class='col-md-12 col-sm-12 col-xs-12'>";
        tds += "<div class='x_panel'>";
        tds += "<div class='x_title'  style='color:White; background-color:#A2D9CE'>";
        tds += "<h4>HISTORIAL DE DATOS BASICOS<small></small></h4>";
        tds += "<div class='clearfix'></div>";
        tds += "</div>";
        tds += "<div class='x_content' id='his'>";

        tds += "<table id='Historial' class='table table-striped' style='width:100%'>";
        tds += "<thead>";
        tds += "<tr>";
        
        tds += "<th>Consecutivo</th>";
        tds += "<th>Identificacion</th>";
        tds += "<th>P. Nombre</th>";
        tds += "<th>S. Nombre</th>";
        tds += "<th>P. Apellido</th>";
        tds += "<th>S. Apellido</th>";
        tds += "<th>Celular</th>";
        tds += "<th>Direccion</th>";
        tds += "<th>Correo Electronico</th>";
        tds += "<th></th>";
        tds += "</tr>";
        tds += "</thead>";
        tds += "<tbody>";
        var y = 0;
        for (var i = 0; i < linea; i++) {
            tds += "<tr>";
            tds += "<td>" + arreglo[y] + "</td>"; //id
            tds += "<td>" + arreglo[y + 1] + "</td>";
            tds += "<td>" + arreglo[y + 2] + "</td>";
            tds += "<td>" + arreglo[y + 3] + "</td>";
            tds += "<td>" + arreglo[y + 4] + "</td>";
            tds += "<td>" + arreglo[y + 5] + "</td>";
            tds += "<td>" + arreglo[y + 6] + "</td>";
            tds += "<td>" + arreglo[y + 7] + "</td>";
            tds += "<td>" + arreglo[y + 8] + "</td>";
          
                tds += '<td><a href="javascript:GestionAuto11(\'' + arreglo[y] + '\',\'' + arreglo[y + 1] + '\')">Registro Auto</a></td>';
            

            tds += "</tr>";
            y = y + 9;
        }
        tds += "</tbody>";
        tds += "<tfoot>";
        tds += "</tfoot>";
        tds += "</div>";
        tds += "</div>";
        $("#divHistorial").append(tds);

    }
}

function GestionAuto11(conse, identi) {

    $("#formClienteVehiculo").empty();
    $("#formCliente").css("display", "none");
    $("#formClienteVehiculo").css("display", "block");
    $("#divHistorialVehiculo").css("display", "block");
    $("#formClienteMantenimiento").css("display", "none");
    $("#divHistorialMantenimiento").css("display", "none");
    $("#divHistorial").css("display", "none");

    var tdsv = "";

    tdsv += "<form style='text-align:center; width:450px;margin:0 auto' >";

    tdsv += "<br /><br />";

    tdsv += "<div id='divDetalle' style='display:block'>";

    tdsv += "<div class='form-group'>";
    tdsv += "<label >Presupuesto</label>";
    tdsv += "<input type='number' class='form-control' id='txtPresupuesto' aria-describedby='emailHelp' placeholder='Presupuesto'>";
    tdsv += "</div>";
    tdsv += "<br /><br />";

    tdsv += "<div class='form-group'>";
    tdsv += "<label >Marca</label>";
    tdsv += "<input type='text' class='form-control' id='txtMarca' aria-describedby='emailHelp' placeholder='Marca'>";
    tdsv += "</div>";
    tdsv += "<br />";
    tdsv += "<div class='form-group'>";
    tdsv += "<label >Modelo</label>";
    tdsv += "<input type='text' class='form-control' id='txtModelo' aria-describedby='emailHelp' placeholder='Modelo'>";
    tdsv += "</div>";
    tdsv += "<br />";
    tdsv += "<div class='form-group'>";
    tdsv += "<label >Placa</label>";
    tdsv += "<input type='text' class='form-control' id='txtPlaca' aria-describedby='emailHelp' placeholder='Placa'>";
    tdsv += "</div>";
    tdsv += "<br />";
    tdsv += "<br />";
    tdsv += "</div>";
    
    tdsv += "<div>";
    tdsv += '  <br/><button type="button" class="btn btn-submit"  style="background-color:Orange; color:White; display:block" onclick="javascript: GrabarGestionAuto(\'' + conse + '\',\'' + identi + '\')">Aceptar</button>';

    tdsv += "</div>";
    tdsv += "<br />";
    tdsv += "<br />";
    tdsv += "</form>";

    $('#formClienteVehiculo').append(tdsv);

   /* HistorialVehiculo(identi);*/
}

///////////////////Registra vehiculo/////////////////////////


function GrabarGestionAuto(conse, identi) {
    alert(conse, identi);
    var grabar = true;


    if ($("#cmbTdocumento").val() == '') {
        grabar = false;
        alert("Tipo de Identificacion sin diligenciar");
        return false;
    }



    if ($("#txtMarca").val() == '') {
        grabar = false;
        alert("El campo Marcha no  esta diligencido.");
        return false;
    }

    if ($("#txtModelo").val() == '') {
        grabar = false;
        alert("El campo Modelo no  esta diligencido");
        return false;
    }

    if ($("#txtPlaca").val() == '') {
        grabar = false;
        alert("El campo Placa no esta diligenciado");
        return false;
    }




    if (grabar == true) {

        var vPresupuesto = $("#txtPresupuesto").val();
        var vMarca = $("#txtMarca").val();
        var vModelo = $("#txtModelo").val();
        var vPlaca = $("#txtPlaca").val();



        $.ajax({
            type: "POST",
            url: "Cliente.aspx/GrabarVehiculo",
            data: JSON.stringify({ consePer: conse, vPresupuesto: vPresupuesto, vMarca: vMarca, vModelo: vModelo, vPlaca: vPlaca }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSucces,
            failure: function (response) {
                alert(response.d);
            }
        });
        function OnSucces(response) {

            var respuesta = response.d

            if (respuesta[0] == "OK") {
                alert("Registro guardado correctamente");
               /* HistorialVehiculo(identi)*/
            } else {
                alert("No se logro guardar la informacion")
            }
            /* HistorialVehiculo(identi)*/
        }
    }

}

function GestionMan(conse, iden) {

    $("#formClienteVehiculo").empty();
    $("#formCliente").css("display", "none");
    $("#formClienteVehiculo").css("display", "none");
    $("#divHistorialVehiculo").css("display", "none");
    $("#formClienteMantenimiento").css("display", "block");
    $("#divHistorialMantenimiento").css("display", "block");
    $("#divHistorial").css("display", "none");

    var tdsM = "";
    tdsM += "<h2>FACTURAR</h2>";
    tdsM += "<div id='divFactura' style='display:block'>";

    tdsM += "<label >Elija la tienda de servicio</label>";
    tdsM += "<div class='form-group'>";
    tdsM += "<label >Tienda</label>";
    tdsM += "<select class='form-select' id='cmbTiendaServicio' aria-label='Default select example'></select>";
    tdsM += "</div>";


    tdsM += "<br /><br />";
    tdsM += "<label >Identificacion del cliente</label>";
    tdsM += "<div class='form-group'>";
    tdsM += "<input type='text' class='form-control' id='txtIdCliente' aria-describedby='emailHelp' placeholder='Identificacion del cliente'>";
    tdsM += "</div>";
    tdsM += "<br /><br />";
    tdsM += '  <br/><button type="button" class="btn btn-submit"  style="background-color:Orange; color:White; display:block" onclick="javascript: GrabarFactura(\'' + conse + '\',\'' + iden + '\')">Aceptar</button>';
    tdsM += "</div>";


    $("#divHistorialMantenimiento").append(tdsM);

    /*  -----grabamos mecanico-----*/

    $.ajax({
        type: "POST",
        url: "Empleado.aspx/GrabarMecanico",
        data: JSON.stringify({ conse: conse, iden: iden }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSucces,
        failure: function (response) {
            alert(response.d);
        }
    });
    function OnSucces(response) {

        var respuesta = response.d
        if (respuesta == "OK") {

            // HistorialFactura(identi);
            HistorialFactura(iden);
        } else {
            alert("Identificacion no encontrada en base de datos.")
        }
        LlenarCmbRepuesto();

    }
}
function GrabarServicio1(conFact) {
    var grabar = true;


    if ($("#cmbRepuestos").val() == '') {
        grabar = false;
        alert("Campo repuestos no esta diligenciado.");
        return false;
    }
    if ($("#cmbTipoServicio").val() == '') {
        grabar = false;
        alert("Campo Tipo de Servicio no esta diligenciado.");
        return false;
    }

    if ($("#txtPresioMObra").val() == '') {
        grabar = false;
        alert("Campo Mano de obra no esta diligenciado.");
        return false;
    }



    if (grabar == true) {

        var vcmbRepuestos = $("#cmbRepuestos").val();
        var vcmbTipoServicio = $("#cmbTipoServicio").val();

        var vtxtPresioMObra = $("#txtPresioMObra").val();
        var vtxtDescuento = $("#txtDescuento").val();

        $.ajax({
            type: "POST",
            url: "Empleado.aspx/GrabarDetalleFactura",
            data: JSON.stringify({ conFact: conFact, vcmbRepuestos: vcmbRepuestos, vcmbTipoServicio: vcmbTipoServicio, vtxtPresioMObra: vtxtPresioMObra, vtxtDescuento: vtxtDescuento }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSucces,
            failure: function (response) {
                alert(response.d);
            }
        });
        function OnSucces(response) {

            var respuesta = response.d

            if (respuesta[0] == "OK") {
                alert("Registro guardado correctamente");


            } else {
                alert("No se logro guardar la informacion")
            }
            /* HistorialVehiculo(identi)*/
        }
    }










    ///////////////////Registra vehiculo/////////////////////////




}
function HistorialFactura(iden) {

    $("#divHistorialMantenimiento").empty();
    $.ajax({
        type: "POST",
        url: "Empleado.aspx/HistorialFactura",
        data: JSON.stringify({ iden: iden }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSucces,
        failure: function (response) {
            alert(response.d);
        }
    });
    function OnSucces(response) {
        var arreglo = response.d;
        var linea = (arreglo.length / 10);
        var tds = "";
        //////////////////////////////////////////////////
        //         tds += "<div class='col-md-12 col-sm-12 col-xs-12'>";
        tds += "<br/><br/>";
        tds += "<div class='x_panel'>";
        tds += "<div class='x_title'  style='color:White; background-color:#A2D9CE'>";
        tds += "<h4>PENDIENTES POR FACTURAR<small></small></h4>";
        tds += "<div class='clearfix'></div>";
        tds += "</div>";
        tds += "<div class='x_content' id='his'>";

        tds += "<table id='HistorialVehiculo' class='table table-striped' style='width:100%'>";
        tds += "<thead>";
        tds += "<tr>";
        // tds += "<th>Consecutivo</th>";
        tds += "<th>Consecutivo</th>";
        tds += "<th>Identificacion</th>";
        tds += "<th>Cliente</th>";
        tds += "<th>Empleado</th>";
        tds += "<th>Fecha</th>";
        tds += "<th>Tienda</th>";
        tds += "<th></th>";
        tds += "</tr>";
        tds += "</thead>";
        tds += "<tbody>";
        var y = 0;
        for (var i = 0; i < linea; i++) {
            tds += "<tr>";
            tds += "<td>" + arreglo[y] + "</td>"; //id
            tds += "<td>" + arreglo[y + 5] + "</td>";
            tds += "<td>" + arreglo[y + 6] + "</td>";
            tds += "<td>" + arreglo[y + 7] + "</td>";
            tds += "<td>" + arreglo[y + 3] + "</td>";
            tds += "<td>" + arreglo[y + 9] + "</td>";
            tds += '<td><a href="javascript:GestionManF(\'' + arreglo[y] + '\')">Facturar</a></td>';
            tds += "</tr>";
            y = y + 10;
        }
        tds += "</tbody>";
        tds += "<tfoot>";
        tds += "</tfoot>";
        tds += "</div>";
        tds += "</div>";
        $("#divHistorialMantenimiento").append(tds);

    }
}

function LlenarCmbTipoServicio() {

    $.ajax({
        type: "POST",
        url: "Empleado.aspx/LlenarComboTipoServicio",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSucces,
        failure: function (response) {
            alert(response.d);
        }
    });

    function OnSucces(response) {

        var arreglo = response.d;
        var linea = (arreglo.length / 4);
        var y = 0;

        for (var i = 0; i < linea; i++) {
            var option = $(document.createElement('option'));
            option.val(arreglo[y]);
            option.text("Descripcion: " + arreglo[y + 1] + "     Valor Minimo: " + arreglo[y + 2] + "     Valor Maximo: " + arreglo[y + 3]);
            $("#cmbTipoServicio").append(option);
            y = y + 4;

        }


        LlenarComboTienda();

    }


}

function LlenarComboTienda() {

    $.ajax({
        type: "POST",
        url: "Empleado.aspx/LlenarComboTienda",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSucces,
        failure: function (response) {
            alert(response.d);
        }
    });

    function OnSucces(response) {

        var arreglo = response.d;
        var linea = (arreglo.length / 2);
        var y = 0;

        for (var i = 0; i < linea; i++) {
            var option = $(document.createElement('option'));
            option.val(arreglo[y]);
            option.text(arreglo[y + 1]);
            $("#cmbTiendaServicio").append(option);
            y = y + 2;

        }



    }


}

function LlenarCmbRepuesto() {
    $.ajax({
        type: "POST",
        url: "Empleado.aspx/LlenarComboRepuesto",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSucces,
        failure: function (response) {
            alert(response.d);
        }
    });

    function OnSucces(response) {

        var arreglo = response.d;
        var linea = (arreglo.length / 6);
        var y = 0;

        for (var i = 0; i < linea; i++) {
            var option = $(document.createElement('option'));
            option.val(arreglo[y]);
            option.text(arreglo[y + 1]);
            $("#cmbRepuestos").append(option);
            y = y + 6;

        }



    }

}