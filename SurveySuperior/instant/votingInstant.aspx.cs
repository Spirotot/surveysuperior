using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class votingInstant : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //TODO
        int pollId = 1;//use request[]
        //
        String[,] temp = (String[,])Application["polls"];
        Label1.Text = temp[pollId, 0];
        Button2.Text = temp[pollId, 1];
        Button3.Text = temp[pollId, 2];
        Button4.Text = temp[pollId, 3];
        Button5.Text = temp[pollId, 4];
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        clicky(1);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        clicky(2);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        clicky(3);
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        clicky(4);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        clicky(5);
    }
    void clicky(int clicked)
    {
        //TODO
        int pollId = 1;//use request[]
        int usersCount = Convert.ToInt32(Application["usersCount"]);
        int pollsCount = Convert.ToInt32(Application["pollsCount"]);
        //
        clicked--;
        
        //get user by username
        String[,] temp = (String[,])Application["users"];
        //Label2.Text = "Voted " + clicked.ToString()+ Session["user"].ToString() + temp[0, 0];
        for (int x = 0; x < usersCount; x++)
        {
            //clicked = clicked;
            temp[x, pollId] = temp[x, pollId];
            if (temp[x, 0] == Session["user"].ToString())
                temp[x, pollId] = Convert.ToString(clicked);
        }
        Application["users"] = temp;
        //
    }
}