<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckSurvey.aspx.cs" Inherits="Teacher_CheckSurvey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float:left">
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:Label ID="Label9" runat="server"></asp:Label>
    <br />
    <br />
    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList2_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    Total Questions:     <asp:Label ID="Label10" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" HeaderStyle-BackColor="Blue" HeaderStyle-Font-Italic="true" HeaderStyle-ForeColor="Yellow" RowStyle-BackColor="OldLace" AlternatingRowStyle-BackColor="LightGray">
    </asp:GridView>
    <br />
    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList3_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    <a href="../Default.aspx">Default.aspx</a><br />
    </div>
    <div style="position:relative; float:left; left:10px">
    Survey type:
    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" CssClass="lbl" Text="Label" Width="40"></asp:Label>
    &nbsp;students picked
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" CssClass="lbl" Text="Label" Width="40"></asp:Label>
    &nbsp;students picked
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label5" runat="server" CssClass="lbl" Text="Label" Width="40"></asp:Label>
    &nbsp;students picked
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label7" runat="server" CssClass="lbl" Text="Label" Width="40"></asp:Label>
    &nbsp;students picked
    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
    &nbsp;<br />
    <br />
    <asp:GridView ID="GridView2" runat="server" HeaderStyle-BackColor="Blue" HeaderStyle-Font-Italic="true" HeaderStyle-ForeColor="Yellow" RowStyle-BackColor="OldLace" AlternatingRowStyle-BackColor="LightGray">
    </asp:GridView>
    </div>
    <br />
    </form>
</body>
</html>
