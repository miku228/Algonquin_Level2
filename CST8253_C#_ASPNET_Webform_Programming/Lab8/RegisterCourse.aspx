<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Course Resitration</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/> 
    </head>
    <body>
        <div class="container">
            <h1 class="h1" >Algonquin College Course Resitration</h1>
            <form id="form1" runat="server" class="bg-light">
                <div class="m-2 h-50">
                    <asp:Label ID="lblSName" runat="server" Text="Student : "></asp:Label>
                
                    <asp:DropDownList ID="ddlSInfo" runat="server" Width="400px"
                        AutoPostBack="True" onselectedindexchanged="studentSelected">
                    </asp:DropDownList>

                    <asp:RequiredFieldValidator ID="rfvSInfo" runat="server" ErrorMessage="Must select one!"
                        ForeColor="Red" Display="Dynamic" ControlToValidate="ddlSInfo" EnableClientScript="true" 
                        InitialValue="0" CssClass="ml-2">
                    </asp:RequiredFieldValidator>

                </div>

                <asp:Label ID="lblRSummary" runat="server" CssClass="font-weight-bold text-info m-2 h-50"></asp:Label>

                <h3 class="m-2 h-50">
                    <asp:Label ID="lblBeforeSelectedTxt" runat="server" CssClass="h3" Text="Following courses are currently available for registration"></asp:Label>
                </h3>
                <asp:Label ID="lblEMessage" runat="server" CssClass="font-weight-bold text-danger m-2 h-50"></asp:Label>

                <asp:CheckBoxList ID="cblAvailableCourses" runat="server" CssClass="container m-2">
                </asp:CheckBoxList>

                <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="cmdSubmit_Click" CssClass="m-2"/>


                <!-- 
                <br />
                <asp:Label ID="lblAfterSelected" runat="server" Text="has enrolled in the following courses"></asp:Label>
            
                <asp:Table ID="tblSelectedCourses" runat="server" CssClass="table table-hover container bg-white" Height="216px" Width="522px">
                    <asp:TableHeaderRow runat="server" TableSection="TableHeader">
                        <asp:TableHeaderCell runat="server">Course Code</asp:TableHeaderCell>
                        <asp:TableHeaderCell runat="server">Course Title</asp:TableHeaderCell>
                        <asp:TableHeaderCell runat="server">Weekly Hours</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            
                -->
            </form>

        </div>
        <asp:HyperLink ID="hlToAddStudent" runat="server" NavigateUrl="~/AddStudent.aspx">Add Student</asp:HyperLink>
    </body>
</html>
