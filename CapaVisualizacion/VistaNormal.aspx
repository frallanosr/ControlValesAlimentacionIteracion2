<%@ Page Title="" Language="C#" MasterPageFile="~/maestraTotem.Master" AutoEventWireup="true" CodeBehind="VistaNormal.aspx.cs" Inherits="CapaVisualizacion.VistaNormal" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <script type="text/javascript">
            var int = self.setInterval("refresh()", 3000);
    function refresh()
    {
        location.reload(true);
    }
</script>

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
           <%-- <p>USTED TIENE:<asp:Label ID="cantidadVales" runat="server" Text="Label"></asp:Label> VALES DISPONIBLES</p>--%> <p><asp:Label ID="nombreTurno" runat="server" Text="asdfg"></asp:Label></p>
        </div>
        
        <div class="inter">

            <br>
            <br>

            <asp:Button ID="Button1" runat="server" Text="IMPRIMIR" style="height: 130px; width: 360px; margin:2px;" class="btn btn-primary" OnClick="Button1_Click"
            />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" style="height: 130px; width: 360px; margin:2px;" class="btn btn-primary" Text="IMPRIMIR VALE ESPECIAL" />
            <br>
            <br>
            <br>
            <asp:Button ID="Button2" runat="server" Text="SALIR" OnClick="Button2_Click" style="height: 130px; width: 360px; margin:2px;"
                class="btn btn-primary" />
        </div>
    </asp:Content>