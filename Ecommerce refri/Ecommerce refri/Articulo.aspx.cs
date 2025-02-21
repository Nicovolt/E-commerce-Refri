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
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CargarCombos();
                int idProducto = ObtenerIdProducto();

                if (idProducto != -1)
                {
                    CargarProducto(idProducto);
                    ltlTitulo.Text = "Modificar Producto";
                    btnGuardar.Text = "Actualizar";
                }
                else
                {
                    ltlTitulo.Text = "Nuevo Producto";
                    btnGuardar.Text = "Agregar";
                }
            }
        }

        private void CargarProducto(int idProducto)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Articulo producto = negocio.buscarPorID(idProducto);

                if (producto != null)
                {
                    txtNombre.Text = producto.Nombre;
                    txtDescripcion.Text = producto.Descripcion;
                    ddlCategoria.SelectedValue = producto.IDcategoria.ToString();
                    ddlMarca.SelectedValue = producto.IDmarca.ToString();
                    txtPrecio.Text = producto.precio.ToString();
                    txtStock.Text = producto.Stock.ToString();


                }
            }
            catch (Exception ex)
            {

            }
        }

        private int ObtenerIdProducto()
        {
            if (Request.QueryString["id"] != null)
            {
                return int.TryParse(Request.QueryString["id"], out int id) ? id : -1;
            }
            return -1;
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo art = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                art.Nombre = txtNombre.Text;
                art.Descripcion = txtDescripcion.Text;
                art.precio = decimal.Parse(txtPrecio.Text);
                art.IDcategoria = int.Parse(ddlCategoria.SelectedValue);
                art.IDmarca = int.Parse(ddlMarca.SelectedValue);
                art.Stock = int.Parse(txtStock.Text);

                int idProducto = ObtenerIdProducto();
                if (idProducto != -1) // Si hay un ID, significa que estamos editando
                {
                    art.IdArticulo = idProducto; // Aseguramos que mantenga el ID
                    negocio.Modificar(art);
                    MostrarExito("Producto actualizado exitosamente");
                    Response.Redirect("VistaArticulos.aspx");

                }
                else // Si no hay un ID, entonces estamos creando un nuevo producto
                {
                    negocio.Agregar(art);
                    MostrarExito("Producto agregado exitosamente");
                    Response.Redirect("VistaArticulos.aspx");
                }



            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CargarCombos()
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ddlCategoria.DataSource = categoriaNegocio.ListarCategorias();
            ddlCategoria.DataTextField = "nombre";
            ddlCategoria.DataValueField = "id_categoria";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("Seleccione una categoria", ""));

            MarcaNegocio MarcaNegocio = new MarcaNegocio();
            ddlMarca.DataSource = MarcaNegocio.ListarMarcas();
            ddlMarca.DataTextField = "nombre";
            ddlMarca.DataValueField = "id_marca";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Seleccione una marca", ""));
        }

        private void MostrarExito(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "success",
               $"Swal.fire({{" +
               $"  icon: 'success'," +
               $"  title: '¡Éxito!'," +
               $"  text: '{mensaje}'," +
               $"  confirmButtonColor: '#3085d6'" +
               $"}}).then((result) => {{" +
               $"  if (result.isConfirmed) {{" +
               $"    window.location = 'Default.aspx';" +
               $"  }}" +
               $"}});", true);
        }
    }
}