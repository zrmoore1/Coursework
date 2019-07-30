<%@ Page Title="Homework 12" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="homework12.aspx.cs" Inherits="Homework_week11_homework12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--
        Name: Zachary Moore
        Class: CPDM 152-400
        Date: 3/24/2018
        Abstract: A form that allows user to select a customer from
            a dropdownlist and see their information and order history.
        -->
    <link rel="stylesheet" type="text/css" href="../../Styles/homework12.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <div class="main">
        <h1>Customer Information</h1>
        <asp:DropDownList ID="ddlCustomers" runat="server" OnSelectedIndexChanged="ddlCustomers_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        <br />   
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate> 
                <br />
                <asp:GridView ID="grdCustomerInfo" runat="server" CssClass="table-details"></asp:GridView>
                <br />
                <asp:GridView ID="grdCustomerOrders" runat="server" CssClass="table-details"></asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlCustomers" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>

