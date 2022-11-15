<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab6.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Algonquin College Course Resitration</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/> 
    
</head>
<body class="">
    <div class="container">
        <h1 class="h1" >Algonquin College Course Resitration</h1>
        <form id="form1" runat="server" class="bg-light">
            <div>
                <asp:Label ID="lblSName" runat="server" Text="Student Name : "></asp:Label>
                <asp:TextBox ID="txtbSName" runat="server" Width="260px" autocomplete="off"></asp:TextBox>
                <asp:RadioButtonList ID="rblStudentType" runat="server" RepeatDirection="Horizontal" Width="593px" style="margin-bottom: 0px">
                    <asp:ListItem Value="1">Full Time</asp:ListItem>
                    <asp:ListItem Value="2">Part Time</asp:ListItem>
                    <asp:ListItem Value="3">Co-op</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="lblErrorMsg" runat="server" CssClass="alert alert-danger p-2"></asp:Label>
            </div>

        
            <h3>
                <asp:Label ID="lblBeforeSelectedTxt" runat="server" CssClass="h3" Text="Following courses are currently available for registration"></asp:Label>
            </h3>
            <asp:CheckBoxList ID="cblAvailableCourses" runat="server" CssClass="container">
            </asp:CheckBoxList>

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="cmdSubmit_Click"/>

            <br />
            <asp:Label ID="lblAfterSelected" runat="server" Text="has enrolled in the following courses"></asp:Label>

            <asp:Table ID="tblSelectedCourses" runat="server" CssClass="table table-hover container bg-white" Height="216px" Width="522px">
                <asp:TableHeaderRow runat="server" TableSection="TableHeader">
                    <asp:TableHeaderCell runat="server">Course Code</asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server">Course Title</asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server">Weekly Hours</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>

            <asp:Button ID="btnReload" runat="server" Text="Reload" OnClick="cmdReload_Click"/>

        </form>

    </div>
    
</body>
</html>
