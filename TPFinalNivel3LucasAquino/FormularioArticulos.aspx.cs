using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPFinal_3_ConComentarios
{
    public partial class FormularioArticulos : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            txtId.Enabled = false;

            ConfirmaEliminacion = false;

            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio negocio = new MarcaNegocio();
                    CategoriaNegocio catNegocio = new CategoriaNegocio();

                    List<Marca> lista = negocio.listar();
                    List<Categoria> listaCategoria = catNegocio.listar();

                    ddlMarca.DataSource = lista;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = listaCategoria;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                }

                if (Request.QueryString["id"] != null && !IsPostBack)
                {
                    string id = Request.QueryString["id"].ToString();

                    ArticuloNegocio negocio = new ArticuloNegocio();

                    List<Articulo> lista = negocio.listar(Request.QueryString["id"].ToString());

                    Articulo seleccionado = lista[0];

                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;

                    txtImagenUrl.Text = seleccionado.UrlImagen;
                    txtPrecio.Text = seleccionado.Precio.ToString();


                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                    txtImagenUrl_TextChanged(sender, e);

                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);

            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.UrlImagen = txtImagenUrl.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);


                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificarArticulo(nuevo);
                }
                else
                {
                    negocio.agregarArticulo(nuevo);

                }

                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;


        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminarArticulo(int.Parse(txtId.Text));

                    Response.Redirect("listaArticulos.aspx", false);

                }


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;

            string script = "<script type='text/javascript'>scrollToBottom();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "ScrollToBottom", script);


        }


    }
}