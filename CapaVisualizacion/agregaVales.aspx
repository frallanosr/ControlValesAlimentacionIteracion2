<%@ Page Title="" Language="C#" MasterPageFile="~/maestraAdministrador.Master" AutoEventWireup="true" CodeBehind="agregaVales.aspx.cs" Inherits="CapaVisualizacion.agregaVales" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        

        <style type="text/css">
            #contenedor {

                width: 75%;
                height: 55%;
            }
            h2{
                font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
                font-size:medium;
            }
            h3{
                font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
                 font-size:medium;
            }
        </style>

        <form id="form1" runat="server">
            <center>
                <div id="contenedor">
                    <div id="Content">
                        <center>
                            <br />
                            <h2>ASIGNA VALE A RUT</h2>
                            <table border="0" style="align-content:center;">
                                <tr>
                                    <td>
                                        <h3>TURNO 4 ESPECIAL</h3>
                                        <br>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="rut_empleado" runat="server" placeholder="Ej:11-111-111-k" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El Rut Es Requerido" ControlToValidate="rut_empleado"
                                            CssClass="alert-danger" ValidationGroup="btn"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="cantidad" min="1" runat="server" TextMode="Number" CssClass="form-control" placeholder="Cantidad"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Cantidad de vales es requerido" Display="Dynamic"
                                            ControlToValidate="cantidad" CssClass="alert-danger" ValidationGroup="btn"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <asp:TextBox ID="fechatxt" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Fecha de vale es requerido" Display="Dynamic"
                                            ControlToValidate="fechatxt" CssClass="alert-danger" ValidationGroup="btn"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <center>
                                            <br />
                                            <asp:Button ID="Btn1" runat="server" onclick="Btn1_Click" Text="Agregar" CssClass="btn btn-danger" ValidationGroup="btn"
                                            />
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                </div>
            </center>
        </form>
    </asp:Content>