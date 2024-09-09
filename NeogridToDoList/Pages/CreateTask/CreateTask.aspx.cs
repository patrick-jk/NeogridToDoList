using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using Domain;
using Microsoft.Ajax.Utilities;
using Repository;

namespace Pages.CreateTask
{
    public partial class CreateTask : Page
    {
        protected void BtnCreateTask_Click(object sender, EventArgs e)
        {
            if (hfValidationPassed.Value == "false") return;

            try
            {
                using (var db = new TaskDbContext())
                {
                    var taskId = Request.QueryString["taskId"] != null ? int.Parse(Request.QueryString["taskId"]) : (int?)null;
                    var taskTitle = txtTaskTitle.Text.Trim();
                    var taskDescription = txtTaskDescription.Text.Trim();
                    var priority = int.Parse(selectTaskPriority.SelectedValue);
                    var existsDuplicate = db.Tasks.FirstOrDefault(t => t.Title == taskTitle && t.Id != taskId);

                    if (existsDuplicate != null)
                    {
                        lblModalBody.Text = $"A tarefa com nome {taskTitle} já existe! Por favor, insira outro nome.";
                        hfOperationStatus.Value = "error";
                        throw new DuplicateNameException();
                    }

                    var task = taskId.HasValue ? db.Tasks.FirstOrDefault(t => t.Id == taskId) : new Task { CreatedAt = DateTime.Now };

                    if (task != null)
                    {
                        task.Title = taskTitle;
                        task.Description = taskDescription;
                        task.Priority = priority;
                        task.IsDone = chkIsDone.Checked;

                        if (!taskId.HasValue) db.Tasks.Add(task);

                        db.SaveChanges();

                        if (taskId.HasValue) lblModalTitle.Text = "Atualizar Tarefa";
                        lblModalBody.Text = taskId.HasValue ? "Tarefa atualizada com sucesso!" : "Tarefa salva com sucesso.";
                        hfOperationStatus.Value = "success";

                        if (!taskId.HasValue)
                        {
                            txtTaskTitle.Text = "";
                            txtTaskDescription.Text = "";
                            selectTaskPriority.SelectedValue = "null";
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                Debug.WriteLine("Error while saving task: ", ex);
                lblModalBody.Text = "Erro ao salvar tarefa. Por favor, tente novamente mais tarde!";
                hfOperationStatus.Value = "error";
            }
            catch (DuplicateNameException)
            {
                Debug.WriteLine($"The record '{txtTaskTitle.Text}' already exists.");
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "afterClickModal", "showModal();", true);
        }

        protected void BtnDeleteTask_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "Deletar Tarefa";

            try
            {
                var taskId = int.Parse(Request.QueryString["taskId"]);
                using (var db = new TaskDbContext())
                {
                    var task = db.Tasks.FirstOrDefault(t => t.Id == taskId);
                    if (task != null)
                    {
                        db.Tasks.Remove(task);
                        db.SaveChanges();
                    }
                }

                lblModalBody.Text = "Tarefa excluída com sucesso.";
                hfOperationStatus.Value = "success";
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error while saving task: ", ex);
                lblModalBody.Text = "Erro ao deletar tarefa. Por favor, tente novamente mais tarde!";
                hfOperationStatus.Value = "error";
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "afterClickModal", "showModal();", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (Request.QueryString["taskId"] == null) return;

            btnCreateTask.Text = "Editar Tarefa";
            var taskId = int.Parse(Request.QueryString["taskId"]);
            LoadTaskData(taskId);
        }

        private void LoadTaskData(int taskId)
        {
            using (var db = new TaskDbContext())
            {
                var task = db.Tasks.FirstOrDefault(t => t.Id == taskId);
                if (task == null) return;
                txtTaskTitle.Text = task.Title;
                txtTaskDescription.Text = task.Description;
                selectTaskPriority.SelectedValue = task.Priority.ToString();
                chkIsDone.Checked = task.IsDone;
            }
        }
    }
}