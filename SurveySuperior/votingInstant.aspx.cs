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
        int pollId = 0;//use request[]
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
    void clicky(int clicked)
    {
        //TODO
        int pollId = 0;//use request[]
        //
        //get user by username
        String[,] temp = (String[,])Application["users"];
        
        for (int x = 0; x < temp.Length / 2; x++)
        {
            if (temp[x, 0] == User.Identity.Name.ToString())
                temp[x, pollId+1] = Convert.ToString(clicked);
        }
        Application["users"] = temp;
        //
    }
}