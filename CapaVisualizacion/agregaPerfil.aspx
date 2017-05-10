<%@ Page Title="" Language="C#" MasterPageFile="~/maestraAdministrador.Master" AutoEventWireup="true" CodeBehind="agregaPerfil.aspx.cs" Inherits="CapaVisualizacion.agregaPerfil" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br>
        <script type="text/javascript" src="js/jquery.js"></script>
        <script src="js/alertifyjs/alertify.min.js"></script>
        <script src="js/modernizr-custom.js"></script>
        <link rel="stylesheet" type="text/css" href="css/stiloPopUp.css">

        <style type="text/css">
            #contenedor {

                border-left-style: solid;
                border-right-style: solid;
                border-top-style: solid;
                border-bottom-style: solid;
                width: 75%;
                height: 55%;
            }
        </style>
        <form id="form1" runat="server">
            <!--AREA DONDE SE CREA EL CONTENIDO DEL POPUP -->
            <div id="popup" style="display: none;">
                <div class="content-popup">
                    <div class="close">
                        <a href="#" id="close"><img src="images/close.png" /></a>
                    </div>
                    <div>
                        <center>
                            <h2>Agregar Perfil </h2>
                            <table border="0" style="align-content:center;">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="nombrePerfil" runat="server" CssClass="form-control" placeholder="Nombre Perfil"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nombre de perfil es requerido" Display="Dynamic"
                                            ControlToValidate="nombrePerfil" CssClass="alert-danger" ValidationGroup="btn"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <!--CODIGO COMBOBOX DROPDOWNLIST-->
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-secondary dropdown-toggle">
                                            <asp:ListItem Selected="True" Value="0" CssClass="form-control">- Tipo Usuario -</asp:ListItem>
                                            <asp:ListItem Value="normal">Normal</asp:ListItem>
                                            <asp:ListItem Value="conPrivilegios">Con Privilegios</asp:ListItem>
                                            <asp:ListItem Value="cajero">Cajero</asp:ListItem>
                                            <asp:ListItem Value="administrador">Administrador</asp:ListItem>

                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0" ErrorMessage="El tipo de usuario es requerido"
                                            Display="Dynamic" ControlToValidate="DropDownList1" CssClass="alert-danger" ValidationGroup="btn"></asp:RequiredFieldValidator>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <center>
                                            <br />
                                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Agregar" CssClass="btn btn-danger" ValidationGroup="btn"
                                            />
                                        </center>
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </div>
                </div>
            </div>
            <center>
                <div id="contenedor">
                    <div id="Content">
                        <center>
                            <br />
                            <p>
                                <a id="open">

                                    <span class="glyphicon glyphicon-plus"></span>

                                    <span> Agregar Perfil</span>
                                </a>
                            </p>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None"
                                BorderWidth="1px" CellPadding="4" CssClass="table" DataKeyNames="IDPERFIL" DataSourceID="SqlDataSource1"
                                OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="IDPERFIL" HeaderText="ID" ReadOnly="True" SortExpression="IDPERFIL" />
                                    <asp:BoundField DataField="P_CARGO" HeaderText="CARGO" SortExpression="P_CARGO" />
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" HeaderText="ACCIONES" />
                                </Columns>
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#003399" BackColor="White" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />
                            </asp:GridView>

                        </center>
                    </div>
                    <br />
                    <br />
                </div>
            </center>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="UPDATE &quot;PERFIL&quot; SET &quot;P_ESTADO&quot; = 0 WHERE &quot;IDPERFIL&quot; = :IDPERFIL"
                InsertCommand="INSERT INTO &quot;PERFIL&quot; (&quot;IDPERFIL&quot;, &quot;P_CARGO&quot;, &quot;P_ESTADO&quot;, &quot;P_TIPOUSUARIO&quot;) VALUES (:IDPERFIL, :P_CARGO, :P_ESTADO, :P_TIPOUSUARIO)"
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;IDPERFIL&quot;, &quot;P_CARGO&quot; FROM &quot;PERFIL&quot; where &quot;P_ESTADO&quot; = 1"
                UpdateCommand="UPDATE &quot;PERFIL&quot; SET &quot;P_CARGO&quot; = :P_CARGO, &quot;P_ESTADO&quot; = :P_ESTADO, &quot;P_TIPOUSUARIO&quot; = :P_TIPOUSUARIO WHERE &quot;IDPERFIL&quot; = :IDPERFIL">
                <DeleteParameters>
                    <asp:Parameter Name="IDPERFIL" Type="Decimal" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="IDPERFIL" Type="Decimal" />
                    <asp:Parameter Name="P_CARGO" Type="String" />
                    <asp:Parameter Name="P_ESTADO" Type="String" />
                    <asp:Parameter Name="P_TIPOUSUARIO" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="P_CARGO" Type="String" />
                    <asp:Parameter Name="P_ESTADO" Type="String" />
                    <asp:Parameter Name="P_TIPOUSUARIO" Type="String" />
                    <asp:Parameter Name="IDPERFIL" Type="Decimal" />
                </UpdateParameters>
            </asp:SqlDataSource>

        </form>

        <script type="text/javascript">
            $(document).ready(function () {
                $('#open').click(function () {
                    $('#popup').fadeIn('slow');
                    $('.popup-overlay').fadeIn('slow');
                    $('.popup-overlay').height($(window).height());
                    return false;
                });

                $('#close').click(function () {
                    $('#popup').fadeOut('slow');
                    $('.popup-overlay').fadeOut('slow');
                    return false;
                });

                /*   $("#Button1").on("click",function(e){
                     e.preventDefault();//evita que la pagina se recargue 
       
                     var nombrePerfil = $("#nombrePerfil").val();
                     if (nombrePerfil.trim()=="") {
                       warning("Debe ingresar el nombre del perfil");
                       ingresarError("No se ingreso nombre de perfil");
                     }
                   )};
       */
            });
        </script>

    </asp:Content>