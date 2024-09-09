<%@ Page Title="Criar Tarefa" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CreateTask.aspx.cs" Inherits="Pages.CreateTask.CreateTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="/Scripts/CreateTask.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/Content/CreateTask.css"/>

    <h2 class="text-center">Criar Tarefa</h2>
    <div class="container text-start">
        <form id="createTaskForm" method="post">

            <div class="row">
                <asp:TextBox ID="txtTaskName" ClientIDMode="Static" placeholder="Nome da Tarefa" runat="server"></asp:TextBox>
            </div>
            <br/>
            <div class="row">
                <asp:TextBox ID="txtTaskDescription" TextMode="MultiLine" ClientIDMode="Static" placeholder="Descrição da Tarefa" runat="server"></asp:TextBox>
            </div>
            <br/>
            <div class="row">
                <asp:DropDownList ID="selectTaskPriority" ClientIDMode="Static" runat="server">
                    <asp:ListItem Selected="True" Disabled="disabled" Value="null">Selecione a Prioridade</asp:ListItem>
                    <asp:ListItem Value="1">Baixa</asp:ListItem>
                    <asp:ListItem Value="2">Média</asp:ListItem>
                    <asp:ListItem Value="3">Alta</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="row">
                <div class="col align-items-center mt-3 text-start" id="chkIsDoneDiv">
                    <asp:CheckBox ID="chkIsDone" ClientIDMode="Static" runat="server"/>
                    <label for="chkIsDone" class="ms-3">Tarefa finalizada?</label>
                </div>
            </div>
            <br/>
            <div class="row">
                <asp:Button ID="btnCreateTask" runat="server" Text="Salvar Tarefa" OnClick="BtnCreateTask_Click" CssClass="btn btn-success btnSave"/>
                <asp:Button ID="btnDeleteTask" runat="server" Text="Deletar Tarefa" OnClick="BtnDeleteTask_Click" ClientIDMode="Static" CssClass="btn btn-danger"/>
            </div>
            <br/>

            <asp:HiddenField ID="hfOperationStatus" runat="server" Value="" ClientIDMode="Static"/>
        </form>
        <div class="modal fade text-dark" data-bs-backdrop="static" id="afterClickModal" tabindex="-1" aria-labelledby="afterClickModal" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Criar Tarefa</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <p>
                            <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" id="btnOkModal" class="btn btn-primary" data-bs-dismiss="modal" onclick="goToDefault();">OK</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>