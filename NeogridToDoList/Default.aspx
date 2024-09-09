<%@ Page Title="Neogrid To Do List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="/Content/Default.css"/>
    <script type="text/javascript" src="/Scripts/Default.js"></script>

    <div class="jumbotron container-fluid text-center">
        <h2>To Do List</h2>
        <asp:Button runat="server" Text="Criar Tarefa" OnClick="BtnGoToCreateTask_Click" CssClass="btn btn-primary btnCreateTask"/>

        <div class="row justify-content-center text-center">
            <div>
                <asp:TextBox runat="server" CssClass="searchTasks" placeholder="Buscar Tarefa por Título" AutoPostBack="True" OnTextChanged="searchTasks_OnTextChanged"></asp:TextBox>
            </div>
        </div>
        <br/>

        <asp:Repeater ID="rptTasks" runat="server" ClientIDMode="Static">
            <ItemTemplate>
                <div class="row text-dark text-start">
                    <div class="card mb-3 d-flex mx-auto">
                        <div class="card-body d-flex flex-column">
                            <!-- Upper Section: Title and Description (Left), CreatedAt (Right) -->
                            <div class="d-flex justify-content-between">
                                <!-- Title and Description -->
                                <div>
                                    <h5 class="card-title"><%# Eval("Title") %></h5>
                                    <p class="card-subtitle"><%# Eval("Description") %></p>
                                </div>

                                <!-- CreatedAt (Upper Right) -->
                                <div>
                                    <p class="card-text text-end">
                                        <%# Eval("CreatedAt", "{0:dd/MM - HH:mm}") %>
                                    </p>
                                </div>
                            </div>

                            <!-- Lower Section: Priority and Checkbox (Left), Button (Right) -->
                            <div class="d-flex justify-content-between align-items-end mt-auto">
                                <!-- Priority and Checkbox (Lower Left) -->
                                <div>
                                    <p class="card-text">Prioridade: <%# GetPriorityLabel(Convert.ToInt32(Eval("Priority"))) %></p>

                                    <div class="text-bottom d-flex align-items-center">
                                        <asp:CheckBox ID="chkIsDone" runat="server" AutoPostBack="true" OnCheckedChanged="chkIsDone_CheckedChanged" Checked='<%# Eval("IsDone") %>'/>
                                        <asp:HiddenField ID="hfTaskId" runat="server" Value='<%# Eval("Id") %>'/>
                                        <label class="form-check-label ms-2" for="chkIsDone">Feito</label>
                                    </div>
                                </div>

                                <!-- Button (Lower Right) -->
                                <div>
                                    <asp:Button ID="BtnTaskDetails" runat="server" Text="Editar" OnClick="BtnTaskDetails_OnClick" CssClass="btn btn-task-details text-light" CommandArgument='<%# Eval("Id") %>'/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>