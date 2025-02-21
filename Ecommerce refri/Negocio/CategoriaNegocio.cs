using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> ListarCategorias()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Categoria> lista = new List<Categoria>();
            datos.setearConsulta("select * from Categoria");
            try
            {
                datos.ejecutarAccion();
                while (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();

                    categoria.id_categoria = (int)datos.Lector["id_categoria"];
                    categoria.nombre = (string)datos.Lector["nombre"];

                    lista.Add(categoria);

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public Categoria BuscarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id_categoria, nombre FROM Categoria where id_categoria = @ID");
                datos.setearParametro("@ID", id);
                datos.ejecutarLectura();

                Categoria categoria = null;

                while (datos.Lector.Read())
                {
                    if (categoria == null)
                    {
                        categoria = new Categoria();
                        categoria.id_categoria = (int)datos.Lector["id_categoria"];
                        categoria.nombre = (string)datos.Lector["nombre"];
                    }

                }


                return categoria;
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
