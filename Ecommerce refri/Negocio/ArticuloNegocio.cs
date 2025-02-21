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
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("SELECT id_articulo, nombre, precio,descripcion, stock, id_marca, id_categoria FROM Articulo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.IdArticulo = (int)datos.Lector["id_articulo"];
                    aux.Nombre = (string)datos.Lector["nombre"];
                    aux.precio = (decimal)datos.Lector["precio"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];
                    aux.Stock = (int)datos.Lector["stock"];
                    aux.IDmarca = datos.Lector["id_marca"] != DBNull.Value ? (int)datos.Lector["id_marca"] : 0;
                    aux.IDcategoria = datos.Lector["id_categoria"] != DBNull.Value ? (int)datos.Lector["id_categoria"] : 0;

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

        public Articulo buscarPorID(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id_articulo, nombre, descripcion, precio, id_marca, id_categoria,stock FROM Articulo where id_articulo = @ID");
                datos.setearParametro("@ID", Id);
                datos.ejecutarLectura();

                Articulo Articulo = null;

                while (datos.Lector.Read())
                {
                    if (Articulo == null)
                    {
                        Articulo = new Articulo();
                        Articulo.IdArticulo = (int)datos.Lector["id_articulo"];
                        Articulo.Nombre = (string)datos.Lector["nombre"];
                        Articulo.Descripcion = (string)datos.Lector["descripcion"];
                        Articulo.IDcategoria = (int)datos.Lector["id_categoria"];
                        Articulo.IDmarca = (int)datos.Lector["id_marca"];
                        Articulo.precio = (decimal)datos.Lector["precio"];
                        Articulo.Stock = (int)datos.Lector["stock"];


                    }

                }

                return Articulo;
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

        public void Eliminar(int aux)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("delete Articulo where id_articulo = @id");
            datos.setearParametro("@id", aux);
            datos.ejecutarLectura();
            datos.cerrarConexion();
        }
        public void Agregar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("insert into Articulo(nombre,descripcion,precio,id_categoria,id_marca,stock) values(@nombre,@descip,@precio,@idCat,@idMarc,@stock);");
                datos.setearParametro("@nombre", art.Nombre);
                datos.setearParametro("@descip", art.Descripcion);
                datos.setearParametro("@precio", art.precio);
                datos.setearParametro("@idCat", art.IDcategoria);
                datos.setearParametro("@idMarc", art.IDmarca);
                datos.setearParametro("@stock", art.Stock);

                datos.ejecutarLectura();

            }
            catch (Exception ex)
            {

                throw new Exception("Error al agregar el producto: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Articulo set nombre =@nom, descripcion =@des ,precio =@precio ,id_categoria =@idcat ,id_marca =@idmarc ,stock = @stock where id_articulo = @id ");
                datos.setearParametro("@nom", art.Nombre);
                datos.setearParametro("@des", art.Descripcion);
                datos.setearParametro("@precio", art.precio);
                datos.setearParametro("@idcat", art.IDcategoria);
                datos.setearParametro("@idmarc", art.IDmarca);
                datos.setearParametro("@stock", art.Stock);
                datos.setearParametro("@id", art.IdArticulo);

                datos.ejecutarLectura();

            }
            catch (Exception ex)
            {

                throw new Exception("Error al modificar el producto: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
