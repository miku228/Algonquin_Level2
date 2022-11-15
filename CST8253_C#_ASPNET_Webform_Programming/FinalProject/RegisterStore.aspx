<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RegisterStore.aspx.cs" Inherits="FinalProject.RegisterStore" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="container">
        <!-- Title -->
        <h1 class="mt-5 mb-5">Register Store</h1>
        <p>Please input info and select store(s) to register a new car.</p>
        <p>Car type and store speciality must be matched.</p>
        <p>SUV Cars are both family and sports car.</p>
        <!-- Title -->
        <!-- Input Form -->

        <!-- Error Message -->
        <asp:Label ID="lblEMessage" runat="server" CssClass="font-weight-bold m-2 h-50 text-danger"></asp:Label>
        <br />
        <!-- Error Message -->
        
        <!-- Car Name -->
        <div class="form-group row mt-3">
            <asp:Label ID="lblCName" runat="server" CssClass="control-label col-sm-2">Car Name :</asp:Label>
            <div class="col-sm-3">
                <asp:TextBox ID="txtbCName" runat="server" autocomplete="off" CssClass=""></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator ID="rfvCName" runat="server" ErrorMessage="Required!"
                                        ForeColor="Red" Display="Dynamic" ControlToValidate="txtbCName"
                                        EnableClientScript="true" CssClass="col-sm-7">
            </asp:RequiredFieldValidator>
            <br /> 
        </div>
        <!-- Car Name -->
        <!-- Car Type -->
        <div class="form-group row">
            <asp:Label ID="lblCType" runat="server" CssClass="control-label col-sm-2">Car Type :</asp:Label>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlCType" runat="server" CssClass="">
                    <asp:ListItem hidden="true">-- Select --</asp:ListItem>
                    <asp:ListItem Value="1">Family Car</asp:ListItem>
                    <asp:ListItem Value="2">Sports Car</asp:ListItem>
                    <asp:ListItem Value="3">SUV Car</asp:ListItem>
                </asp:DropDownList>
            </div>
            
            <asp:RangeValidator ID="rvCTypeVlidation" runat="server" ErrorMessage="Must Select One!"
                                ForeColor="Red" Display="Dynamic" ControlToValidate="ddlCType" 
                                EnableClientScript="true" MaximumValue="3" MinimumValue="1" 
                                CssClass="col-sm-7">
            </asp:RangeValidator>
            <br />
        </div>
        <!-- Car Type -->

        <!-- Max Riding Capacity -->
        <div class="form-group row">
            <asp:Label ID="lblMRiding" runat="server" CssClass="control-label col-sm-2">Max Riding Capacity :</asp:Label>
            <div class="col-sm-3">
                <asp:DropDownList ID="ddlMRiding" runat="server" CssClass="">
                    <asp:ListItem hidden="true">-- Select --</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                </asp:DropDownList>
            </div>
           
            <asp:RangeValidator ID="rvMRiding" runat="server" ErrorMessage="Must Select One!"
                                ForeColor="Red" Display="Dynamic" ControlToValidate="ddlMRiding" 
                                EnableClientScript="true" MaximumValue="8" MinimumValue="1"
                                CssClass="col-sm-7" >
            </asp:RangeValidator>
            <br />
        </div>
        <!-- Max Riding Capacity -->
        <!-- Engine Type -->
        <div class="form-group row">
            <asp:Label ID="lblEngineType" runat="server" CssClass="control-label col-sm-2 pt-0 float-sm-left">Engine Type :</asp:Label>
            <div class="col-sm-3 d-inline">
                <asp:RadioButtonList ID="rblEType" runat="server" CssClass="">
                    <asp:ListItem>Electric</asp:ListItem>
                    <asp:ListItem>Gasoline</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            
            <asp:RequiredFieldValidator ID="rvEType" runat="server" ErrorMessage="Must Select One!" 
                                        ForeColor="Red" Display="Dynamic" ControlToValidate="rblEType"
                                        EnableClientScript="true" CssClass="col-sm-7">
            </asp:RequiredFieldValidator>
            <br />
        </div>
        <!-- Engine Type -->

        <!-- Available Store -->
        <div class="form-group row">
            <asp:Label ID="lblAStore" runat="server" CssClass="control-label col-sm-2">Available Store :</asp:Label>
            <asp:CheckBoxList ID="cblAvailableStores" runat="server" CssClass="col-sm-10 d-inline">
            </asp:CheckBoxList>
        </div>
        <!-- Available Store -->

        <div class="form-group row" CssClass="col-sm-offset-4 col-sm-10">
        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="cmdSubmit_Click" CssClass="btn btn-outline-secondary" />
        </div>
        <!-- Input Form -->

    </main>
</asp:Content>
