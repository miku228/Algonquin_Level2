<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="Lab5.Statistics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Static Calculator</title>
    <%-- Set style below --%>
    <%-- Use Bootstrap to style the page --%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
    
</head>
<body>
    <div class="container">
        <h1>Static Calculator</h1>
        <p>Enter three numbers and click Submit button to find out the statistics</p>

        <form id="form1" runat="server">
            <div class="form-group row">
                 <asp:Label ID="lblFNum" runat="server" CssClass="col-sm-4 col-form-label"></asp:Label>
                 <asp:TextBox ID="TxtbxFNum" runat="server" CssClass="form-control col-sm-3" autocomplete="off"></asp:TextBox>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblSNum" runat="server" CssClass="col-sm-4 col-form-label"></asp:Label>
                <asp:TextBox ID="TxtbxSNum" runat="server" CssClass="form-control col-sm-3"  autocomplete="off"></asp:TextBox>
            </div>
            <div class="form-group row">
                <asp:Label ID="lblTNum" runat="server" CssClass="col-sm-4 col-form-label"></asp:Label>
                <asp:TextBox ID="TxtbxTNum" runat="server" CssClass="form-control col-sm-3"  autocomplete="off"></asp:TextBox>
            </div>

            <p>
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" />
            </p>
            <asp:Label ID="lblErrorMsg" runat="server" CssClass="alert alert-danger"></asp:Label>


            <h2>Statistics of the numbers you entered</h2>
            <div class="form-group row">
                 <asp:Label ID="lblMax" runat="server" CssClass="col-sm-2 col-form-label"></asp:Label>
                 <asp:Label ID="lblCalMax" runat="server" CssClass="col-sm-3"></asp:Label>
            </div>
             <div class="form-group row">
                 <asp:Label ID="lblMin" runat="server" CssClass="col-sm-2 col-form-label"></asp:Label>
                 <asp:Label ID="lblCalMin" runat="server" CssClass="col-sm-3"></asp:Label>
            </div>
             <div class="form-group row">
                 <asp:Label ID="lblAvg" runat="server" CssClass="col-sm-2 col-form-label"></asp:Label>
                 <asp:Label ID="lblCalAvg" runat="server" CssClass="col-sm-3"></asp:Label>
            </div>
            <div class="form-group row">
                  <asp:Label ID="lblTotal" runat="server" CssClass="col-sm-2 col-form-label"></asp:Label>
                  <asp:Label ID="lblCalTotal" runat="server" CssClass="col-sm-3"></asp:Label>
            </div>
        </form>
    </div>
</body>
</html>
