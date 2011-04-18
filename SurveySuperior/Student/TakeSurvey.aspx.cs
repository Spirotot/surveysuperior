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
        foreach (ListItem li in RadioButtonList1.Items)
        {
            if (li.Selected)
            {
                s = li.Text;
            }
        }

        Label1.Text = s;
        conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        SqlConnection conn = new SqlConnection(conStr);
        conn.Open();
        check = "SELECT Answer FROM Answer WHERE SurveyName = @pSurveyName AND Username = @pUsername";
        SqlCommand cmd1 = new SqlCommand(check, conn);

        cmd1.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);
        cmd1.Parameters.AddWithValue("@pUsername", User.Identity.Name.ToString());

        SqlDataReader dr;
        cmd1.CommandText = check;
        dr = cmd1.ExecuteReader();
        if (dr.Read())
        {
            dr.Close();

            update = "UPDATE Answer SET Answer = @pAnswer WHERE SurveyName = @pSurveyName AND Username  = @pUsername ";
            SqlCommand cmd2 = new SqlCommand(update, conn);
            cmd2.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);
            cmd2.Parameters.AddWithValue("@pUsername ", User.Identity.Name.ToString());
            cmd2.Parameters.AddWithValue("@pAnswer", Label1.Text);
            cmd2.Parameters.AddWithValue("@pDate", DateTime.Now.ToString());
            cmd2.Parameters.AddWithValue("@pClassName", DropDownList1.Text);

            cmd2.CommandText = update;
            cmd2.ExecuteNonQuery();

        }
        else
        {
            dr.Close();
            insert = "INSERT INTO Answer VALUES (@pSurveyName, @pUsername , @pAnswer, @pDate, @pClassName)";
            SqlCommand cmd2 = new SqlCommand(insert, conn);
            cmd2.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);
            cmd2.Parameters.AddWithValue("@pUsername ", User.Identity.Name.ToString());
            cmd2.Parameters.AddWithValue("@pAnswer", Label1.Text);
            cmd2.Parameters.AddWithValue("@pDate", DateTime.Now.ToString());
            cmd2.Parameters.AddWithValue("@pClassName", DropDownList1.Text);

            cmd2.CommandText = insert;
            cmd2.ExecuteNonQuery();
        }
        conn.Close();
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

        sqlStr = "SELECT DISTINCT Date FROM CreateSurvey WHERE (Date IS NOT NULL) AND ClassName = @pClassName";
        SqlCommand cmd = new SqlCommand(sqlStr, conn);
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
        DateTime date = DateTime.Parse(DropDownList2.Text);
        Label2.Text = date.Month.ToString() + '/' + date.Day + '/' + date.Year;

        DropDownList3.AppendDataBoundItems = true;
        DropDownList3.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        DropDownList3.SelectedIndex = 0;
        string conStr;
        string sqlStr;

        conStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(conStr);
        conn.Open();

        sqlStr = "SELECT SurveyName FROM CreateSurvey WHERE Date = @pDate AND ClassName = @pClassName";
        SqlCommand cmd = new SqlCommand(sqlStr, conn);
        cmd.Parameters.AddWithValue("@pDate", Label2.Text);
        cmd.Parameters.AddWithValue("@pClassName", DropDownList1.Text);

        SqlDataReader dr;
        cmd.CommandText = sqlStr;
        dr = cmd.ExecuteReader();
        DropDownList3.DataSource = dr;
        DropDownList3.DataTextField = "SurveyName";
        DropDownList3.DataBind();
        dr.Close();

        sqlStr = "SELECT SurveyQuestion FROM CreateSurvey WHERE Date = @pDate AND ClassName = @pClassName AND SurveyName = @pSurveyName";
        SqlCommand cmd1 = new SqlCommand(sqlStr, conn);
        cmd1.Parameters.AddWithValue("@pDate", Label2.Text);
        cmd1.Parameters.AddWithValue("@pClassName", DropDownList1.Text);
        cmd1.Parameters.AddWithValue("@pSurveyName", DropDownList3.Text);

        SqlDataReader dr1;
        cmd1.CommandText = sqlStr;
        dr1 = cmd1.ExecuteReader();
        if (dr1.Read())
        {
            Label3.Text = dr1.GetValue(0).ToString();
        }
        dr1.Close();

        conn.Close();
    }
}
