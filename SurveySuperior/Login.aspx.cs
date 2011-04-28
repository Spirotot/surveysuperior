using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void change(object sender, EventArgs e)
    {
        if (createUser.Text == "Create New Account")
        {
            Login1.Visible = false;
            CreateUserWizard1.Visible = true;
            createUser.Text = "Go Back";
        }
        else
        {
            Login1.Visible = true;
            CreateUserWizard1.Visible = false;
            createUser.Text = "Create New Account";
        }
    }
}
