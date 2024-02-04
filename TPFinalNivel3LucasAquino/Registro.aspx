<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinal_3_ConComentarios.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-4">
            <h2 class="mt-3">Registro</h2>

            <div class="mb-3 mt-3">
                <label for="txtCorreo" class="form-label">Correo</label>
                <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator Display="Dynamic" ID="validaVacio" runat="server" ErrorMessage="*Ingrese el correo." ControlToValidate="txtCorreo" Style="color: red; font-size: 12px; white-space: nowrap;"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" ControlToValidate="txtCorreo" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" ErrorMessage="*Ingrese un formato de email.." Style="color: red; font-size: 12px;"></asp:RegularExpressionValidator>
            </div>

            <div class="mb-4">
                <label for="txtPass" class="form-label">Contraseña</label>
                <asp:TextBox ID="txtPass" TextMode="Password" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator Display="Dynamic" ID="validaVacio2" runat="server" ErrorMessage="*Ingrese la contraseña." ControlToValidate="txtPass" Style="color: red; font-size: 12px; white-space: nowrap;"></asp:RequiredFieldValidator>
            </div>

            <div class="mb-3">
                <asp:Button Text="Registrarme" ID="btnAceptarRegistro" CssClass="btn btn-success me-2" OnClick="btnAceptarRegistro_Click" runat="server" />
                <a href="Default.aspx">Cancelar</a>
            </div>

        </div>
    </div>

</asp:Content>
