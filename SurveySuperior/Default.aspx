<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
    <p>
        <a href="Student/TakeSurvey.aspx">TakeSurvey.aspx</a></p>
    <p>
        <a href="Teacher/CreateSurvey.aspx">CreateSurvey.aspx</a></p>
    <p>
        <a href="Teacher/CheckSurvey.aspx">CheckSurvey.aspx</a></p>
    </form>
    <p>
        <a href="Teacher/MakeClass.aspx">MakeClass.aspx</a></p>
</body>
</html>
