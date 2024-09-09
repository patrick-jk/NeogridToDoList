using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using Domain;
using log4net;
using Repository;

namespace Pages.CreateTask
{
    public partial class CreateTask : Page
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CreateTask));

        protected void BtnCreateTask_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new TaskDbContext())
                {
                    var task = new Task
                    {
                        Title = txtTaskName.Text,
                        Description = txtTaskDescription.Text,
                        Priority = int.Parse(selectTaskPriority.SelectedValue),
                        IsDone = false,
                        CreatedAt = DateTime.Now
                    };

                    if (Request.QueryString["taskId"] != null)
                    {
                        var taskId = int.Parse(Request.QueryString["taskId"]);
                        var oldTask = db.Tasks.FirstOrDefault(t => t.Id == taskId);
                        if (oldTask != null)
                        {
                            oldTask.Title = txtTaskName.Text;
                            oldTask.Description = txtTaskDescription.Text;
                            oldTask.Priority = int.Parse(selectTaskPriority.SelectedValue);
                            oldTask.IsDone = chkIsDone.Checked;
                            db.SaveChanges();
                            lblModalBody.Text = "Tarefa atualizada com sucesso!";
                            hfOperationStatus.Value = "success";
                        }
                    }
                    else
                    {
                        var existsDuplicate = db.Tasks.FirstOrDefault(t => t.Title == txtTaskName.Text);
                        if (existsDuplicate != null)
                        {
                            lblModalBody.Text =
                                $"A tarefa com nome {txtTaskName.Text} já existe! Por favor, insira outro nome.";
                            hfOperationStatus.Value = "error";
                            throw new DuplicateNameException();
                        }

                        db.Tasks.Add(task);
                        db.SaveChanges();
                        lblModalBody.Text = "Tarefa salva com sucesso.";
                        hfOperationStatus.Value = "success";
                    }
                }
            }
            catch (EntityException ex)
            {
                Debug.WriteLine("Error while saving task: ", ex);
                lblModalBody.Text = "Erro ao salvar tarefa. Por favor, tente novamente mais tarde!";
                hfOperationStatus.Value = "error";
            }
            catch (DuplicateNameException duplicateNameException)
            {
                Debug.WriteLine($"The record '{txtTaskName.Text}' already exists.");
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "afterClickModal", "showModal();", true);
        }

        protected void BtnDeleteTask_Click(object sender, EventArgs e)
        {
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
                txtTaskName.Text = task.Title;
                txtTaskDescription.Text = task.Description;
                selectTaskPriority.SelectedValue = task.Priority.ToString();
                chkIsDone.Checked = task.IsDone;
            }
        }
    }
}