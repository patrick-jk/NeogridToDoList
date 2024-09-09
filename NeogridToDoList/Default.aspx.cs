using Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default : Page
{
    protected void BtnGoToCreateTask_Click(object sender, EventArgs e)
    {
        Response.Redirect("Pages/CreateTask/CreateTask.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTaskList();
        }
    }

    private void BindTaskList()
    {
        try
        {
            using (var db = new TaskDbContext())
            {
                var taskList = db.Tasks.ToList();
                Debug.WriteLine(taskList.Count + " ROWS");
                rptTasks.DataSource = taskList;
                rptTasks.DataBind();
            }
        }
        catch (Exception ex)
        {
            // Handle exception
            Debug.WriteLine(ex);
        }
    }

    protected void chkIsDone_CheckedChanged(object sender, EventArgs e)
    {
        var chkIsDone = (CheckBox)sender;
        var item = (RepeaterItem)chkIsDone.NamingContainer;
        var hfTaskId = (HiddenField)item.FindControl("hfTaskId");

        var taskId = int.Parse(hfTaskId.Value);
        var isDone = chkIsDone.Checked;

        using (var db = new TaskDbContext())
        {
            var task = db.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null) return;
            task.IsDone = isDone;
            db.SaveChanges();
        }
    }

    protected void BtnTaskDetails_OnClick(object sender, EventArgs e)
    {
        var btnDetails = (Button)sender;
        var taskId = int.Parse(btnDetails.CommandArgument);
        Response.Redirect($"~/Pages/CreateTask/CreateTask.aspx?taskId={taskId}");
    }

    protected string GetPriorityLabel(int priority)
    {
        switch (priority)
        {
            case 1:
                return "Baixa";
            case 2:
                return "Média";
            case 3:
                return "Alta";
            default:
                return "Desconhecida";
        }
    }

    protected void searchTasks_OnTextChanged(object sender, EventArgs e)
    {
        var searchBox = (TextBox)sender;
        var searchText = searchBox.Text.Trim().ToLower();

        using (var db = new TaskDbContext())
        {
            var taskList = db.Tasks.Where(task => task.Title.ToLower().Contains(searchText)).ToList();

            rptTasks.DataSource = taskList;
            rptTasks.DataBind();
        }
    }
}