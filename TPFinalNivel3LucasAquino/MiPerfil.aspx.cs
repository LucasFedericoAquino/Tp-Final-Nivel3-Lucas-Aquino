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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Enabled = false;

            if (!IsPostBack)
            {

                if (Seguridad.sesionActiva(Session["UsuarioActivo"]))
                {
                    Usuario user = (Usuario)Session["UsuarioActivo"];

                    txtEmail.Text = user.Email;
                    txtNombre.Text = user.Nombre;
                    txtApellido.Text = user.Apellido;

                 if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    imagenPerfil.ImageUrl = "~/ImagenPerfil/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();

                }




            }

            

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            try
            {
                UsuarioNegocio Negocio = new UsuarioNegocio();
                Usuario user = (Usuario)Session["UsuarioActivo"];

                if (txtImagen.PostedFile.FileName != "")
                {
                    string rutaFisica = Server.MapPath("./ImagenPerfil/");

                    txtImagen.PostedFile.SaveAs(rutaFisica + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";

                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;

                Negocio.actualizarDatosUsuario(user);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/ImagenPerfil/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();

                if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    imagenPerfil.ImageUrl = "~/ImagenPerfil/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");


            }

        }
    }
    
}