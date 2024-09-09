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
        CheckBox chkIsDone = (CheckBox)sender;
        RepeaterItem item = (RepeaterItem)chkIsDone.NamingContainer;
        HiddenField hfTaskId = (HiddenField)item.FindControl("hfTaskId");

        int taskId = int.Parse(hfTaskId.Value);
        bool isDone = chkIsDone.Checked;

        using (var db = new TaskDbContext())
        {
            var task = db.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.IsDone = isDone;
                db.SaveChanges();
            }
        }

        // Optionally, rebind the repeater to reflect changes
        // BindRepeater();
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
                return "Baixa"; // Low
            case 2:
                return "Média"; // Medium
            case 3:
                return "Alta"; // High
            default:
                return "Desconhecida";
        }
    }
}