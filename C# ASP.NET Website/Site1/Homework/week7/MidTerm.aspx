<%@ Page Title="Midterm" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="MidTerm.aspx.cs" Inherits="Homework_week7_MidTerm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--
        Name: Zachary Moore
        Class: CPDM 152-400
        Date: 2/25/2019
        Abstract: Midterm
        -->
    <link rel="stylesheet" href="../../Styles/MidTerm.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <div class="main">
        <h1>Midterm</h1>
        <asp:DropDownList ID="ddlCustomers" runat="server" OnSelectedIndexChanged="ddlCustomers_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
         <asp:ScriptManager ID="scmUpdatePanel" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="udpOrders" runat="server">
            <ContentTemplate>
                <br />
                <strong><asp:Label ID="lblOrders" runat="server"></asp:Label></strong><br />
                <asp:DropDownList ID="ddlOrders" runat="server" OnSelectedIndexChanged="ddlOrders_SelectedIndexChanged" AutoPostBack="true" Visible="false">
                </asp:DropDownList>
                <br />
                <br />
                <strong><asp:Label ID="lblDetails" runat="server"></asp:Label></strong>
                <asp:DetailsView ID="dtvOrderDetails" runat="server" Visible="false" CssClass="table-details"></asp:DetailsView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlCustomers" EventName="SelectedIndexChanged"  />
                <asp:AsyncPostBackTrigger ControlID="ddlOrders" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>

