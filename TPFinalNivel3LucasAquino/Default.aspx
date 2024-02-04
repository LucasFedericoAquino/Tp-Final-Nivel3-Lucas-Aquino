<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinal_3_ConComentarios.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

    <% 
        TextBox txtBuscarHome = (TextBox)Master.FindControl("txtBuscar");

        if (txtBuscarHome.Text != "")
        {
    %>
            <asp:Button Text="✖ Borrar Filtro" ID="BtnBorrarFiltro" OnClick="btnBorrarFiltro_Click" CssClass="btn btn-secondary btn-sm mt-4" runat="server" />
    <%
        }
        else
        {
    %>
            <h2 class="mt-4">Home</h2>
    <%
        }
    %>


    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater ID="Repetidor" runat="server">
            <ItemTemplate>

                <div class="col mt-5">

                    <div class="card">
                        <img src="<%#Eval("UrlImagen")%>" class="card-img-top" />

                        <div class="card-body">

                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>

                                    <h5 class="card-tittle"><%#Eval("Nombre")%> </h5>
                                    <h6 class="card-text mb-3"><%#String.Format("{0:C0}", Eval("Precio")) %></h6>
                                    <asp:Button Text="Ver detalles" CssClass="btn btn-primary" ID="btnVerDetalles" CommandArgument='<%#Eval("Id")%>' OnClick="btnVerDetalles_Click" runat="server" />
                                    <asp:Button Text="🤍" CssClass="btn btn-dark" ID="btnFavorito" CommandArgument='<%#Eval("Id") %>' OnClick="btnFavorito_Click" runat="server" />
                                </ContentTemplate>

                            </asp:UpdatePanel>

                        </div>
                    </div>

                </div>

            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
