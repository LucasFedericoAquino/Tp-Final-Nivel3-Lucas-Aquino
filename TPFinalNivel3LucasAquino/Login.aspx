<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinal_3_ConComentarios.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-4">
            <h2 class="mt-3">Login</h2>

            <div class="mb-3 mt-3">
                <label for="txtCorreo" class="form-label">Correo</label>
                <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator Display="Dynamic" ID="validaVacio" runat="server" ErrorMessage="*Ingrese el correo." ControlToValidate="txtCorreo" Style="color: red; font-size: 12px;"></asp:RequiredFieldValidator>
            </div>

            <div class="mb-4">
                <label for="txtPass" class="form-label">Contraseña</label>
                <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator Display="Dynamic" ID="validaVacio2" runat="server" ErrorMessage="*Ingrese la contraseña." ControlToValidate="txtPass" Style="color: red; font-size: 12px;"></asp:RequiredFieldValidator>
            </div>

            <div class="mb-3">
                <asp:Button Text="Ingresar" ID="btnIngresar" OnClick="btnIngresar_Click" CssClass="btn btn-primary me-2" runat="server" />
                <a href="Default.aspx">Cancelar</a>
            </div>

                <asp:Label Text="" ID="lblError" Style="color: red; font-size:14px;" runat="server" />

        </div>
    </div>


</asp:Content>
