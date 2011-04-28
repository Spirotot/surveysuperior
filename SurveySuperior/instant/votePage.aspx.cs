using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class votePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //TODO
        //SHOW ID
        int pollId = 1;//use request[]
        //
        String[,] temp = (String[,])Application["polls"];
        Label1.Text = temp[pollId, 0];
        Label2.Text = temp[pollId, 1];
        Label3.Text = temp[pollId, 2];
        Label4.Text = temp[pollId, 3];
        Label5.Text = temp[pollId, 4];
        
        //String[][] temp = (String[][])Application["polls"];
       // Application["polls"] = temp;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("changeInsta.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //TODO
        int pollId = 1;//use request[]
        int usersCount = Convert.ToInt32(Application["usersCount"]);
        int pollsCount = Convert.ToInt32(Application["pollsCount"]);
        //
        String[,] temp = (String[,])Application["users"];
        int x;
        for (x = 0; x < usersCount; x++)
        {
            temp[x, pollId] = "";
        }
        Application["users"] = temp;
        //Response.Write("x" + x.ToString() + " "+ temp[x-1, pollId].ToString());
        
    }
}