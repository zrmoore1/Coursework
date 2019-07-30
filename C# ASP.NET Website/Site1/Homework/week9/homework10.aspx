<%@ Page Title="Homework 10" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="homework10.aspx.cs" Inherits="Homework_week9_homework10" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--
        Name: Zachary Moore
        Class: CPDM 152-400
        Date: 3/10/2019
        Abstract: A form which allows users to input CD information which will
            be stored in a file. 
        -->
    <link rel="stylesheet" href="../../Styles/homework10.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <div class="container">
        <h3>Homework 10</h3>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="updMessage" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td><label>CD Title:</label></td>
                        <td><asp:TextBox id="txtCDTitle" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><label>Artist:</label></td>
                        <td><asp:TextBox ID="txtArtist" runat="server"></asp:TextBox></td>
                    </tr>
                </table>
                <asp:Button id="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
                <asp:Button ID="btnList" runat="server" Text="List all CDs" OnClick="btnList_Click"/>
                <asp:Button ID="btnClear" runat="server" Text="Clear" UseSubmitBehavior="false" OnClick="btnClear_Click" />
                <br />
                <br />
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="error"></asp:Label>
                <asp:Label ID="lblAllCDs" runat="server"></asp:Label>
           </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnClear" />
                <asp:AsyncPostBackTrigger ControlID="btnSubmit"/>
                <asp:AsyncPostBackTrigger ControlID="btnList" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>

