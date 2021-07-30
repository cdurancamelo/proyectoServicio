

function FormMantenimiento() {
    $("#formDetFactura").css("display", "none");
    $("#formMecanico").empty();
    $("#formMecanico").css("display", "block");
    var tdsM = "";
    tdsM += "<form style='text-align:center; width:450px;margin:0 auto' >";
    tdsM += "<h2>Registro de factura</h2>";

    tdsM += "<br /><br />";
    tdsM += "<label >Registre No. del Empleado</label>";
    tdsM += "<div class='form-group'>";
    tdsM += "<input type='text' class='form-control' id='txtIdMecanico' aria-describedby='emailHelp' placeholder='Identificacion del Mecanico'>";
    tdsM += "</div>";


    tdsM += "<br /><br />";
    tdsM += "<label >Identificacion del cliente</label>";
    tdsM += "<div class='form-group'>";
    tdsM += "<input type='text' class='form-control' id='txtIdCliente' aria-describedby='emailHelp' placeholder='Identificacion del cliente'>";
    tdsM += "</div>";
    tdsM += "<br /><br />";



    tdsM += "<label >Especifique la sucursal</label>";
    tdsM += "<div class='form-group'>";
    tdsM += "<label >Tienda</label>";
    tdsM += "<select class='form-select' id='cmbTiendaServicio' aria-label='Default select example'></select>";
    tdsM += "</div>";


    tdsM += "<div class='form-group'>";
    tdsM += "<table>";
    tdsM += "<tr>";
    tdsM += "<td>";
    tdsM += '  <br/><button type="button" class="btn btn-submit"  style="background-color:Orange; color:White; display:block" onclick="javascript: GrabarFactura()">Aceptar</button>';
    tdsM += "</td>";
    tdsM += "<td>";
    tdsM += '  <br/><button type="button" class="btn btn-submit"  style="background-color:Orange; color:White; display:block" onclick="javascript: HistorialFactura()">Detalle Factura</button>';
    tdsM += "</td>";
    tdsM += "</tr>";
    tdsM += "</table>"
    
  
    tdsM += "</div>";
    tdsM += "</form>";

    $("#formMecanico").append(tdsM);
    LlenarComboTienda();

}

function FormFacturacion(conFactura) {
    $("#formDetFactura").css("display", "block");
    $("#formDetFactura").empty();
    $("#formMecanico").css("display", "none");


    var tdsF = "";
    tdsF += "<form style='text-align:center; width:450px;margin:0 auto' >";
    tdsF += "<h2>Registro de factura</h2>";


    tdsF += "<div class='form-group'>";
    tdsF += "<label >Tipo de Servicio</label>";
    tdsF += "<select class='form-select' id='cmbTipoServicio' aria-label='Default select example'></select>";
    tdsF += "</div>";


    tdsF += "<br />";
    tdsF += "<label >Precio Mano de Obra</label>";
    tdsF += "<div class='form-group'>";
    tdsF += "<input type='name' class='form-control' id='txtManoObra' aria-describedby='emailHelp' placeholder='$Mano de Obra'>";
    tdsF += "</div>";
    tdsF += "<br />";


    tdsF += "<label >Descuento</label>";
    tdsF += "<div class='form-group'>";
    tdsF += "<input type='name' class='form-control' id='txtDescuento' aria-describedby='emailHelp' placeholder='Descuento'>";
    tdsF += "</div>";
    tdsF += "<br />";

    tdsF += "<div class='form-group'>";
    tdsF += "<label >Estado de Transaccion</label>";
    tdsF += "<select class='form-select' id='cmbEstado' aria-label='Default select example'>";
    tdsF += "</select > ";
    tdsF += "</div>";
    tdsF += "<br />";

    tdsF += "<div class='form-group'>";
    tdsF += "<label >Concepto de factura</label>";
    tdsF += "<input type='text' class='form-control' id='txtConceptoFa' aria-describedby='emailHelp' placeholder='Descuento'>";
    tdsF += "</div>";
    tdsF += "<br />";

    tdsF += "<div class='form-group'>";
    tdsF += '  <br/><button type="button" class="btn btn-submit"  style="background-color:Orange; color:White; display:block" onclick="javascript: GrabarDetFacturaServicio(\'' + conFactura + '\')">Grabar servicios</button>';

    tdsF += "</div>";
    tdsF += "</form>";

    $("#formDetFactura").append(tdsF);
    LlenarCmbTipoServicio();
    LlenarComboEstado();

}


function GrabarFactura() {

    var grabar = true;


    if ($("#txtIdMecanico").val() == '') {
        grabar = false;
        alert("Tipo de Identificacion sin diligenciar");
        return false;
    }



    if ($("#txtIdCliente").val() == '') {
        grabar = false;
        alert("El campo Marcha no  esta diligencido.");
        return false;
    }

    if ($("#cmbTiendaServicio").val() == '') {
        grabar = false;
        alert("El campo Modelo no  esta diligencido");
        return false;
    }

    if (grabar == true) {

        var vtxtIdMecanico = $("#txtIdMecanico").val();
        var vtxtIdCliente = $("#txtIdCliente").val();
        var vcmbTiendaServicio = $("#cmbTiendaServicio").val();

        $.ajax({
            type: "POST",
            url: "Empleado.aspx/GrabarFactura",
            data: JSON.stringify({ vIdentificacionCli: vtxtIdCliente, idmecanico: vtxtIdMecanico, vtienda: vcmbTiendaServicio }),
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

        }
    }

}

function GrabarDetFacturaServicio(conFactura) {

    var grabar = true;


    if ($("#cmbTipoServicio").val() == '') {
        grabar = false;
        alert("Tipo de Servicio sin diligenciar");
        return false;
    }



    if ($("#txtManoObra").val() == '') {
        grabar = false;
        alert("El campo Mano de Obra no  esta diligencido.");
        return false;
    }

    if ($("#txtDescuento").val() == '') {
        grabar = false;
        alert("El campo Descuento no  esta diligencido");
        return false;
    }

    if ($("#cmbEstado").val() == '') {
        grabar = false;
        alert("El campo Estado no  esta diligencido");
        return false;
    }

    if (grabar == true) {
        var arrayCol2 = new Array();
        var vcmbTipoServicio = $("#cmbTipoServicio").val();
        var vtxtManoObra = $("#txtManoObra").val();
        var vtxtDescuento = $("#txtDescuento").val();

        var vcmbEstado = $("#cmbEstado").val();
        var vtxtConceptoFa = $("#txtConceptoFa").val();

        arrayCol2.push(conFactura)
        arrayCol2.push(vcmbTipoServicio)
        arrayCol2.push(vtxtManoObra)
        arrayCol2.push(vtxtDescuento)
        arrayCol2.push(vcmbEstado)
        arrayCol2.push(vtxtConceptoFa)
      
        $.ajax({
            type: "POST",
            url: "Empleado.aspx/Detalle",
            data: JSON.stringify({ arrayCol2: arrayCol2 }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSucces,
            failure: function (response) {
                alert(response.d);
            }
        });
        function OnSucces(response) {

            var respuesta = response.d
            if (respuesta > 0) {
                alert("Registro guardado correctamente");

            } else {
                alert("No se logro guardar la informacion")
            }

        }
    }

}

function HistorialFactura() {
    var videMecanico = $("#txtIdMecanico").val();
    $("#divHistorialMantenimiento").empty();
    $.ajax({
        type: "POST",
        url: "Empleado.aspx/HistorialFactura",
        data: JSON.stringify({ iden: videMecanico }),
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

        tds += "<table id='HistorialFactura' class='table table-striped' style='width:100%'>";
        tds += "<thead>";
        tds += "<tr>";
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
            tds += '<td><a href="javascript:FormFacturacion(\'' + arreglo[y] + '\')">Facturar Servicios</a></td>';
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


///////////////////////////////////////llenado de combos///////////////////////

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
            option.text(arreglo[y + 1]);
            $("#cmbTipoServicio").append(option);
            y = y + 4;

        }




    }


}



function LlenarComboEstado() {

    $.ajax({
        type: "POST",
        url: "Empleado.aspx/LlenarComboEstado",
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
            $("#cmbEstado").append(option);
            y = y + 2;

        }




    }


}