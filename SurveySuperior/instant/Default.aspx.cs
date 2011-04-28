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
        //Label1.Text = Session["user"].ToString();
        String[,] temp = new String[1000, 1000];
        temp = (String[,])Application["users"];
        if (Session["user"] == null)
        {
            
            int usersCount = Convert.ToInt32(Application["usersCount"]);
            int pollsCount = Convert.ToInt32(Application["pollsCount"]);


            
            /*for (int x = 1; x <= pollsCount; x++)
            {
                temp[usersCount, x] = "0";
            }*/
            temp[usersCount, 0] = "User" + Convert.ToString(usersCount);
            Session["user"] = "User" + Convert.ToString(usersCount);
            usersCount++;
            Application["usersCount"] = usersCount.ToString();
            Application["users"] = temp;
            
        }
        //temp=temp;
        Label1.Text = Application["pollsCount"].ToString();
        Label2.Text = Application["usersCount"].ToString();
        Label3.Text = Session["user"].ToString();
        Label4.Text = ((String[,])Application["polls"]).ToString();
        Label5.Text = ((String[,])Application["users"]).ToString();
    }
}