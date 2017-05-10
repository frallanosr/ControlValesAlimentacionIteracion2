<%@ Page Title="" Language="C#" MasterPageFile="~/maestraAdministrador.Master" AutoEventWireup="true" CodeBehind="agregaUsuario.aspx.cs" Inherits="CapaVisualizacion.agregaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        #contenedor{
            border-left-style: solid;
            border-right-style: solid;
            border-top-style: solid;
            border-bottom-style: solid;
            width: 75%;
            height: 55%;
        }
    </style>
     <center>
<div id="contenedor" >
    <form id="form1" runat="server" onsubmit="javascript:return WebForm_OnSubmit();">
        <br />
        <br />
        <center>
                <table border="0">
        <tr>
            <td>
               <asp:Label ID="Label1" runat="server" Text="Rut:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="rut" runat="server" CssClass="form-control" OnTextChanged="rut_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rut" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="btn">Es requerido</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Nombre:" ></asp:Label>
            </td>
            <td>

                <asp:TextBox ID="nombre" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="nombre" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="btn">Es requerido</asp:RequiredFieldValidator>

            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Apellido Paterno:"></asp:Label>            
            </td>
            <td>

                <asp:TextBox ID="appaterno" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="appaterno" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="btn">Es requerido</asp:RequiredFieldValidator>

            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Apellido Materno:"></asp:Label>
            </td>
            <td>

                <asp:TextBox ID="amaterno" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="amaterno" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="btn">Es requerido</asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
          <br />
            <td>
                <asp:Label ID="Label77" runat="server" Text="Email:"></asp:Label>
            </td>
            <td>
                 <asp:TextBox ID="email" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Contraseña:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="contraseña" runat="server" CssClass="form-control"></asp:TextBox>

               <!-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="contraseña" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="btn">Es requerido</asp:RequiredFieldValidator> -->

            </td>
              <td>
                  <asp:Button ID="Button2" runat="server" Text="Generar" CssClass="btn btn-primary" OnClick="Button2_Click"></asp:Button>
              </td>
        </tr>
          <tr>
            <td>
             <asp:Label ID="Label6" runat="server" Text="Tipo de Usuario:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="P_CARGO" DataValueField="IDPERFIL">
                    <asp:ListItem Selected="True">--Seleccione--</asp:ListItem>
                    <asp:ListItem Value="administrador">Administrador</asp:ListItem>
                    <asp:ListItem Value="cajero">Cajero</asp:ListItem>
                    <asp:ListItem Value="obrero">Obrero</asp:ListItem>
                    <asp:ListItem Value="Secretari">Secretari@</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;P_CARGO&quot;, &quot;IDPERFIL&quot; FROM &quot;PERFIL&quot;"></asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DropDownList1" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="btn">Es requerido</asp:RequiredFieldValidator>
            </td>
        </tr>
               <%--     <tr>
                        <td>
<asp:Label ID="Label7" runat="server" Text="Cargo:"></asp:Label>
                        </td>
                        <td>
<asp:TextBox ID="cargo" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="cargo" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="btn">Es requerido</asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
    <tr>
        <td>

        </td>
        <td>
<asp:Button ID="Button1" runat="server" Text="Agregar" CssClass="btn btn-danger" ValidationGroup="btn" OnClick="Button1_Click"></asp:Button>
        </td>
    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
       
    </table>
            </center>

  
</form>
</div>
</center>
</asp:Content>
