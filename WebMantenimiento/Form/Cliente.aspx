<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site1.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="WebMantenimiento.Form.Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <%--<script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>--%>
    <script src="../Bootstrap/js/jquery-3.5.1.js"></script>
    <%--<script src="../assets/js/jquery-1.12.4.js"></script>--%>
    <script src="../Bootstrap/js/bootstrap.min.js"></script>
    <script src="../Bootstrap/js/jquery.dataTables.min.js"></script>
    <script src="../Bootstrap/js/dataTables.bootstrap5.min.js"></script>
   
   <%-- <link href="../Bootstrap/css/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="../Bootstrap/css/bootstrap1.min.css" rel="stylesheet" />
    <link href="../Bootstrap/css/dataTables.bootstrap5.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h2 style='text-align:center; width:1050px;margin:0 auto'>Modulo de Cliente</h2>
 <div id="formCliente"></div>

 <div id="formClienteVehiculo" style="display:none"></div>
     <div id="formClienteMantenimiento" style="display:none"></div>
  
    <div style="display:none" id="formDetCliente"></div>
 <div id="divHistorial" style='text-align:center; width:1050px;margin:0 auto'> </div>
    <div id="divHistorialVehiculo" style='text-align:center; width:1050px;margin:0 auto;display:none'> </div>
    <div id="divHistorialMantenimiento" style='text-align:center; width:1050px;margin:0 auto;display:none'> </div>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.6.2/jquery.min.js" type="text/javascript"></script>
  <%--  <script src="../assets/js/jquery.min.js"></script>--%>
    
    <script src="../js/FormCliente.js"></script>
    <script src="../js/FormMantenimiento.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            FormClienteIng("cl");
           

        });
    </script>
</asp:Content>
