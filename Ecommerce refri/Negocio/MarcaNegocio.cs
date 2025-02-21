using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> ListarMarcas()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Marca> lista = new List<Marca>();
            datos.setearConsulta("select * from Marca");
            try
            {
                datos.ejecutarAccion();
                while (datos.Lector.Read())
                {
                    Marca Marca = new Marca();

                    Marca.id_marca = (int)datos.Lector["id_marca"];
                    Marca.nombre = (string)datos.Lector["nombre"];

                    lista.Add(Marca);

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

        public Marca BuscarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id_marca, nombre FROM Marca where id_marca = @ID");
                datos.setearParametro("@ID", id);
                datos.ejecutarLectura();

                Marca Marca = null;

                while (datos.Lector.Read())
                {
                    if (Marca == null)
                    {
                        Marca = new Marca();
                        Marca.id_marca = (int)datos.Lector["id_marca"];
                        Marca.nombre = (string)datos.Lector["nombre"];
                    }

                }


                return Marca;
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
