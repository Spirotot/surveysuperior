<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="instant_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Welcome! You have just had some variables set for you! :) Have a peachy day.<br />
        <a href="changeInsta.aspx">changeInsta.aspx</a> - change your poll!<br />
        <a href="votePage.aspx">votePage.aspx</a> - watch the votes as they come in W00T<br />
        <a href="votingInstant.aspx">votingInstant.aspx</a> - vote on your poll!<br />
        <a href="newPoll.aspx">newPoll.aspx</a> - create a new poll... WOW!<br />
        <br />
        <br />
        polls
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        users
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        name
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <br />
        polls
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <br />
        users
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
