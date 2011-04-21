using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class changeInsta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //TODO
        if (!IsPostBack)
        {
            int pollId = 0;//use request[]
            //
            String[,] temp = (String[,])Application["polls"];
            TextBox1.Text = temp[pollId, 0];
            TextBox2.Text = temp[pollId, 1];
            TextBox3.Text = temp[pollId, 2];
            TextBox4.Text = temp[pollId, 3];
            TextBox5.Text = temp[pollId, 4];
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //TODO
        int pollId = 0;//use request[]
        //
        String[,] temp = (String[,])Application["polls"];
        temp[pollId, 0] = TextBox1.Text;
        temp[pollId, 1] = TextBox2.Text;
        temp[pollId, 2] = TextBox3.Text;
        temp[pollId, 3] = TextBox4.Text;
        temp[pollId, 4] = TextBox5.Text;
        Application["polls"] = temp;
        Response.Redirect("votePage.aspx");
    }
}