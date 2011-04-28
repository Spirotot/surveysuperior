<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TakeSurvey.aspx.cs" Inherits="Student_TakeSurvey" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Logged in as:
        <asp:LoginName ID="LoginName1" runat="server" />
    
    </div>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        DataSourceID="SqlDataSource1" DataTextField="ClassName" 
        DataValueField="ClassName" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT [ClassName] FROM [Class]"></asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList2_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT [Date] FROM [CreateSurvey] WHERE ([ClassName] = @ClassName)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="ClassName" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList3_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT [SurveyName] FROM [CreateSurvey] WHERE (([ClassName] = @ClassName) AND ([Date] = @Date))">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="ClassName" 
                PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="DropDownList2" DbType="Date" Name="Date" 
                PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    Question:
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    <br />
    Type:
    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
        DataSourceID="SqlDataSource4" DataTextField="Answer" 
        DataValueField="Answer">
    </asp:RadioButtonList>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT [Answer] FROM [PAnswers] WHERE ([SurveyName] = @SurveyName)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList3" Name="SurveyName" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" /> <br />
    Last Choice: <asp:Label ID="Label1" runat="server" Text=""></asp:Label> <br />
    Made On: <asp:Label ID="Label2" runat="server"></asp:Label>
    </form>
    <p>
        <a href="../Default.aspx">Splash Page</a></p>
</body>
</html>
