using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TPFinal_3_ConComentarios
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;

            if (!Seguridad.esAdmin(Session["UsuarioActivo"]))
            {
                Session.Add("error", "Sólo los administradores pueden ver esta página.");
                Response.Redirect("Error.aspx");
            }

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                List<Articulo> listaArticulos = negocio.listarArticulo();
                Session["ListaArticulos"] = listaArticulos;

                dgvArticulos.DataSource = negocio.listarArticulo();
                dgvArticulos.DataBind();

            }

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulos.aspx?id=" + id);

        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();

        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulos"];

            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToLower().Contains(txtFiltroRapido.Text));

            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();

        }


        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();

            ddlCriterio.Items.Add("Comienza con");
            ddlCriterio.Items.Add("Termina con");
            ddlCriterio.Items.Add("Contiene");

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                string campoSeleccionado;
                string criterioSeleccionado;

                if (string.IsNullOrEmpty(ddlCampo.SelectedValue))
                {
                    campoSeleccionado = ddlCampo.Items[0].ToString();
                }
                else
                {
                    campoSeleccionado = ddlCampo.SelectedItem.ToString();
                }

                if (string.IsNullOrEmpty(ddlCriterio.SelectedValue))
                {
                    criterioSeleccionado = ddlCriterio.Items[0].ToString();
                }
                else
                {
                    criterioSeleccionado = ddlCriterio.SelectedItem.ToString();
                }

                string palabraClave = txtFiltroAvanzado.Text;

                dgvArticulos.DataSource = negocio.filtrar(campoSeleccionado, criterioSeleccionado, palabraClave);
                dgvArticulos.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);

            }


        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltroRapido.Enabled = !FiltroAvanzado;
        }

        protected void btnBorrarFiltro_Click(object sender, EventArgs e)
        {
            txtFiltroAvanzado.Text = "";
            ddlCampo.ClearSelection();
            ddlCriterio.ClearSelection();

            dgvArticulos.DataSource = Session["ListaArticulos"];
            dgvArticulos.DataBind();

        }

        protected void btnBorrarFiltroRapido_Click(object sender, EventArgs e)
        {
            txtFiltroRapido.Text = "";

            dgvArticulos.DataSource = Session["ListaArticulos"];
            dgvArticulos.DataBind();


        }
    }
}