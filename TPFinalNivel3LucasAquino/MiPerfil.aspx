<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TPFinal_3_ConComentarios.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="mt-4">Mi Perfil</h2>

    <div class="row">
        <div class="col-md-3 mt-md-4 mt-3">

            <div class="mb-3">
                <asp:Label Text="Email" runat="server" />
                <asp:TextBox ID="txtEmail" CssClass="form-control mt-2" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Label Text="Nombre" runat="server" />
                <asp:TextBox ID="txtNombre" CssClass="form-control mt-2" runat="server" />
                <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" ControlToValidate="txtNombre" ValidationExpression="[A-Za-z]+" runat="server" ErrorMessage="*No se permiten números o símbolos." Style="color: red; font-size: 12px;"></asp:RegularExpressionValidator>

            </div>

            <div class="mb-3">
                <asp:Label Text="Apellido" runat="server" />
                <asp:TextBox ID="txtApellido" CssClass="form-control mt-2" runat="server" />
                <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator2" ControlToValidate="txtApellido" ValidationExpression="[A-Za-z]+" runat="server" ErrorMessage="*No se permiten números o símbolos." Style="color: red; font-size: 12px;"></asp:RegularExpressionValidator>

            </div>

        </div>

        <div class="col-md-3 mt-md-4 mt-1">
            <div class="mb-4">
                <label class="form-label">Imagen de Perfil</label>
                <input type="file" id="txtImagen" class="form-control" onchange="mostrarImagen()" runat="server">
            </div>

            <div class="col-md-12 text-center">
                <asp:Image ImageUrl="https://media.istockphoto.com/id/1147544807/es/vector/no-imagen-en-miniatura-gr%C3%A1fico-vectorial.jpg?s=612x612&w=0&k=20&c=Bb7KlSXJXh3oSDlyFjIaCiB9llfXsgS7mHFZs6qUgVk="
                    ID="imagenPerfil" CssClass="img-fluid mb-md-0 mb-4" Width="80%" runat="server" />
            </div>
        </div>


        <div class="row">
            <div class="col-md-4 mb-5">
                <asp:Button Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary me-0" runat="server" />
                <a href="Default.aspx" class="ms-2">Volver</a>
            </div>
        </div>

    </div>


</asp:Content>
