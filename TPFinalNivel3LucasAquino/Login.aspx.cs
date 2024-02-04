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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Page.Validate();
                if (!Page.IsValid)
                return;

            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                usuario.Email = txtCorreo.Text;
                usuario.Pass = txtPass.Text;

                if (negocio.Login(usuario)) 
                {
                    Session.Add("UsuarioActivo", usuario); 

                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    lblError.Text = "*Usuario o contraseña incorrectos..";


                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());

                Response.Redirect("Error.aspx", false);
            }

        }
    }
}