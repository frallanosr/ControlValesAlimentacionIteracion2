<%@ Page Title="" Language="C#" MasterPageFile="~/maestraTotemPrivilegio.Master" AutoEventWireup="true" CodeBehind="vistaConPrivilegio.aspx.cs" Inherits="CapaVisualizacion.vistaConPrivilegio" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <!--<script type="text/javascript">
            var int = self.setInterval("refresh()", 5000);
            function refresh() {
                location.reload(true);
            }

        </script>-->

        <link href="css/bootstrap.min.css" rel="stylesheet">
        <link href="css/datepicker3.css" rel="stylesheet">
        <link href="css/styles.css" rel="stylesheet">

        <style>
            p {
                size: 4px;
            }

            .inter {
                width: 400px;
                height: 400px;
                /*border: 1px solid blue;*/
                align-content: center;
            }

            .lado {}
        </style>

        <div>
            <%-- <p>USTED TIENE:<asp:Label ID="cantidadVales" runat="server" Text="Label"></asp:Label> VALES DISPONIBLES</p>--%>
                <p>
                   <p style="font-size:15px;" class="label label-primary"><asp:Label ID="nombreTurno" runat="server" Text="asdfg"></asp:Label></p>
                </p>
        </div>
        <center>

            <div>SELECCIONE CANTIDAD</div>
        </center>
        <table border="0">
            <tr>
                <td>
                    1
                    <asp:RadioButton ID="rb1" runat="server" Checked="true" GroupName="r" style="width:80%;height:80%" />
                </td>
                <td>
                    2
                    <asp:RadioButton ID="rb2" runat="server" GroupName="r" />
                </td>
                <td>
                    3
                    <asp:RadioButton ID="rb3" runat="server" GroupName="r" />
                </td>
                <td>
                    4
                    <asp:RadioButton ID="rb4" runat="server" GroupName="r" />
                </td>
                <td>
                    5
                    <asp:RadioButton ID="rb5" runat="server" GroupName="r" />
                </td>
            </tr>
        </table>
        <div class="inter">


            <%--  <asp:DropDownList ID="DropDownList1" runat="server" Width="108px">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:DropDownList>--%>


                <asp:Button ID="Button1" runat="server" Text="IMPRIMIR" style="height: 130px; width: 360px; margin:2px;" class="btn btn-primary"
                    OnClick="Button1_Click" />
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" style="height: 130px; width: 360px; margin:2px;" class="btn btn-primary"
                    Text="IMPRIMIR VALE ESPECIAL" />
                <br>
                <br>
                <br>
                <asp:Button ID="Button2" runat="server" Text="SALIR" OnClick="Button2_Click" style="height: 130px; width: 360px; margin:2px;"
                    class="btn btn-primary" />
        </div>

    </asp:Content>