<%@ Page Title="" Language="C#" MasterPageFile="~/maestraAdministrador.Master" AutoEventWireup="true" CodeBehind="agregaTurno.aspx.cs" Inherits="CapaVisualizacion.agregaTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form runat="server">
    <asp:TextBox ID="nombreDelTurno" required="true" runat="server" CssClass="form-control" placeholder="Nombre del Turno" ></asp:TextBox>   
    <asp:TextBox ID="horaInicio" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
    <asp:TextBox ID="horaFin" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
    
</form>
</asp:Content>
