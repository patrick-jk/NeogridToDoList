<%@ Page Title="Neogrid Task List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <link href="Default.css" rel="stylesheet" />
    <div class="jumbotron container text-center">
        <h2>To Do List</h2>
        <asp:Button ID="btnCreateTask" runat="server" Text="Criar Tarefa" OnClick="BtnGoToCreateTask_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
