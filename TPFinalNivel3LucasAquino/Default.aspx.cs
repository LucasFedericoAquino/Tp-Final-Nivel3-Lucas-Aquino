using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using Dominio;
using Negocio;

namespace TPFinal_3_ConComentarios
{
    public partial class Default : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();

                List<Articulo> listaArticulos = negocio.listarArticulo();
                Session["ListaArticulos"] = listaArticulos;

                Repetidor.DataSource = listaArticulos;
                Repetidor.DataBind();

                actualizarIconoFavoritos();
              
            }

        }
        public Repeater ObtenerRepeater()
        {
            return Repetidor;
        }


        protected void btnVerDetalles_Click(object sender, EventArgs e)
        {
            string valorID = ((Button)sender).CommandArgument; //Recupero el ID del artículo seleccionado.

            Response.Redirect("DetallesArticulo.aspx?id=" + valorID);

        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            Button btnFavorito = (Button)sender;
            int idFavorito = int.Parse(btnFavorito.CommandArgument);

            List<int> IdsFavoritos = Session["IdsFavoritos"] as List<int> ?? new List<int>();

            if (IdsFavoritos.Contains(idFavorito))
            {
                IdsFavoritos.Remove(idFavorito);
            }
            else
            {
                IdsFavoritos.Add(idFavorito);
            }

            Session["IdsFavoritos"] = IdsFavoritos;

            actualizarIconoFavoritos();

        }

        public void actualizarIconoFavoritos()
        {
            List<int> IdsFavoritos = Session["IdsFavoritos"] as List<int> ?? new List<int>();

            foreach (RepeaterItem ControlesDelRepeater in Repetidor.Items)
            {
                Button btnFavorito = (Button)ControlesDelRepeater.FindControl("btnFavorito");

                int idArticulo = int.Parse(btnFavorito.CommandArgument);

                if (IdsFavoritos.Contains(idArticulo))
                {
                    btnFavorito.Text = "🧡";

                }
                else
                {
                    btnFavorito.Text = "🤍";

                }

            }
        }

        protected void btnBorrarFiltro_Click(object sender, EventArgs e)
        {
            TextBox txtBuscarHome = (TextBox)Master.FindControl("txtBuscar");
            txtBuscarHome.Text = "";

            Repetidor.DataSource = Session["ListaArticulos"];
            Repetidor.DataBind();

            actualizarIconoFavoritos();

        }
    }
}