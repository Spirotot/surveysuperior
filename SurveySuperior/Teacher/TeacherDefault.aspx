<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherDefault.aspx.cs" Inherits="Teacher_TeacherDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Survey Superior - Teacher Landing</title>
    <style type="text/css">
        body
        {
            font-size:large;
        }
    </style>
    <script type="text/javascript">
        function move(link) {
        //link is the value passed in by the onclick
            if (link == 1)
                document.getElementById("frame").src = "CheckSurvey.aspx";
            if (link == 2)
                document.getElementById("frame").src = "CreateSurvey.aspx";
            if (link == 3)
                document.getElementById("frame").src = "MakeClass.aspx";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float:left; width:10%; min-width:50px;" >
       <div id="1" onclick="move(1)"><img src="../img/checkQuiz.gif" width="15" height="15" />  Check Survey</div> <br /> <br />
        <div id="2" onclick="move(2)"><img src="../img/plus-sign.png" width="15" height="15" />  Create Survey</div> <br /> <br />
        <div id="3" onclick="move(3)"><img src="../img/pencil.gif" width="15" height="15" />  Make Class</div>
    </div>
    <iframe id="frame" width="85%" height="100%" src="">
    </iframe>
    </form>
</body>
</html>
