using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Teacher_MakeClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
        string conStr;
        string check;
        string insert;

        // CREATE CONNECTION TO DATABASE
        conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(conStr);
        conn.Open();

        // CHECK IF CLASSNAME IS ALREADY IN CLASS TABLE
        check = "SELECT ClassName FROM Class WHERE ClassName = @pClassName";
        SqlCommand cmd1 = new SqlCommand(check, conn);
        cmd1.Parameters.AddWithValue("@pClassName", TextBox1.Text);

        SqlDataReader dr;
        cmd1.CommandText = check;
        dr = cmd1.ExecuteReader();
        if (dr.Read())
        {
            dr.Close();
            // IF CLASSNAME IS IN CLASS TABLE TELL USER TO PICK A DIFFERENT CLASS NAME
            Label2.Text = "Pick a different class name.";
        }
        else
        {
            // OTHERWISE INSERT CLASSNAME ANDT TEACHER INTO CLASS TABLE
            dr.Close();
            insert = "INSERT INTO Class VALUES (@pClassName, @pTeacher)";
            SqlCommand cmd2 = new SqlCommand(insert, conn);
            cmd2.Parameters.AddWithValue("@pClassName", TextBox1.Text);
            cmd2.Parameters.AddWithValue("@pTeacher", User.Identity.Name.ToString());

            cmd2.CommandText = insert;
            cmd2.ExecuteNonQuery();
        }
        Response.Redirect("TeacherDefault.aspx");
    }
}
