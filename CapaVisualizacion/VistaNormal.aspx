<%@ Page Title="" Language="C#" MasterPageFile="~/maestraTotem.Master" AutoEventWireup="true" CodeBehind="VistaNormal.aspx.cs" Inherits="CapaVisualizacion.VistaNormal" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <link href="css/bootstrap.min.css" rel="stylesheet">
        <link href="css/datepicker3.css" rel="stylesheet">
        <link href="css/styles.css" rel="stylesheet">

        <style>
          p{
              size: 4px;
          }
          .inter{
              width: 400px; 
              height: 400px; 
              /*border: 1px solid blue;*/
              align-content: center;
          }
        </style>

        <div>
            <p>USTED TIENE:<asp:Label ID="cantidadVales" runat="server" Text="Label"></asp:Label> VALES DISPONIBLES</p>
        </div>
        <div class="inter">

            <br>
            <br>

            <asp:Button ID="Button1" runat="server" Text="IMPRIMIR" style="height: 130px; width: 360px; margin:2px;" class="btn btn-primary" OnClick="Button1_Click"
            />
            <br>
            <br>
            <br>
            <asp:Button ID="Button2" runat="server" Text="SALIR" OnClick="Button2_Click" style="height: 130px; width: 360px; margin:2px;"
                class="btn btn-primary" />
        </div>
    </asp:Content>