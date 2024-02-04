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
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["ListaArticulos"] != null && Session["IdsFavoritos"] != null)
            {
                List<Articulo> listaArticulos = Session["ListaArticulos"] as List<Articulo>;
                List<int> IdsFavoritos = (List<int>)(Session["IdsFavoritos"]);

                List<Articulo> listaFavoritos = listaArticulos.Where(articulo => IdsFavoritos.Contains(articulo.Id)).ToList();

                Repetidor.DataSource = listaFavoritos;
                Repetidor.DataBind();
            }

            if (((List<int>)Session["IdsFavoritos"]) == null || ((List<int>)Session["IdsFavoritos"]).Count < 1)
                lblFavoritos.Text = "No tienes artículos favoritos.";


        }

        protected void btnVerDetalles_Click(object sender, EventArgs e)
        {
            string valorID = ((Button)sender).CommandArgument; //Recupero el ID del artículo seleccionado.
            Response.Redirect("DetallesArticulo.aspx?id=" + valorID);

        }

        protected void btnDesmarcarFavorito_Click(object sender, EventArgs e)
        {
            Button btnDesmarcarFavorito = (Button)sender;
            int idFavorito = int.Parse((btnDesmarcarFavorito.CommandArgument));

            List<int> IdsFavoritos = (List<int>)(Session["IdsFavoritos"]);

            if (IdsFavoritos.Contains(idFavorito))
            {
                IdsFavoritos.Remove(idFavorito);
            }

            Session["IdsFavoritos"] = IdsFavoritos;

            Response.Redirect(Request.RawUrl);

        }


    }
}