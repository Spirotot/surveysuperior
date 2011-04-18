using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Teacher_CheckSurvey : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DropDownList1.AppendDataBoundItems = true;
            DropDownList1.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            DropDownList1.SelectedIndex = 0;
            

            string conStr;
            string sqlStr;

            conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            sqlStr = "SELECT DISTINCT ClassName FROM CreateSurvey WHERE Creator = @pCreator";
            SqlCommand cmd = new SqlCommand(sqlStr, conn);
            cmd.Parameters.AddWithValue("@pCreator", User.Identity.Name.ToString());
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList2.AppendDataBoundItems = true;
        DropDownList2.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        DropDownList2.SelectedIndex = 0;

        string conStr;
        string sqlStr;

        conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        SqlConnection conn = new SqlConnection(conStr);
        conn.Open();
        sqlStr = "SELECT DISTINCT Date FROM CreateSurvey WHERE (Date IS NOT NULL) AND Creator = @pCreator AND ClassName = @pClassName";
        SqlCommand cmd = new SqlCommand(sqlStr, conn);
        cmd.Parameters.AddWithValue("@pCreator", User.Identity.Name.ToString());
        cmd.Parameters.AddWithValue("@pClassName", DropDownList1.Text);
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
        string conStr;
        string check;
        string sqlStr;

        DropDownList3.AppendDataBoundItems = true;
        DropDownList3.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        DropDownList3.SelectedIndex = 0;

        DateTime date = DateTime.Parse(DropDownList2.Text);
        Label9.Text = date.Month.ToString() + '/' + date.Day + '/' + date.Year;

        conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        SqlConnection conn = new SqlConnection(conStr);
        conn.Open();

        sqlStr = "SELECT SurveyName FROM CreateSurvey WHERE Creator = @pCreator AND Date = @pDate";
        SqlCommand cmd = new SqlCommand(sqlStr, conn);
        cmd.Parameters.AddWithValue("@pCreator", User.Identity.Name.ToString());
        cmd.Parameters.AddWithValue("@pDate", Label9.Text);
        SqlDataReader dr;
        cmd.CommandText = sqlStr;
        dr = cmd.ExecuteReader();
        DropDownList3.DataSource = dr;
        DropDownList3.DataTextField = "SurveyName";
        DropDownList3.DataBind();
        dr.Close();

        sqlStr = "SELECT Username, COUNT(*) FROM Answer WHERE Date = @pDate AND ClassName = @pClassName GROUP BY Username";

        SqlCommand ccmd = new SqlCommand(sqlStr, conn);
        ccmd.Parameters.AddWithValue("@pDate", Label9.Text);
        ccmd.Parameters.AddWithValue("@pClassName", DropDownList1.Text);
        SqlDataReader reader;
        reader = ccmd.ExecuteReader();

        GridView1.DataSource = reader;
        GridView1.DataBind();

        reader.Close();

        int total;

        check = "SELECT count(SurveyName) FROM CreateSurvey WHERE ClassName = @pClassName AND Date = @pDate";
        SqlCommand cmd9 = new SqlCommand(check, conn);

        cmd9.Parameters.AddWithValue("@pClassName", DropDownList1.Text);
        cmd9.Parameters.AddWithValue("@pDate", Label9.Text);
        cmd9.CommandText = check;
        total = (int)cmd9.ExecuteScalar();

        Label10.Text = total.ToString();
       
        conn.Close();
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.Text != "")
        {
            string conStr;
            string sqlStr;
            string user;
            string check;
            int star;
            string sstr = "%";

            conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            SqlDataReader dr;

            check = "SELECT A1 FROM CreateSurvey WHERE SurveyName = @pSurveyName";
            SqlCommand cmd1 = new SqlCommand(check, conn);

            cmd1.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);

            cmd1.CommandText = check;
            dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                Label2.Text = dr.GetValue(0).ToString();
            }
            dr.Close();

            check = "SELECT A2 FROM CreateSurvey WHERE SurveyName = @pSurveyName";
            SqlCommand cmd2 = new SqlCommand(check, conn);

            cmd2.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);

            cmd2.CommandText = check;
            dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                Label4.Text = dr.GetValue(0).ToString();
            }
            dr.Close();

            check = "SELECT A3 FROM CreateSurvey WHERE SurveyName = @pSurveyName";
            SqlCommand cmd3 = new SqlCommand(check, conn);

            cmd3.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);

            cmd3.CommandText = check;
            dr = cmd3.ExecuteReader();
            if (dr.Read())
            {
                Label6.Text = dr.GetValue(0).ToString();
            }
            dr.Close();

            check = "SELECT A4 FROM CreateSurvey WHERE SurveyName = @pSurveyName";
            SqlCommand cmd4 = new SqlCommand(check, conn);

            cmd4.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);

            cmd4.CommandText = check;
            dr = cmd4.ExecuteReader();
            if (dr.Read())
            {
                Label8.Text = dr.GetValue(0).ToString();
            }
            dr.Close();


            int c1 = 0;

            check = "SELECT count(Answer) FROM Answer WHERE SurveyName = @pSurveyName AND Answer = @pA1";
            SqlCommand cmd5 = new SqlCommand(check, conn);

            cmd5.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);
            cmd5.Parameters.AddWithValue("@pA1", Label2.Text);
            c1 = (int)cmd5.ExecuteScalar();

            int c2 = 0;

            check = "SELECT count(Answer) FROM Answer WHERE SurveyName = @pSurveyName AND Answer = @pA2";
            SqlCommand cmd6 = new SqlCommand(check, conn);

            cmd6.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);
            cmd6.Parameters.AddWithValue("@pA2", Label4.Text);
            c2 = (int)cmd6.ExecuteScalar();

            int c3 = 0;

            check = "SELECT count(Answer) FROM Answer WHERE SurveyName = @pSurveyName AND Answer = @pA3";
            SqlCommand cmd7 = new SqlCommand(check, conn);

            cmd7.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);
            cmd7.Parameters.AddWithValue("@pA3", Label6.Text);
            c3 = (int)cmd7.ExecuteScalar();

            int c4 = 0;

            check = "SELECT count(Answer) FROM Answer WHERE SurveyName = @pSurveyName AND Answer = @pA4";
            SqlCommand cmd8 = new SqlCommand(check, conn);

            cmd8.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);
            cmd8.Parameters.AddWithValue("@pA4", Label8.Text);
            cmd8.CommandText = check;
            c4 = (int)cmd8.ExecuteScalar();

            Label1.Text = c1.ToString();
            Label3.Text = c2.ToString();
            Label5.Text = c3.ToString();
            Label7.Text = c4.ToString();



            conn.Close();
        }
    }
}
