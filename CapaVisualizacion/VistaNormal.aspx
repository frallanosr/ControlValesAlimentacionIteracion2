﻿<%@ Page Title="" Language="C#" MasterPageFile="~/maestraTotem.Master" AutoEventWireup="true" CodeBehind="VistaNormal.aspx.cs" Inherits="CapaVisualizacion.VistaNormal" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <link href="css/bootstrap.min.css" rel="stylesheet">
        <link href="css/datepicker3.css" rel="stylesheet">
        <link href="css/styles.css" rel="stylesheet">
        <div>
            <p>USTED TIENE:<asp:Label ID="cantidadVales" runat="server" Text="Label"></asp:Label> VALES DISPONIBLES</p>
        </div>
        <div style="width: 400px; height: 400px; border: 1px solid blue;align-content: center;">

            <br>
            <br>

            <asp:Button ID="Button1" runat="server" Text="IMPRIMIR" style="height: 130px; width: 360px; margin:2px;" class="btn btn-primary"
            />
            <br>
            <br>
            <br>
            <asp:Button ID="Button2" runat="server" Text="SALIR" OnClick="Button2_Click" style="height: 130px; width: 360px; margin:2px;"
                class="btn btn-primary" />
        </div>
    </asp:Content>