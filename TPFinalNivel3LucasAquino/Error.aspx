<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPFinal_3_ConComentarios.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-6 mt-md-4 mt-4">

            <h2 class="mb-3">Hubo un problema </h2>

            <asp:Label Text="text" ID="lblMensaje" runat="server" />
            <br />
            <br />
            <a href="Default.aspx">Volver</a>

        </div>
    </div>


</asp:Content>
