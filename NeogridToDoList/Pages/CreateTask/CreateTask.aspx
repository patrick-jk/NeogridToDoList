<%@ Page Title="Criar Tarefa" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CreateTask.aspx.cs" Inherits="CreateTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="CreateTask.js"></script>
    <link rel="stylesheet" href="CreateTask.css" />

    <h2 class="text-center">Criar Tarefa</h2>
    <div class="container-sm text-center">
        <div class="row">
            <asp:TextBox ID="txtTaskName" placeholder="Nome da Tarefa" runat="server"></asp:TextBox>
        </div>
        <br />
        <div class="row">
            <asp:TextBox ID="txtTaskDescription" placeholder="Descrição da Tarefa" runat="server"></asp:TextBox>
        </div>
        <br />
        <div class="row">
            <asp:DropDownList ID="selectTaskPriority" runat="server">
                <asp:ListItem Selected="True" Disabled="disabled" Value="null">Selecione a Prioridade</asp:ListItem>
                <asp:ListItem Value="1">Baixa</asp:ListItem>
                <asp:ListItem Value="2">Média</asp:ListItem>
                <asp:ListItem Value="3">Alta</asp:ListItem>
            </asp:DropDownList>
        </div>
        <br />
        <div class="row">
            <asp:Button ID="btnCreateTask" runat="server" Text="Salvar Tarefa" OnClick="BtnCreateTask_Click" CssClass="btn btn-success btnSave" />
            <asp:Button ID="btnDeleteTask" runat="server" Text="Deletar Tarefa" OnClick="BtnDeleteTask_Click" CssClass="btn btn-danger" />
        </div>
        <br />
        <asp:HiddenField ID="TaskSaved" runat="server" Value='<%= Session["TaskSaved"] != null ? Session["TaskSaved"].ToString() : "null" %>' />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

