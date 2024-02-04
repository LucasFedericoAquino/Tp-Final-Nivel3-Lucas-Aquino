using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.Drawing;


namespace TPFinal_3_ConComentarios
{
    public partial class DetallesArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtNombre.ReadOnly = true;
            ddlCategoria.Visible = false;
            txtDescripcion.ReadOnly = true;
            txtDescripcion.ReadOnly = false;
            txtPrecio.ReadOnly = true;
            txtImagenUrl.Visible = false;

            algunMetodoParaGestionarStockEnAlgunMomentoDeLaVidaJajaj();






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

                    //Precargo las cajas de texto

                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;

                    txtImagenUrl.Text = seleccionado.UrlImagen;

                    txtPrecio.Text = seleccionado.Precio.ToString("C0");

                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                    txtImagenUrl_TextChanged(sender, e);


                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }

        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        private bool algunMetodoParaGestionarStockEnAlgunMomentoDeLaVidaJajaj()
        {
            int r = 0;
            int g = 200;
            int b = 0;

            lblDisponibilidad.Text = "Disponible";
            lblDisponibilidad.ForeColor = Color.FromArgb(r, g, b);

            return true;

        }







    }
}