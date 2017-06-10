<%@ Page Title="" Language="C#" MasterPageFile="~/maestraLogin.Master" AutoEventWireup="true" CodeBehind="LoginAdm.aspx.cs" Inherits="CapaVisualizacion.LoginAdm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <html>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>

    <head>

        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">

        <title>Inicio de Sesión</title>

        <link href="css/bootstrap.min.css" rel="stylesheet"/>
        <link href="css/datepicker3.css" rel="stylesheet"/>
        <link href="css/styles.css" rel="stylesheet"/>
        <style>
        .btn {
            border-radius: 3.5px;
            padding: 3px 7px;
            font-family: 'courier';
            font-size: 15px;
            background-color: dodgerblue;
        }

            .btn:hover {
                background-color: Highlight;
            }
    </style>
    </head>

    <body>

        <div class="row">
            <div class="col-xs-10 col-xs-offset-1 col-sm-8 col-sm-offset-2 col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading"></div>
                    <div class="panel-body">
                        <form role="form" id="multiple-events">
                            
                                
                                    <%--<legend>Acceso&nbsp;&nbsp;&nbsp;</legend>--%>
                                
                                <div class="form-group ">
                                    <asp:TextBox ID="rut" name="rut" placeholder="Rut" class="input_rut form-control col-lg-4" onfocus="lastfocus = this;" autofocus="autofocus" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="rut" Display="Dynamic" ForeColor="Red" ValidationGroup="btn">EL RUT ES REQUERIDO</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <center>
                                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                        </center>
                                    <asp:TextBox ID="pass" name="pass" runat="server" class="form-control" placeholder="Contraseña" type="password" onfocus="lastfocus = this;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="pass" Display="Dynamic" ForeColor="Red" ValidationGroup="btn">LA CONTRASEÑA ES REQUERIDA</asp:RequiredFieldValidator>
                                </div>
                                

                                    <div align="center" style="padding-top: 10px">
                                        <asp:Button ID="Button1" runat="server" Text="INGRESAR" style="height: 40px; width: 160px;" CssClass="btn btn-primary btn-sm btn-bloc" OnClick="Button1_Click" ValidationGroup="btn" />
                                    </div>
                            </form>

                                </div>
                          
                    </div>
                </div>
                <p style="margin-left: 1400px; margin-bottom:initial;  max-width:100%;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="arrow" PostBackUrl="~/Login.aspx"><img src="images/flechaIz.png" /></asp:LinkButton>
        
            </p>
            </div>
            


        
       

    </body>
        <script src="js/jquery-1.11.1.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/chart.min.js"></script>
        <script src="js/chart-data.js"></script>
        <script src="js/easypiechart.js"></script>
        <script src="js/easypiechart-data.js"></script>
        <script src="js/bootstrap-datepicker.js"></script>

    </html>

</asp:Content>
