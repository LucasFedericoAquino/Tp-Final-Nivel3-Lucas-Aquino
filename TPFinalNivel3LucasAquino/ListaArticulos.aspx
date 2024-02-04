<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="TPFinal_3_ConComentarios.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="mt-4">Lista de Artículos</h2>

    <div class="row">
        <div class="col-lg-auto">
            <div class="m-3 d-flex align-items-center">
                <asp:Label Text="Filtro Rápido:" CssClass="mr-5" runat="server" Style="white-space: nowrap; font-weight: 700; font-size: 18px" />
                <asp:TextBox ID="txtFiltroRapido" PlaceHolder="Nombre de Artículo" AutoPostBack="true" OnTextChanged="txtFiltroRapido_TextChanged" CssClass="form-control m-2" runat="server" />

                <div class="row-cols-8 m-md-8 d-flex align-items-center">
                    <asp:CheckBox CssClass="m-1" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" runat="server" ID="chkAvanzado" />
                    <label style="white-space: nowrap;" for="chkAvanzado">Filtro Avanzado</label>
                </div>

            </div>

            <% if (!string.IsNullOrEmpty(txtFiltroRapido.Text))
                { %>
            <asp:Button Text="✖ Borrar Filtro" ID="btnBorrarFiltroRapido" OnClick="btnBorrarFiltroRapido_Click" CssClass="btn btn-secondary btn-sm" runat="server" />
            <% } %>

        </div>
    </div>

    <% if (FiltroAvanzado)
        { %>

    <div class="row">
        <div class="col-md-2 col-4">
            <div class="mb-4">
                <asp:Label Text="Campo" runat="server" />
                <asp:DropDownList CssClass="form-control mt-1" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" runat="server">
                    <asp:ListItem Text="Código" Selected="True" />
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Descripción" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoría" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="col-md-2 col-4">
            <div class="mb-3">
                <asp:Label Text="Criterio" runat="server" />

                <asp:DropDownList CssClass="form-control mt-1" ID="ddlCriterio" runat="server">
                    <asp:ListItem Text="Comienza con" />
                    <asp:ListItem Text="Termina con" />
                    <asp:ListItem Text="Contiene" />

                </asp:DropDownList>
            </div>
        </div>

        <div class="col-md-2 col-4">
            <div class="mb-3">
                <asp:Label Text="Palabra Clave" ID="Label2" runat="server" />
                <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control mt-1" runat="server" />
            </div>
        </div>

    </div>

    <div class="row">
        <div class="col-md-5 col-6">
            <div class="mb-3">
                <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-primary me-2" OnClick="btnBuscar_Click" runat="server" />

                <% if (!string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                    { %>
                <asp:Button Text="✖ Borrar Filtro" ID="btnBorrarFiltro" OnClick="btnBorrarFiltro_Click" CssClass="btn btn-secondary btn-sm" runat="server" />
                <% } %>
            </div>
        </div>
    </div>

    <%  } %>


    <asp:GridView ID="dgvArticulos" DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" CssClass="table mt-3" runat="server">

        <Columns>

            <asp:BoundField HeaderText="Código" DataField="Codigo" HeaderStyle-CssClass="bg-dark text-white" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" HeaderStyle-CssClass="bg-dark text-white" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" HeaderStyle-CssClass="bg-dark text-white" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" HeaderStyle-CssClass="bg-dark text-white" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" HeaderStyle-CssClass="bg-dark text-white" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍" HeaderStyle-CssClass="bg-dark text-white" />

        </Columns>

    </asp:GridView>

    <a href="FormularioArticulos.aspx" class="btn btn-primary mb-5 mt-3" id="btnAgregar">Agregar</a>

</asp:Content>
