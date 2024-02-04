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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptarRegistro_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();

                usuario.Email = txtCorreo.Text;
                usuario.Pass = txtPass.Text;

                usuario.Id = UsuarioNegocio.insertarNuevo(usuario);

                Session.Add("UsuarioActivo", usuario);

                Response.Redirect("Default.aspx", false);


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");

            }

        }
    }
}