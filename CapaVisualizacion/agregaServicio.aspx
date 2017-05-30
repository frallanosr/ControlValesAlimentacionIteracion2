<%@ Page Title="" Language="C#" MasterPageFile="~/maestraAdministrador.Master" AutoEventWireup="true" CodeBehind="agregaServicio.aspx.cs" Inherits="CapaVisualizacion.agregaServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <form id="form1" runat="server">
	<script type="text/javascript" src="js/jquery.js"></script>
     <script src="js/alertifyjs/alertify.min.js"></script>
     <script src="js/modernizr-custom.js"></script>
     <link rel="stylesheet" type="text/css" href="css/stiloPopUp.css">
	<style type="text/css">
		#contenedor{
			
			width: 75%;
			height: 55%;
		}
		#divGridPopUp{
                background-color: red;

		}
        #cont{
        	background-color: red;
        }
	</style>
	
	  <!--AREA DONDE SE CREA EL CONTENIDO DEL POPUP -->
       <div id="popup" style="display: none;" >
          <div class="content-popup" >
              <div class="close"><a href="#" id="close"><img src="images/close.png"/></a></div>
             
                      <div>
                         <center>
                             <h2>Agregar Servicio</h2>
                         </center>
                        
                         <table border="1">
                         	<tr>
                         		<td></td>
                         		<td></td>
                         		<td></td>
                         		<td></td>
                         	</tr>
                         </table>
                          <asp:TextBox ID="nombreDelServicio" required="true" runat="server" CssClass="form-control" placeholder="Nombre del servicio" ></asp:TextBox>   

                          <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="P_CARGO" DataValueField="IDPERFIL"></asp:DropDownList>

                          <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' ProviderName='<%$ ConnectionStrings:ConnectionString.ProviderName %>' SelectCommand='SELECT "P_CARGO","IDPERFIL" FROM "PERFIL"'></asp:SqlDataSource>

                          <asp:TextBox ID="valorDelServicio" runat="server" required="true" CssClass="form-control" placeholder="Valor del servicio" ></asp:TextBox>   
                          
                          <table border="0">
                              <tr>
                                  <td>Hora Inicio:</td>
                                  <td width="30%">
                                      
                                      <asp:TextBox ID="horaInicio" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
                                  </td><td><span class="glyphicon">&#xe141;</span></td>
                                  <td>Hora Término:</td>
                                  <td width="30%">
                                  <asp:TextBox ID="horaFin" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>    
                                  </td><td><span class="glyphicon">&#xe141;</span></td>
                              </tr>
                          </table>       
                          <center>
                              <asp:Button ID="Button1" runat="server" Text="Agregar" OnClick="Button1_Click" CssClass="btn btn-danger" ValidationGroup="btn"/>
                          </center>                  
                      </div>
                </div>
                </div>
	
    <center>

    <!--Contenedor principal -->
    <div id="contenedor" >
    	        <p>
                  <a id="open" >
                       <br />
                    <span class="glyphicon glyphicon-plus"></span>
                        Agregar Servicio
                  </a>
                </p>
                <p>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table"  BorderWidth="1px" CellPadding="4"  DataKeyNames="IDSERVICIO" DataSourceID="SqlDataSource2" GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="IDSERVICIO" HeaderText="ID" ReadOnly="True" SortExpression="IDSERVICIO" />
                            <asp:BoundField DataField="SE_NOMBRE" HeaderText="NOMBRE SERVICIO" SortExpression="SE_NOMBRE" />
                            <asp:BoundField DataField="EXPR1" HeaderText="HR INICIO" SortExpression="EXPR1" />
                            <asp:BoundField DataField="EXPR2" HeaderText="HR TÉRMINO" SortExpression="EXPR2" />
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
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM &quot;SERVICIO&quot; WHERE &quot;IDSERVICIO&quot; = :IDSERVICIO" InsertCommand="INSERT INTO &quot;SERVICIO&quot; (&quot;IDSERVICIO&quot;, &quot;SE_NOMBRE&quot;, &quot;SE_VALOR&quot;, &quot;SE_INICIO&quot;, &quot;SE_TERMINO&quot;, &quot;SE_NOMBREPERFIL&quot;) VALUES (:IDSERVICIO, :SE_NOMBRE, :SE_VALOR, :SE_INICIO, :SE_TERMINO, :SE_NOMBREPERFIL)" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT IDSERVICIO, SE_NOMBRE, to_char(SE_INICIO, 'HH:MI') AS EXPR1, to_char(SE_TERMINO, 'HH:MI') AS EXPR2 FROM SERVICIO" UpdateCommand="UPDATE &quot;SERVICIO&quot; SET &quot;SE_NOMBRE&quot; = :SE_NOMBRE, &quot;SE_INICIO&quot; = :SE_INICIO, &quot;SE_TERMINO&quot; = :SE_TERMINO,WHERE &quot;IDSERVICIO&quot; = :IDSERVICIO">
                        <DeleteParameters>
                            <asp:Parameter Name="IDSERVICIO" Type="Decimal" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="IDSERVICIO" Type="Decimal" />
                            <asp:Parameter Name="SE_NOMBRE" Type="String" />
                            <asp:Parameter Name="SE_VALOR" Type="Decimal" />
                            <asp:Parameter Name="SE_INICIO" Type="DateTime" />
                            <asp:Parameter Name="SE_TERMINO" Type="DateTime" />
                         
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="SE_NOMBRE" Type="String" />
                            <asp:Parameter Name="SE_INICIO" Type="DateTime" />
                            <asp:Parameter Name="SE_TERMINO" Type="DateTime" />
                            <asp:Parameter Name="IDSERVICIO" Type="Decimal" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </p> 
    </div>
      
    
         </center>

      <script type="text/javascript">
        $(document).ready(function(){
          $('#open').click(function(){
                $('#popup').fadeIn('slow');
                $('.popup-overlay').fadeIn('slow');
                $('.popup-overlay').height($(window).height());
                return false;
            });
            
            $('#close').click(function(){
                $('#popup').fadeOut('slow');
                $('.popup-overlay').fadeOut('slow');
                return false;
            });
        });
    </script>
    </form>
</asp:Content>
