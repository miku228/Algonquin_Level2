<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RegisteredInfo.aspx.cs" Inherits="FinalProject.RegisteredInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="container">

        <!-- Title -->
        <h1 class="mt-5 mb-5">Register Info</h1>
        <!-- Title -->

        <!-- Table -->
        <asp:Table ID="tblAddedCars" runat="server" CssClass="table table-striped mb-5">
            <asp:TableHeaderRow runat="server" TableSection="TableHeader">
                <asp:TableHeaderCell runat="server">ID</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Name</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Car Type</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Max Riding Capacity</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Engine Type</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Registered Store</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <!-- Table -->

        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-outline-secondary" OnClick="cmdClear_Click"/>


    
    </main>

</asp:Content>
