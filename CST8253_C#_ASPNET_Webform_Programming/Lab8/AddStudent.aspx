<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.3.1/dist/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
        <title>Add Student</title>
    </head>
    <body>
        <form id="form1" runat="server" class="bg-light">
                <h1 style="color: green;">Students </h1>
                <hr style="border: 1px solid green" />
                <div class="m-2 h-50">
                    <asp:Label ID="lblSName" runat="server" Text="Student Name :" CssClass="w-25"></asp:Label>
                    <asp:TextBox ID="txtbSName" runat="server" Width="285px" autocomplete="off" CssClass="w-25"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSName" runat="server" ErrorMessage="Required!"
                        ForeColor="Red" Display="Dynamic" ControlToValidate="txtbSName" EnableClientScript="true">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="m-2 h-50">
                    <asp:Label ID="lblSType" runat="server" Text="Student Type :" CssClass="w-25"></asp:Label>
                    <asp:DropDownList ID="ddlSType" runat="server" Width="318px" CssClass="w-25">
                        <asp:ListItem Value="0" hidden="true">-- Select --</asp:ListItem>
                        <asp:ListItem Value="1">Full Time</asp:ListItem>
                        <asp:ListItem Value="2">Part Time</asp:ListItem>
                        <asp:ListItem Value="3">Coop</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvSType" runat="server" ErrorMessage="Must Select one!"
                        ForeColor="Red" Display="Dynamic" ControlToValidate="ddlSType" EnableClientScript="true">
                    </asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvSTypeVlidation" runat="server" ErrorMessage="Must Select One!"
                       ForeColor="Red" Display="Dynamic" ControlToValidate="ddlSType" EnableClientScript="true" MaximumValue="3" MinimumValue="1" ></asp:RangeValidator>
                </div>
            

                <p class="ml-3">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-outline-success" Text="Add" Width="93px" OnClick="cmdAdd_Click" />
                </p>

                <!-- 
                <p>    
                    <asp:Button ID="btbClear" runat="server" CssClass="btn btn-outline-secondary" Visible="true" Text="Clear" Width="91px" OnClick="cmdClear_Click" />
                </p>
        
                -->

                <asp:Table ID="tblAddedStudents" runat="server" CssClass="table table-hover container bg-white" Height="216px" Width="522px">
                    <asp:TableHeaderRow runat="server" TableSection="TableHeader">
                        <asp:TableHeaderCell runat="server">ID</asp:TableHeaderCell>
                        <asp:TableHeaderCell runat="server">Name</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>  
        
                <asp:HyperLink ID="hlToRegerterCourse" runat="server" NavigateUrl="~/RegisterCourse.aspx">
                    Register Course
                </asp:HyperLink>
            </form>
    </body>
</html>
