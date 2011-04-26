<%@ Page Language="C#" AutoEventWireup="true" CodeFile="votePage.aspx.cs" Inherits="votePage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" >
    <title></title>
    <script type="text/javascript">
        var t;
        function update() {
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            //http://localhost:58557/Voting/votePage.aspx?id=1
            var loc = window.location.href;
            var x = loc.length;
            var poll;
            //alert(loc.length);
            poll = (loc.charAt(x - 1) - '0')
            if (loc.charAt(x - 2) >= '0' && loc.charAt(x - 2) <= '9')
                poll = (loc.charAt(x - 2) - '0') * 10 + (loc.charAt(x - 1) - '0');
            //alert(poll);
            xmlhttp.open("GET", "count.aspx?t=" + Math.random() + "&id=" + poll, false);
            xmlhttp.send();
            var res = xmlhttp.responseText;
            //W
            //var patt = new RegExp(xmlhttp.responseText, "/^\d*/")
            var offset = 0;
            var a = parseInt(res.charAt(offset + 0) * 10 + res.charAt(offset + 1));
            var b = parseInt(res.charAt(offset + 3) * 10 + res.charAt(offset + 4));
            var c = parseInt(res.charAt(offset + 6) * 10 + res.charAt(offset + 7));
            var d = parseInt(res.charAt(offset + 9) * 10 + res.charAt(offset + 10));
            //document.write(a + " " + b + " " + c + " " + d);

            //alert(a);
            document.getElementById("Div1").innerHTML = a;
            document.getElementById("Div2").innerHTML = b;
            document.getElementById("Div3").innerHTML = c;
            document.getElementById("Div4").innerHTML = d;
            // t = clearTimeout();
            // t = setTimeout(update(), 5000);
        }
        // setInterval("update()", 5000);
        function start() {
            t = setTimeout(update(), 5000);
        }
        /*function vote(num){
        alert(num);
        }*/

    </script>
</head>
<body onload="update(); setInterval('update()', 5000 )">
    <form id="form1" runat="server">
<div id="Div1"  style="float: left; width 15px; padding:25px; background-color:LightBlue; margin:5px;"></div>
<div id="Div2"  style="float: left; width= 15px; padding:25px; background-color:LightBlue; margin:5px;"></div>
<div id="Div3"  style="float: left; width= 15px; padding:25px; background-color:LightBlue; margin:5px;"></div>
<div id="Div4"  style="float: left; width= 15px; padding:25px; background-color:LightBlue; margin:5px;"></div>
    <p>
        &nbsp;</p>
    <br />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Change" />
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Reset" />
    </form>
</body>
</html>