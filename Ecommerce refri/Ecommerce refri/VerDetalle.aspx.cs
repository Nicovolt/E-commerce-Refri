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
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        private int ObtenerElIdDelArticuloDesdeLaURL()
        {
            int idArticulo = -1;
            if (Request.QueryString["id"] != null)
            {
                if (int.TryParse(Request.QueryString["id"], out idArticulo))
                {
                }
            }
            return idArticulo;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ObtenerElIdDelArticuloDesdeLaURL() != -1)
            {

                if (!IsPostBack)
                {
                    actualizarVisualizacionBotones();
                    string articuloID = Request.QueryString["id"];
                    if (!string.IsNullOrEmpty(articuloID))
                    {
                        CargarDetalleArticulo(articuloID);
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }


        private void CargarDetalleArticulo(string articuloID)
        {
            Marca marca = new Marca();
            Categoria categoria = new Categoria();
            ArticuloNegocio ArticuloNegocio = new ArticuloNegocio();
            Articulo Articulo = ArticuloNegocio.buscarPorID(int.Parse(articuloID));
            lblNombreArticulo.Text = Articulo.Nombre;
            lblDescripcionArticulo.Text = Articulo.Descripcion;
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            categoria = categoriaNegocio.BuscarPorId(Articulo.IDcategoria);
            lblCategoriaArticulo.Text = categoria.nombre.ToString();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            marca = marcaNegocio.BuscarPorId(Articulo.IDmarca);
            lblMarcaArticulo.Text = marca.nombre.ToString();
            lblPrecioArticulo.Text = Articulo.precio.ToString();


        }

        protected void actualizarVisualizacionBotones()
        {
            bool mostrarBotones = false;

            if (Session["usuario"] != null)
            {
                dynamic usuario = Session["usuario"];
                mostrarBotones = usuario.EsAdmin;
            }

            btnBorrar.Visible = mostrarBotones;
            btnModificar.Visible = mostrarBotones;
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            if (Session["CarritoCompras"] == null)
            {
                Session["CarritoCompras"] = new List<Articulo>();
            }

            int id = 0;
            int.TryParse(Request.QueryString["id"], out id);

            ArticuloNegocio ArticuloNegocio = new ArticuloNegocio();

            Articulo Articulo = ArticuloNegocio.buscarPorID(id);
            Articulo.Cantidad = 1;

            if (Articulo != null)
            {
                List<Articulo> carrito = Session["CarritoCompras"] as List<Articulo>;

                Articulo productoExistente = carrito.FirstOrDefault(p => p.IdArticulo == id);

                if (productoExistente != null)
                {
                    productoExistente.Cantidad++;
                }
                else
                {
                    Articulo.Cantidad = 1;
                    carrito.Add(Articulo);
                }

                Session["CarritoCompras"] = carrito;

                List<Articulo> carritoActual = (List<Articulo>)Session["CarritoCompras"];
                int cantArticulos = carritoActual.Count;

                SiteMaster masterPage = (SiteMaster)this.Master;
                masterPage.ActualizarContadorCarrito(cantArticulos);



                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Producto agregado al carrito exitosamente!');", true);
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio artNeg = new ArticuloNegocio();
            int idProducto;
            int.TryParse(Request.QueryString["id"], out idProducto);
            artNeg.Eliminar(idProducto);
            Response.Redirect("VistaArticulos.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int idProducto;
            int.TryParse(Request.QueryString["id"], out idProducto);
            Response.Redirect($"Articulos.aspx?id={idProducto}");
        }   
    }
}