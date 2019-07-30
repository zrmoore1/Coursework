<%@ Page Title="Homework 13" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="homework13.aspx.cs" Inherits="Homework_week12_homework13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--
        Name: Zach Moore
        Class: CPDM 152-400
        Date: 4/2/2019
        Abstract: Consumes a web service. 
        -->
    <link href="../../Styles/homework12.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <div class="main">
        <h1>Homework 13</h1>
        <p>
            This homework populates a gridview using a remote web service as a data source.<br />
            Source: <a href="http://itd1.cincinnatistate.edu/C2-SutterStewartR/CategoryService.asmx">http://itd1.cincinnatistate.edu/C2-SutterStewartR/CategoryService.asmx</a> 
        </p>
        <asp:Button ID="btnShowCategories" runat="server" text="Show Categories" OnClick="btnShowCategories_Click" />
        <asp:Button ID="btnShowProducts" runat="server" Text="Show Products" OnClick="btnShowProducts_Click" />
        <br /><br />
       <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnShowCategories" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnShowProducts" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView ID="grdCategoriesProducts" runat="server" CssClass="table-details"></asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

