using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, email, pass, nombre, apellido, urlImagenPerfil, admin From USERS Where email = @email And pass = @pass");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Admin = (bool)datos.Lector["admin"];

                    if (!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["nombre"];

                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["apellido"];

                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.ImagenPerfil = (string)datos.Lector["urlImagenPerfil"];

                    return true;

                }

                return false;

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        public void actualizarDatosUsuario(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update USERS set nombre = @nombre, apellido = @apellido, urlImagenPerfil = @imagen Where Id = @id");

                datos.setearParametro("@nombre", user.Nombre);
                datos.setearParametro("@apellido", user.Apellido);
                datos.setearParametro("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : (object)DBNull.Value);
                datos.setearParametro("@id", user.Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }


        }

        public int insertarNuevo(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("insertarNuevoUsuario");

                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@pass", nuevo.Pass);


                return datos.ejecutarAccionScalar(); ;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                datos.cerrarConexion();

            }

        }

    }


}
