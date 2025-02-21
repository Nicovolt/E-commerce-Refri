<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Precentacion.aspx.cs" Inherits="Ecommerce_refri.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
main {
    text-align: center;
}

/* Estilo del texto de presentación */
.texto-presentacion {
    max-width: 800px; /* Limita el ancho para mejor lectura */
    margin: 0 auto; /* Centra horizontalmente */
    text-align: center; /* Justifica el texto */
}

/* Tarjetas */
.card {
    background: white;
    padding: 15px;
    margin: 10px auto;
    border-radius: 8px;
    box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
    font-weight: bold;
    color: #333;
    max-width: 400px;
}

    </style>



  <main class="container">
        <h1>Quienes Somos</h1>
        <div class="texto-presentacion">
            <p>
                Somos una empresa familiar con más de 30 años en el rubro de la refrigeración comercial.
                Al ser fabricantes, nos permite poder realizar trabajos a medida para satisfacer mejor 
                las necesidades de nuestros clientes y enviarlo a todo el país.
            </p>
            <p>
                Fabricamos heladeras comerciales, cámaras frigoríficas de media y baja temperatura y los 
                accesorios necesarios para garantizar un mejor almacenamiento y orden de su local.
            </p>
            <p>
                A su vez, brindamos el servicio de flete, armado y puesta en marcha por nuestros mecánicos 
                experimentados en su local por un costo adicional.
            </p>
            <p>
                Nuestro objetivo es poder tener la mejor relación con el cliente a la hora de prestar nuestros servicios.
                Para eso contamos con asesoramiento gratuito y servicio post-venta para aclarar cualquier tipo de duda 
                que pudiera surgir.
            </p>
        </div>

        <h2>Nuestros Servicios</h2>
        <div class="card">
            <p>Asesoramiento gratuito y servicio post-venta.</p>
        </div>

        <div class="card">
            <p>Servicio de envío, armado y puesta en marcha.</p>
        </div>

        <h2>Formas de Pago</h2>
        <div class="card">
            <p>Contado en efectivo</p>
        </div>

        <div class="card">
            <p>Depósito y/o transferencia bancaria</p>
        </div>
    </main>

</asp:Content>
