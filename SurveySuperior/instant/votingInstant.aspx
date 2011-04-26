<%@ Page Language="C#" AutoEventWireup="true" CodeFile="votingInstant.aspx.cs" Inherits="votingInstant" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Button" />
        <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="Button" />
        <asp:Button ID="Button5" runat="server" Text="Button" 
            onclick="Button5_Click" />
    
        <br />
        <br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
