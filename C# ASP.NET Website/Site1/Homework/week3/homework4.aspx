<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="homework4.aspx.cs" Inherits="Homework_week3_homework4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--
        Name: Zachary Moore
        Class: CPDM 152-400
        Date: 2/03/2019
        Abstract: Demonstrates different math functions. 
    -->
    <link type="text/css" rel="stylesheet" href="../../Styles/homework4.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <div class="container">
        <table>
            <tr>
                <td><label for="txtInput1">Input 1</label></td>
                <td><asp:TextBox ID="txtInput1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtInput2">Input 2</label></td>
                <td><asp:TextBox ID="txtInput2" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:button id="btnProblem1" runat="server" onclick="btnProblem1_Click" Text="Problem 1"></asp:button></td>
                <td><asp:button id="btnProblem2" runat="server" onclick="btnProblem2_Click" Text="Problem 2"></asp:button></td> 
            </tr>
            <tr>
                <td><asp:button id="btnProblem3" runat="server" onclick="btnProblem3_Click" Text="Problem 3"></asp:button></td>
                <td><asp:button id="btnProblem4" runat="server" onclick="btnProblem4_Click" Text="Problem 4"></asp:button></td> 
            </tr>
            <tr>
                <td><asp:button id="btnProblem5" runat="server" onclick="btnProblem5_Click" Text="Problem 5"></asp:button></td>
                <td><asp:button id="btnProblem6" runat="server" onclick="btnProblem6_Click" Text="Problem 6"></asp:button></td> 
            </tr>
            <tr>
                <td><asp:button id="btnProblem7" runat="server" onclick="btnProblem7_Click" Text="Problem 7"></asp:button></td>
                <td><asp:button id="btnProblem8" runat="server" onclick="btnProblem8_Click" Text="Problem 8"></asp:button></td> 
            </tr>
        </table>
        <asp:Label ID="lblResult" runat="server" CssClass="result"></asp:Label>
    </div>
</asp:Content>

