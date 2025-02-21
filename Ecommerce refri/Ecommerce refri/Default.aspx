<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ecommerce_refri._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  
    <asp:Repeater ID="repArticulos" runat="server" onitemcommand="repArticulos_ItemCommand">
        <ItemTemplate>
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nombre") %> </h5>
                        <p class="card-text"><%# Eval("Descripcion") %> </p>
                        <p class="card-text"><strong>Precio: </strong>$<%# Eval("precio") %></p>
                        <div class="d-flex justify-content-between align-items-center mt-auto">
                           
                            <asp:Button ID="btnDetalle" runat="server" CommandName="VerDetalle" commandargument='<%# Eval("IdArticulo") %>' Text="Ver detalle" CssClass="btn btn-primary"/>
                            <asp:Button  runat="server"  CommandName="idModificar" CommandArgument='<%# Eval("IdArticulo")%>' Text="Editar" CssClass="btn btn-primary"/>
                            <asp:Button  runat="server" CommandName="idBorrar" CommandArgument='<%# Eval("IdArticulo") %>' Text="Borrar" CssClass="btn btn-primary"/>
                            
                            

                         </div>
                    </div>
                </div>
            </div>



        </ItemTemplate>
    </asp:Repeater>


</asp:Content>
