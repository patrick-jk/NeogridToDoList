using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateTask : System.Web.UI.Page
{
    private bool IsTaskCreated = false; //TODO: Show Modal after save attempt
    private static readonly ILog log = LogManager.GetLogger(typeof(CreateTask));
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
                db.Tasks.Add(task);
                db.SaveChanges();
            }
            IsTaskCreated = true;
        } catch (Exception ex)
        {
            log.Error("Error while saving task: ", ex);
            IsTaskCreated = false;
        }


    }
    protected void BtnDeleteTask_Click(object sender, EventArgs e)
    {

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}