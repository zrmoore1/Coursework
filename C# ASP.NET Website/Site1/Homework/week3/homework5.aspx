<%@ Page Title="Homework 5" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="homework5.aspx.cs" Inherits="Homework_week3_homework5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--
        Name: Zachary Moore
        Class: CPDM 152-400
        Date: 2/03/2019
        Abstract: A web form that performs various string operations.
    -->
    <link rel="stylesheet" type="text/css" href="../../Styles/homework5.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <div class="container">
        <fieldset>
            <legend>Step 1</legend>
            <label for="txtSentence">Sentence:</label><asp:TextBox runat="server" ID="txtSentence" CssClass="long-text"></asp:TextBox><br />
            <asp:Button ID="btnCountVowels" runat="server" Text="Count Vowels" accesskey="v" OnClick="btnCountVowels_Click"/>
            <asp:Button ID="btnCountWords" runat="server" Text="Count Words" accesskey="w" OnClick="btnCountWords_Click"/>
            <asp:Button ID="btnReverse" runat="server" Text="Reverse" AccessKey="r" OnClick="btnReverse_Click"/>
        </fieldset>
        <fieldset>
            <legend>Step 2</legend>
            <label for="txtRecord">Record:</label><asp:TextBox runat="server" ID="txtRecord" CssClass="long-text"></asp:TextBox><br />
            <asp:Button runat="server" ID="btnBreakApart" Text="Break Apart" AccessKey="b" OnClick="btnBreakApart_Click" />
            <asp:Button runat="server" ID="btnPutTogether" Text="Put Together" AccessKey="t" OnClick="btnPutTogether_Click" /><br />
            <label for="txtField1">Field 1:</label><asp:TextBox runat="server" ID="txtField1" CssClass="field-text"></asp:TextBox>
            <label for="txtField2">Field 2:</label><asp:TextBox runat="server" ID="txtField2" CssClass="field-text"></asp:TextBox>
            <br />
            <label for="txtField3">Field 3:</label><asp:TextBox runat="server" ID="txtField3" CssClass="field-text"></asp:TextBox>
            <label for="txtField4">Field 4:</label><asp:TextBox runat="server" ID="txtField4" CssClass="field-text"></asp:TextBox>
            <br />
            <label for="txtField5">Field 5:</label><asp:TextBox runat="server" ID="txtField5" CssClass="field-text"></asp:TextBox>
            <label for="txtField6">Field 6:</label><asp:TextBox runat="server" ID="txtField6" CssClass="field-text"></asp:TextBox>
        </fieldset>
        <fieldset>
            <legend>Extra Credit</legend>
            <table>
                <tr>
                    <td><label for="txtPhoneNumber">Phone Number:</label></td>
                    <td><asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="field-text"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label for="txtFormattedNumber">Formatted Phone Number:</label></td>
                    <td><asp:TextBox runat="server" ID="txtFormattedNumber" ReadOnly="true" Enabled="false" CssClass="field-text"></asp:TextBox></td>
                </tr>
            </table>
            <asp:Button runat="server" ID="btnFormatNumber" Text="Format Phone Number" AccessKey="f" OnClick="btnFormatNumber_Click" />
        </fieldset>
    </div>
</asp:Content>

