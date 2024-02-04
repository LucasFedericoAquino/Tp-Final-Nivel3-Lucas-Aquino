<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioArticulos.aspx.cs" Inherits="TPFinal_3_ConComentarios.FormularioArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

    <div class="row">

        <div class="col-md-4 mt-5">
            <!-- Primera columna -->

            <div class="mb-3">
                <label for="txtId" class="form-label">ID</label>
                <asp:TextBox ID="txtId" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator Display="Dynamic" ID="validaVacio" runat="server" ErrorMessage="*Ingrese el nombre del artículo." ControlToValidate="txtNombre" Style="color: red; font-size: 12px; white-space: nowrap;"></asp:RequiredFieldValidator>

            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
        </div>

        <div class="col-md-4 mt-md-5 mt-3">

            <!-- Segunda columna -->
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" />
            </div>

            <div>
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server" />
                <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" ControlToValidate="txtPrecio" ValidationExpression="^\d+([\.,]\d{1,2})?$" runat="server" ErrorMessage="*Ingrese sólo números." Style="color: red; font-size: 12px;"></asp:RegularExpressionValidator>

            </div>

            <asp:UpdatePanel ID="updatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-4">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox ID="txtImagenUrl" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <div class="row align-items-center">
                        <div class="col-md-12 text-center">
                            <asp:Image ImageUrl="https://seetruetechnology.com/wp-content/uploads/2022/02/BG-7.jpg"
                                ID="imgArticulo" Width="50%" runat="server" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <!-- Cierre de la segunda columna -->

    </div>
    <!-- Cierre de la fila-->

    <!-- Nueva columna para los botones -->

    <div class="row">
        <div class="col-md-4 mt-md-5 mt-5">
            <div class="mb-4">

                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-success me-2" OnClick="btnAceptar_Click" runat="server" />

                <%if (txtId.Text != "")
                    {%>
                <asp:Button Text="Eliminar" AutoPostBack="True" ID="btnEliminar" OnClick="btnEliminar_Click" OnClientClick="scrollToBottom()" CssClass="btn btn-warning me-2" runat="server" />

                <%}%>

                <a href="ListaArticulos.aspx">Cancelar</a>

            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div class="mb-4"></div>
                    <% if (ConfirmaEliminacion)
                        { %>

                    <div class="row-cols-8 m-md-8 d-flex align-items-center mb-5">

                        <asp:CheckBox CssClass="m-1" runat="server" ID="chkConfirmarEliminacion" />
                        <label style="white-space: nowrap;" for="chkConfirmarEliminacion">Confirmar Eliminación</label>
                        <asp:Button Text="Eliminar" ID="btnConfirmarEliminacion" OnClick="btnConfirmarEliminacion_Click" CssClass="btn btn-danger ms-3" runat="server" />

                    </div>
                    <% } %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <script type="text/javascript">
        function ejecutarEliminar() {
            
            __doPostBack('<%= btnEliminar.UniqueID %>');

            scrollToBottom();

        }

        function scrollToBottom() {
            document.documentElement.scrollTop = document.body.scrollHeight;
        }
    </script>


</asp:Content>
