using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Teacher_CreateSurvey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // ADD A BLANK TO THE CLASSNAME DROPDOWNLIST (CLASSNAMES ARE THE CONTENTS OF DROPDOWNLIST1)
            DropDownList1.AppendDataBoundItems = true;
            DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            DropDownList1.SelectedIndex = 0;

            string conStr;
            string sqlStr;

            // CREATE CONNECTION TO DATABASE
            conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();

            // SELECT ALL CLASSNAMES THAT WERE MADE BY THE LOGGED IN TEACHER
            sqlStr = "SELECT ClassName FROM Class WHERE Teacher = @pTeacher";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@pTeacher", User.Identity.Name.ToString());

            // PUT ALL CLASSNAMES THAT MATCH THIS CRITERIA INTO DROPDOWNLIST1
            SqlDataReader dr;
            cmd.CommandText = sqlStr;
            dr = cmd.ExecuteReader();
            DropDownList1.DataSource = dr;
            DropDownList1.DataTextField = "ClassName";
            DropDownList1.DataBind();
            dr.Close();
            conn.Close();

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string conStr;
        string check;
        string insert;
        string date = DateTime.Now.Date.ToString();

        // CREATE CONNECTION TO DATABASE
        conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(conStr);
        conn.Open();

        // CHECK TO SEE IF SURVERYNAME ALREADY EXISTS
        check = "SELECT SurveyName FROM CreateSurvey WHERE SurveyName = @pSurveyName";
        SqlCommand cmd1 = new SqlCommand(check, conn);
        cmd1.Parameters.AddWithValue("@pSurveyName", TextBox1.Text);

        SqlDataReader dr;
        cmd1.CommandText = check;
        dr = cmd1.ExecuteReader();
        if (dr.Read())
        {
            // IF IT DOES TELL USER TO PICK A DIFFERENT SURVEY NAME
            dr.Close();
            Label7.Text = "Pick a different survey name.";
        }
        else
        {
            // OTHERWISE PUT THE SURVERYNAME, ANSWERS, CREATOR, DATE, ETC INTO CREATESURVERY TABLE
            dr.Close();
            insert = "INSERT INTO CreateSurvey VALUES (@pSurveyName, @pCreator, @pSurveyQuestion, @pA1, @pA2, @pA3, @pA4, @pDate, @pClassName)";
            SqlCommand cmd2 = new SqlCommand(insert, conn);
            cmd2.Parameters.AddWithValue("@pSurveyName", TextBox1.Text);
            cmd2.Parameters.AddWithValue("@pCreator", User.Identity.Name.ToString());
            cmd2.Parameters.AddWithValue("@pSurveyQuestion", TextBox2.Text);
            cmd2.Parameters.AddWithValue("@pA1", TextBox3.Text);
            cmd2.Parameters.AddWithValue("@pA2", TextBox4.Text);
            cmd2.Parameters.AddWithValue("@pA3", TextBox5.Text);
            cmd2.Parameters.AddWithValue("@pA4", TextBox6.Text);
            cmd2.Parameters.AddWithValue("@pDate", date);
            cmd2.Parameters.AddWithValue("@pClassName", DropDownList1.Text);

            cmd2.CommandText = insert;
            cmd2.ExecuteNonQuery();

            // INSERT POSSIBLE ANSWERS INTO PANSWERS TABLE (ALLOWS US TO EASILY PRINT OUT THE POSSIBLE ANSWERS FOR THE SURVEY TAKERS)
            insert = "INSERT INTO PAnswers VALUES (@pSurveyName, @pA1)";
            SqlCommand cmd3 = new SqlCommand(insert, conn);
            cmd3.Parameters.AddWithValue("@pSurveyName", TextBox1.Text);
            cmd3.Parameters.AddWithValue("@pA1", TextBox3.Text);

            cmd3.CommandText = insert;
            cmd3.ExecuteNonQuery();


            insert = "INSERT INTO PAnswers VALUES (@pSurveyName, @pA2)";
            SqlCommand cmd4 = new SqlCommand(insert, conn);
            cmd4.Parameters.AddWithValue("@pSurveyName", TextBox1.Text);
            cmd4.Parameters.AddWithValue("@pA2", TextBox4.Text);

            cmd4.CommandText = insert;
            cmd4.ExecuteNonQuery();


            insert = "INSERT INTO PAnswers VALUES (@pSurveyName, @pA3)";
            SqlCommand cmd5 = new SqlCommand(insert, conn);
            cmd5.Parameters.AddWithValue("@pSurveyName", TextBox1.Text);
            cmd5.Parameters.AddWithValue("@pA3", TextBox5.Text);

            cmd5.CommandText = insert;
            cmd5.ExecuteNonQuery();


            insert = "INSERT INTO PAnswers VALUES (@pSurveyName, @pA4)";
            SqlCommand cmd6 = new SqlCommand(insert, conn);
            cmd6.Parameters.AddWithValue("@pSurveyName", TextBox1.Text);
            cmd6.Parameters.AddWithValue("@pA4", TextBox6.Text);

            cmd6.CommandText = insert;
            cmd6.ExecuteNonQuery();

            Response.Redirect("../Default.aspx");
        }
        conn.Close();
    }
}
