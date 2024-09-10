<%@ page title="Criar Tarefa" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Pages.CreateTask.CreateTask, App_Web_swmxy3hy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <script src="/Scripts/CreateTask.js" type="text/javascript"></script>
    <link rel="stylesheet" href="/Content/CreateTask.css" type="text/css"/>

    <script type="text/javascript">
        var btnCreateTaskClientID = '<%= btnCreateTask.ClientID %>';
        var txtTaskTitleClientID = '<%= txtTaskTitle.ClientID %>';
        var txtTaskDescriptionClientID = '<%= txtTaskDescription.ClientID %>';
        var selectTaskPriorityClientID = '<%= selectTaskPriority.ClientID %>';
        var hfValidationPassedClientID = '<%= hfValidationPassed.ClientID %>';
    </script>

    <h2 class="text-center">Criar Tarefa</h2>
    <div class="container text-start">
        <form id="createTaskForm" name="createTaskForm" method="post">

            <div class="row">
                <asp:TextBox ID="txtTaskTitle" name="txtTaskTitle" ClientIDMode="Static" placeholder="Nome da Tarefa" runat="server"></asp:TextBox>
                <h5 id="validateTitle" class="validation-label" style="display: none;">Insira um título válido!</h5>
            </div>
            <br/>
            <div class="row">
                <asp:TextBox ID="txtTaskDescription" TextMode="MultiLine" ClientIDMode="Static" placeholder="Descrição da Tarefa" runat="server"></asp:TextBox>
                <h5 id="validateDescription" class="validation-label" style="display: none;">Insira uma descrição válida!</h5>
            </div>
            <br/>
            <div class="row">
                <asp:DropDownList ID="selectTaskPriority" ClientIDMode="Static" runat="server">
                    <asp:ListItem Selected="True" Disabled="disabled" Value="null">Selecione a Prioridade</asp:ListItem>
                    <asp:ListItem Value="1">Baixa</asp:ListItem>
                    <asp:ListItem Value="2">Média</asp:ListItem>
                    <asp:ListItem Value="3">Alta</asp:ListItem>
                </asp:DropDownList>
                <h5 id="validateSelect" class="validation-label" style="display: none;">Escolha uma prioridade válida!</h5>
            </div>
            <div class="row">
                <div class="col align-items-center mt-3 text-start" id="chkIsDoneDiv" style="display: none;">
                    <asp:CheckBox ID="chkIsDone" ClientIDMode="Static" runat="server"/>
                    <label for="chkIsDone" class="ms-3">Tarefa finalizada?</label>
                </div>
            </div>
            <br/>
            <div class="row">
                <asp:Button ID="btnCreateTask" runat="server" Text="Salvar Tarefa" OnClick="BtnCreateTask_Click" ClientIDMode="Static" CssClass="btn btn-success btnSave"/>
                <asp:Button ID="btnDeleteTask" runat="server" Text="Deletar Tarefa" OnClick="BtnDeleteTask_Click" ClientIDMode="Static" CssClass="btn btn-danger" style="display: none;"/>
            </div>
            <br/>

            <asp:HiddenField ID="hfOperationStatus" runat="server" Value="" ClientIDMode="Static"/>
            <asp:HiddenField ID="hfValidationPassed" runat="server" Value="false" ClientIDMode="Static"/>
        </form>
        <div class="modal fade text-dark" data-bs-backdrop="static" id="afterClickModal" tabindex="-1" aria-labelledby="afterClickModal" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text="Criar Tarefa"></asp:Label></h5>
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