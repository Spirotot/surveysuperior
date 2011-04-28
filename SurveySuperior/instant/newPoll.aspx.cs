using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class instant_newPoll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int usersCount = Convert.ToInt32(Application["usersCount"]);
        int pollsCount = Convert.ToInt32(Application["pollsCount"]);
        String[,] temp = (String[,])Application["users"];
        pollsCount++;

        for (int x = 0; x < usersCount; x++)
        {
            temp[pollsCount, x] = "0";
        }
        Application["users"] = temp;
        temp = (String[,])Application["polls"];
        temp[pollsCount, 0] = TextBox1.Text;
        temp[pollsCount, 1] = TextBox2.Text;
        temp[pollsCount, 2] = TextBox3.Text;
        temp[pollsCount, 3] = TextBox4.Text;
        temp[pollsCount, 4] = TextBox5.Text;
        Application["pollsCount"] = pollsCount.ToString();
        Application["polls"] = temp;
        Response.Redirect("default.aspx");
    }
}