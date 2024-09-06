using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void BtnGoToCreateTask_Click(object sender, EventArgs e)
    {
        Response.Redirect("Pages/CreateTask/CreateTask.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}