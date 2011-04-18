<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateSurvey.aspx.cs" Inherits="Teacher_CreateSurvey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <p>
        Logged in as:
        <asp:LoginName ID="LoginName1" runat="server" />
    </p>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Survey Name: "></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Question: "></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Answer 1: "></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Answer 2: "></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Answer 3: "></asp:Label>
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Answer 4: "></asp:Label>
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />
&nbsp;<asp:Label ID="Label7" runat="server"></asp:Label>
    </form>
</body>
</html>
