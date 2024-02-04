<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPFinal_3_ConComentarios.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

    <h2 class="mt-4">Mis Favoritos</h2>

    <asp:Label Text="" ID="lblFavoritos" runat="server" />

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater ID="Repetidor" runat="server">
            <ItemTemplate>
                <div class="col mt-5">

                    <div class="card">
                        <img src="<%#Eval("UrlImagen")%>" class="card-img-top" />

                        <div class="card-body">

                            <h5 class="card-tittle"><%#Eval("Nombre")%> </h5>
                            <h6 class="card-text mb-3"><%#String.Format("{0:C0}", Eval("Precio")) %></h6>
                            <asp:Button Text="Ver detalles" CssClass="btn btn-primary" ID="btnVerDetalles" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloID" OnClick="btnVerDetalles_Click" runat="server" />
                            <asp:Button Text="🧡" CssClass="btn btn-dark" AutoPostBack="true" ID="btnDesmarcarFavorito" CommandArgument='<%#Eval("Id") %>' OnClick="btnDesmarcarFavorito_Click" runat="server" />

                        </div>
                    </div>

                </div>

            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
