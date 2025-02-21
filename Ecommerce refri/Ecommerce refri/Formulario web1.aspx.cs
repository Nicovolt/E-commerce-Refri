using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce_refri
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        public List<Articulo> listarArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarArticulos();

            }
        }

        private void CargarArticulos()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> productos = negocio.listar();
            repArticulos.DataSource = productos;
            repArticulos.DataBind();
        }

        protected void repArticulos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "idModificar")
            {
                string ArticuloID = e.CommandArgument.ToString();
                Response.Redirect($"Articulos.aspx?id={ArticuloID}");
            }
            if (e.CommandName == "idBorrar")
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                int ProductoID = int.Parse(e.CommandArgument.ToString());
                negocio.Eliminar(ProductoID);
                CargarArticulos();

            }
            if (e.CommandName == "VerDetalle")
            {
                string ProductoID = e.CommandArgument.ToString();
                Response.Redirect($"VerDetalle.aspx?id={ProductoID}");
            }
        }
    }
}