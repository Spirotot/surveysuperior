using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //TODO
        int pollId = 1;//use request[]
        int usersCount = Convert.ToInt32(Application["usersCount"]);
        int pollsCount = Convert.ToInt32(Application["pollsCount"]);
        //
        int a = 0, b = 0, c = 0, d = 0;
        String[,] temp = (String[,])Application["users"];
        //int id = Convert.ToInt32(Request["id"]);
        //The line "arr.GetLength(1)" always gets the number of columns, and "arr.GetLength(0)" gets the number of rows.
        //temp[0] = {"username", "1"};

        //Response.Write("blah" + Convert.ToString(temp[0, 1]=="1"));
        //Console.Write(Convert.ToString(temp.ToString()));
        for (int x = 0; x < usersCount; x++)
        {
            //Console.Write(Convert.ToString(x)+ "x" + "wowowowo\n");
            if (temp[x, pollId] == "1")
                a++;
            if (temp[x, pollId] == "2")
                b++;
            if (temp[x, pollId] == "3")
                c++;
            if (temp[x, pollId] == "4")
                d++;
        }

        
        string aa = a.ToString(), bb = b.ToString(), cc = c.ToString(), dd = d.ToString();
        if (a < 10)
            aa = '0' + a.ToString();
        if (b < 10)
            bb = '0' + b.ToString();
        if (c < 10)
            cc = '0' + c.ToString();
        if (d < 10)
            dd = '0' + d.ToString();
        Response.Write( aa + "," + bb + "," + cc + "," + dd);
        //Response.Write("blah\n");
    }

}