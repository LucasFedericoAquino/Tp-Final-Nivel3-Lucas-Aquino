<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="DetallesArticulo.aspx.cs" Inherits="TPFinal_3_ConComentarios.DetallesArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

    <div class="row">

        <div class="col-md-4 mt-5">
            <!-- Primera columna -->

            <div class="mb-3">
                <label for="txtNombre" class="form-label" style="font-weight: 600">Artículo</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label" style="font-weight: 600">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select disabled" Style="background-color: #fff; color: #000;" Enabled="false" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label" style="font-weight: 600">Especificaciones</label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server" />
            </div>

            <div class="mb-4">
                <label for="txtPrecio" class="form-label" style="font-weight: 600">Precio</label>
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" />
            </div>

            <div class="mb-2">
                <asp:Label ID="lblStock" Text="Stock:" Style="font-weight: 600" CssClass="form-label" runat="server" />
                <asp:Label ID="lblDisponibilidad" Text="" Style="font-weight: 600" CssClass="form-label" runat="server" />
            </div>

        </div>

        <div class="col-md-4 mt-md-5">

            <!-- Segunda columna -->


            <asp:UpdatePanel ID="updatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-4">
                        <asp:TextBox ID="txtImagenUrl" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" runat="server" />
                    </div>
                    <div class="row align-items-center">
                        <div class="col-md-12 col-mb-0 mb-5 text-center">
                            <asp:Image ImageUrl="https://seetruetechnology.com/wp-content/uploads/2022/02/BG-7.jpg"
                                ID="imgArticulo" CssClass="img-fluid" runat="server" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <!-- Cierre de la segunda columna -->

    </div>

</asp:Content>
