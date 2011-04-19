using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Student_TakeSurvey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            // ADD A BLANK TO THE CLASSNAME DROPDOWNLIST (CLASSNAMES ARE THE CONTENTS OF DROPDOWNLIST1)
            DropDownList1.AppendDataBoundItems = true;
            DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            DropDownList1.SelectedIndex = 0;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string conStr;
        string check;
        string update;
        string insert;
        string s = "";

        // DISPLAY SELECTED ANSWER
        foreach (ListItem li in RadioButtonList1.Items)
        {
            if (li.Selected)
            {
                s = li.Text;
            }
        }
        Label1.Text = s;

        // CREATE CONNECTION TO DATABASE
        conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(conStr);
        conn.Open();
        
        //Check SurveyType
        SqlCommand cmd0 = new SqlCommand("SELECT SurveyType FROM CreateSurvey WHERE SurveyName = @pSurveyName", conn);
        cmd0.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);

        SqlDataReader r = cmd0.ExecuteReader();
        while (r.Read())
        {
            if (r["SurveyType"].ToString() == "A" || r["SurveyType"].ToString() == "B") //Anonymous or keep track of who's voted, but not votes
            {
                //Update answer table with username, null answer
                vote("");

                //Update PAnswers, Answercount = Answercount + 1
                SqlCommand cmd99 = new SqlCommand("UPDATE PAnswers SET Answercount = Answercount + 1 WHERE SurveyName = @pSurveyName AND Answer = @pAnswer", conn);
                cmd99.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);
                cmd99.Parameters.AddWithValue("@pAnswer", Label1.Text);

                r.Close();
                cmd99.ExecuteNonQuery();
                break;
            }
            else
            {
                vote(Label1.Text); //This is exactly the same as what Chuck's code was doing before, before I even messed with anything.
            }
        }
        conn.Close();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // CLEAR OUT DATES IN DROPDOWNLIST2
        DropDownList2.Items.Clear();

        // ADD A BLANK TO THE DATE DROPDOWNLIST (DATES ARE THE CONTENTS OF DROPDOWNLIST2)
        DropDownList2.AppendDataBoundItems = true;
        DropDownList2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        DropDownList2.SelectedIndex = 0;

        string conStr;
        string sqlStr;

        // CREATE CONNECTION TO DATABASE
        conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(conStr);
        conn.Open();

        // SELECT DATES OF SURVEYS FROM THE SPECIFIED CLASSNAME AND DATE EXISTS
        sqlStr = "SELECT DISTINCT Date FROM CreateSurvey WHERE (Date IS NOT NULL) AND ClassName = @pClassName";
        SqlCommand cmd = new SqlCommand(sqlStr, conn);
        cmd.Parameters.AddWithValue("@pClassName", DropDownList1.Text);

        // PUT ALL DATES THAT MATCH THIS CRITERIA INTO DROPDOWNLIST2
        SqlDataReader dr;
        cmd.CommandText = sqlStr;
        dr = cmd.ExecuteReader();
        DropDownList2.DataSource = dr;
        DropDownList2.DataTextField = "Date";
        DropDownList2.DataBind();
        dr.Close();
        conn.Close();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        // CONVERT DATE FROM THE DATE DROPDOWNLIST INTO A STRING THAT WILL MATCH WHATS IN OUR DATABASE
        DateTime date = DateTime.Parse(DropDownList2.Text);
        Label2.Text = date.Month.ToString() + '/' + date.Day + '/' + date.Year;

        // CLEAR OUT SURVEY NAMES IN DROPDOWNLIST3
        DropDownList3.Items.Clear();

        // ADD A BLANK TO THE SURVEY NAME DROPDOWNLIST (SURVEY NAMES ARE THE CONTENTS OF DROPDOWNLIST3)
        DropDownList3.AppendDataBoundItems = true;
        DropDownList3.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        DropDownList3.SelectedIndex = 0;

        string conStr;
        string sqlStr;

        // CREATE CONNECTION TO DATABASE
        conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(conStr);
        conn.Open();

        // SELECT SURVEY NAMES OF SURVEYS FROM THE SPECIFIED CLASSNAME AND DATE
        sqlStr = "SELECT SurveyName FROM CreateSurvey WHERE Date = @pDate AND ClassName = @pClassName";
        SqlCommand cmd = new SqlCommand(sqlStr, conn);
        cmd.Parameters.AddWithValue("@pDate", Label2.Text);
        cmd.Parameters.AddWithValue("@pClassName", DropDownList1.Text);

        // PUT ALL SURVEY NAMES THAT MATCH THIS CRITERIA INTO DROPDOWNLIST2
        SqlDataReader dr;
        cmd.CommandText = sqlStr;
        dr = cmd.ExecuteReader();
        DropDownList3.DataSource = dr;
        DropDownList3.DataTextField = "SurveyName";
        DropDownList3.DataBind();
        dr.Close();

        

        conn.Close();
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        string conStr;
        string sqlStr;

        // CREATE CONNECTION TO DATABASE
        conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(conStr);
        conn.Open();

        // SURVEY QUESTION THAT MATCHES DATE, CLASSNAME, AND SURVEY NAME
        sqlStr = "SELECT SurveyQuestion, SurveyType FROM CreateSurvey WHERE Date = @pDate AND ClassName = @pClassName AND SurveyName = @pSurveyName";
        SqlCommand cmd1 = new SqlCommand(sqlStr, conn);
        cmd1.Parameters.AddWithValue("@pDate", Label2.Text);
        cmd1.Parameters.AddWithValue("@pClassName", DropDownList1.Text);
        cmd1.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);

        // DISPLAY SURVEY QUESTION
        SqlDataReader dr1;
        cmd1.CommandText = sqlStr;
        dr1 = cmd1.ExecuteReader();
        if (dr1.Read())
        {
            Label3.Text = dr1.GetValue(0).ToString();
            Label4.Text = dr1["SurveyType"].ToString();
        }
        else
        {
            // THIS SHOULD NEVER HAPPEN BUT I FIGURED I WOULD ADD IT FOR FUNSIES
            Label3.Text = "YOU SUCK!";
        }
        dr1.Close();

        conn.Close();
    }
    protected void vote(string ans)
    {
        // CREATE CONNECTION TO DATABASE
        string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(conStr);
        conn.Open();

        // SELECT ANSWER FROM DATABASE GIVEN BY LOGGED IN USER ON THE GIVEN SURVEY
        string check = "SELECT Answer FROM Answer WHERE SurveyName = @pSurveyName AND Username = @pUsername";
        SqlCommand cmd1 = new SqlCommand(check, conn);
        cmd1.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);
        cmd1.Parameters.AddWithValue("@pUsername", User.Identity.Name.ToString());


        SqlDataReader dr = cmd1.ExecuteReader();
        if (dr.Read())
        {
            // IF AN ANSWER WAS ALREADY GIVEN FOR THIS SURVEY CHANGE IT TO THE NOW SELECTED ANSWER
            dr.Close();
            string update = "UPDATE Answer SET Answer = @pAnswer WHERE SurveyName = @pSurveyName AND Username  = @pUsername ";
            SqlCommand cmd2 = new SqlCommand(update, conn);
            cmd2.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);
            cmd2.Parameters.AddWithValue("@pUsername ", User.Identity.Name.ToString());
            cmd2.Parameters.AddWithValue("@pAnswer", ans);
            cmd2.Parameters.AddWithValue("@pDate", DateTime.Now.ToString());
            cmd2.Parameters.AddWithValue("@pClassName", DropDownList1.Text);

            cmd2.CommandText = update;
            cmd2.ExecuteNonQuery();

        }
        else
        {
            // OTHERWISE INSERT ANSWER INTO ANSWER TABLE
            dr.Close();
            string insert = "INSERT INTO Answer VALUES (@pSurveyName, @pUsername , @pAnswer, @pDate, @pClassName)";
            SqlCommand cmd2 = new SqlCommand(insert, conn);
            cmd2.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);
            cmd2.Parameters.AddWithValue("@pUsername ", User.Identity.Name.ToString());
            cmd2.Parameters.AddWithValue("@pAnswer", ans);
            cmd2.Parameters.AddWithValue("@pDate", DateTime.Now.ToString());
            cmd2.Parameters.AddWithValue("@pClassName", DropDownList1.Text);

            cmd2.CommandText = insert;
            cmd2.ExecuteNonQuery();
        }
        conn.Close();
    }

}
