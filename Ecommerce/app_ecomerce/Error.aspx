<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="app_ecomerce.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div>
            <h1 class="text-center">Hubo un problema</h1>
        </div>

        <div class="alert alert-danger" role="alert">
            <asp:Label Text="text" ID="lblError" runat="server" />
        </div>
    </div>
</asp:Content>
