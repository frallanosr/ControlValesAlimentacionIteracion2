<%@ Page Title="" Language="C#" MasterPageFile="~/maestraAdministrador.Master" AutoEventWireup="true" CodeBehind="agregaVales.aspx.cs" Inherits="CapaVisualizacion.agregaVales" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <script type="text/javascript" src="js/jquery.js"></script>
        <script src="js/alertifyjs/alertify.min.js"></script>
        <script src="js/modernizr-custom.js"></script>
        <link rel="stylesheet" type="text/css" href="css/stiloPopUp.css">

        <style type="text/css">
            #contenedor {
           
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
                            <h2>Definir Vales</h2>
                            <table border="0" style="align-content:center;">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="rut_empleado" runat="server" placeholder="Ej:11-111-111-k"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El Rut Es Requerido"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                        <!--CODIGO COMBOBOX DROPDOWNLIST-->
                                        <asp:DropDownList ID="DropDownList3" runat="server" cssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="P_CARGO"
                                            DataValueField="P_CARGO">
                                        </asp:DropDownList>
                                    </td>
                                </tr>


                                <tr>
                                    <td>
                                        <br>
                                        <asp:TextBox ID="valorVale" runat="server" TextMode="Number" CssClass="form-control" placeholder="Valor Vale"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Valor de vale es requerido" Display="Dynamic"
                                            ControlToValidate="valorVale" CssClass="alert-danger" ValidationGroup="btn"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br>
                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="T_NOMBRE"
                                            DataValueField="IDTURNO"></asp:DropDownList>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' ProviderName='<%$ ConnectionStrings:ConnectionString.ProviderName %>'
                                            SelectCommand='SELECT "T_NOMBRE", "IDTURNO" FROM "TURNO"'></asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                         <asp:TextBox ID="cantidad" runat="server" TextMode="Number" CssClass="form-control" placeholder="Cantidad"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Cantidad de vales es requerido" Display="Dynamic"
                                            ControlToValidate="valorVale" CssClass="alert-danger" ValidationGroup="btn"></asp:RequiredFieldValidator>
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
            </div>


            <center>
                <div id="contenedor">
                    <div id="Content">
                        <center>
                            <br />
                            <p>
                                <a id="open">

                                    <span class="glyphicon glyphicon-plus"></span>

                                    <span> Definir Vale</span>
                                </a>
                            </p>


                        </center>
                    </div>
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource3" CssClass="table" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="IDVALE">
                        <Columns>
                            <asp:BoundField DataField="IDVALE" HeaderText="N° Vale" SortExpression="IDVALE" ReadOnly="True" />
                            <asp:BoundField DataField="V_VALOR" HeaderText="VALOR" SortExpression="V_VALOR" />
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SortedAscendingCellStyle BackColor="#EDF6F6" />
                        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                        <SortedDescendingCellStyle BackColor="#D6DFDF" />
                        <SortedDescendingHeaderStyle BackColor="#002876" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;IDVALE&quot;, &quot;V_VALOR&quot; FROM &quot;VALE&quot; WHERE USUARIO_TURNO_USUARIO_RUT = '184155842'
"></asp:SqlDataSource>
                    <br />

                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
                        SelectCommand="SELECT &quot;P_CARGO&quot; FROM &quot;PERFIL&quot;"></asp:SqlDataSource>
                    <br />
                </div>
            </center>

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


            });
        </script>



    </asp:Content>