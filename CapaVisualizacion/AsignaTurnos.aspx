<%@ Page Title="" Language="C#" MasterPageFile="~/maestraAdministrador.Master" AutoEventWireup="true" CodeBehind="AsignaTurnos.aspx.cs" Inherits="CapaVisualizacion.AsignaTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
    <div> 
        <p>ASIGNA TURNOS AUTOMATICAMETE</p>
    <asp:button runat="server" text="ASIGNAR TURNOS" />
    </div>
        <asp:gridview runat="server"></asp:gridview>
</form>
</asp:Content>
