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
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";

            if (Page is Default || Page is Error || Page is DetallesArticulo)
            {
                if (Seguridad.sesionActiva(Session["UsuarioActivo"]))
                {
                    Usuario user = (Usuario)Session["UsuarioActivo"];
                    lblUser.Text = user.Email;

                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        imgAvatar.ImageUrl = "~/ImagenPerfil/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();

                }

            }

            if (!(Page is Default || Page is Login || Page is Registro || Page is Error || Page is DetallesArticulo))
            {
                if (!Seguridad.sesionActiva(Session["UsuarioActivo"]))
                    Response.Redirect("Login.aspx", false);

                else
                {
                    Usuario user = (Usuario)Session["UsuarioActivo"];
                    lblUser.Text = user.Email;

                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        imgAvatar.ImageUrl = "~/ImagenPerfil/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                }
            }

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("Login.aspx");

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Default Default = Page as Default;

            Repeater RepetidorDefault = Default.ObtenerRepeater();

            if (RepetidorDefault != null)
            {
                List<Articulo> lista = (List<Articulo>)Session["ListaArticulos"];
                List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToLower().Contains(txtBuscar.Text));

                RepetidorDefault.DataSource = listaFiltrada;
                RepetidorDefault.DataBind();

            }

            Default.actualizarIconoFavoritos();

        }
    }
}