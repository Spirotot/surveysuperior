using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class instant_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            int usersCount = Convert.ToInt32(Application["usersCount"]);
            int pollsCount = Convert.ToInt32(Application["pollsCount"]);
            String[,] temp = new String[usersCount + 1, pollsCount];
            temp = (String[,])Application["users"];

            temp[usersCount, 0] = "User" + Convert.ToString(usersCount);
            for (int x = 0; x < pollsCount; x++)
            {
                temp[usersCount, x] = "0";
            }
            usersCount++;
            Application["usersCount"] = usersCount.ToString();
            Application["users"] = temp;
            Session["user"] = "User" + Convert.ToString(usersCount);
        }
        Label1.Text = Application["pollsCount"].ToString() ;
        Label2.Text = Application["usersCount"].ToString();
        Label3.Text = Session["user"].ToString();
        Label4.Text = ((String[,])Application["polls"]).ToString();
        Label5.Text = ((String[,])Application["users"]).ToString();
    }
}