using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar(string Id = "")
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();

            try
            {

                if (Id == "")
                {
                    datos.setearConsulta("Select A.Id, Codigo, Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, M.Descripcion as Marca, C.Descripcion as Categoria, ImagenUrl, Precio FROM ARTICULOS A JOIN CATEGORIAS C ON A.IdCategoria = C.Id JOIN MARCAS M ON A.IdMarca = M.Id");

                }
                else
                {
                    datos.setearConsulta("Select A.Id, Codigo, Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, M.Descripcion as Marca, C.Descripcion as Categoria, ImagenUrl, Precio FROM ARTICULOS A JOIN CATEGORIAS C ON A.IdCategoria = C.Id JOIN MARCAS M ON A.IdMarca = M.Id And A.Id = " + Id);

                }

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    aux.Precio = Math.Round((decimal)datos.Lector["Precio"], 2);

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];



                    lista.Add(aux);

                }
                return lista;

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

        public List<Articulo> listarArticulo()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, M.Descripcion as Marca, C.Descripcion as Categoria, ImagenUrl, Precio FROM ARTICULOS A JOIN CATEGORIAS C ON A.IdCategoria = C.Id JOIN MARCAS M ON A.IdMarca = M.Id";
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    }

                    aux.Precio = Math.Round((decimal)datos.Lector["Precio"], 2);

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];


                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string palabraClave)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, M.Descripcion as Marca, C.Descripcion as Categoria, ImagenUrl, Precio FROM ARTICULOS A JOIN CATEGORIAS C ON A.IdCategoria = C.Id JOIN MARCAS M ON A.IdMarca = M.Id And ";

                switch (campo)
                {
                    case "Código":

                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Codigo like '" + palabraClave + "%'";
                                break;

                            case "Termina con":
                                consulta += "A.Codigo like '%" + palabraClave + "'";
                                break;

                            case "Contiene":
                                consulta += "A.Codigo like '%" + palabraClave + "%'";
                                break;
                        }
                        break;

                    case "Nombre":

                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Nombre like '" + palabraClave + "%'";
                                break;

                            case "Termina con":
                                consulta += "A.Nombre like '%" + palabraClave + "'";
                                break;

                            case "Contiene":
                                consulta += "A.Nombre like '%" + palabraClave + "%'";
                                break;
                        }
                        break;

                    case "Descripción":

                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Descripcion like '" + palabraClave + "%'";
                                break;

                            case "Termina con":
                                consulta += "A.Descripcion like '%" + palabraClave + "'";
                                break;

                            case "Contiene":
                                consulta += "A.Descripcion like '%" + palabraClave + "%'";
                                break;
                        }
                        break;

                    case "Marca":

                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "M.Descripcion like '" + palabraClave + "%'";
                                break;

                            case "Termina con":
                                consulta += "M.Descripcion like '%" + palabraClave + "'";
                                break;

                            case "Contiene":
                                consulta += "M.Descripcion like '%" + palabraClave + "%'";
                                break;
                        }
                        break;

                    case "Categoría":

                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "C.Descripcion like '" + palabraClave + "%'";
                                break;

                            case "Termina con":
                                consulta += "C.Descripcion like '%" + palabraClave + "'";
                                break;

                            case "Contiene":
                                consulta += "C.Descripcion like '%" + palabraClave + "%'";
                                break;
                        }
                        break;

                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    aux.Precio = Math.Round((decimal)datos.Lector["Precio"], 2);

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];


                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregarArticulo(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@ImagenUrl", nuevo.UrlImagen);
                datos.setearParametro("@Precio", nuevo.Precio);

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

        public void modificarArticulo(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idmarca, IdCategoria = @idcategoria, ImagenUrl = @imagenurl, Precio = @precio Where Id = @id");
                datos.setearParametro("@codigo", modificar.Codigo);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@descripcion", modificar.Descripcion);
                datos.setearParametro("@idmarca", modificar.Marca.Id);
                datos.setearParametro("@idcategoria", modificar.Categoria.Id);
                datos.setearParametro("@imagenurl", modificar.UrlImagen);
                datos.setearParametro("@precio", modificar.Precio);
                datos.setearParametro("@id", modificar.Id);

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

        public void eliminarArticulo(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            datos.setearConsulta("Delete From ARTICULOS Where Id= @id");
            datos.setearParametro("id", Id);

            datos.ejecutarAccion();

        }

        public List<Articulo> listarFavoritos(string Id)
        {

            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();

            try
            {
                datos.setearConsulta("Select A.Id, Codigo, Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, M.Descripcion as Marca, C.Descripcion as Categoria, ImagenUrl, Precio FROM ARTICULOS A JOIN CATEGORIAS C ON A.IdCategoria = C.Id JOIN MARCAS M ON A.IdMarca = M.Id And A.Id = " + Id);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    aux.Precio = Math.Round((decimal)datos.Lector["Precio"], 2);

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    lista.Add(aux);

                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;

            }




        }













    }



}
