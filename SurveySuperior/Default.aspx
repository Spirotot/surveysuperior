<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InstaFeedback</title>
    <link rel="Shortcut Icon" href="img/dsu-logo-2colors_orig.gif" />
    <script type="text/javascript">
        function change(a, b) {
            if (a == 1 && b == 1)
                img1.src = "img/dsu-logo-2colors_stu.gif";
            if (a == 1 && b == 0)
                img1.src = "img/dsu-logo-2colors_none1.gif";
            if (a == 2 && b == 1)
                img2.src = "img/dsu-logo-2colors_tea.gif";
            if (a == 2 && b == 0)
                img2.src = "img/dsu-logo-2colors_none2.gif";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <a href="Student/TakeSurvey.aspx"><img id="img1" onmouseover="change(1,1)" onmouseout="change(1,0)" src="img/dsu-logo-2colors_none1.gif" />
    <a href="Teacher/TeacherDefault.aspx"><img id="img2" onmouseover="change(2,1)" onmouseout="change(2,0)" src="img/dsu-logo-2colors_none2.gif" /></a>
    </form>
</body>
</html>
<!--thalverson thalv1!
    Chuck Chuck1! -->
