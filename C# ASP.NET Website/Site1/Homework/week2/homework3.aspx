<%@ Page Title="Homework 3" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="homework3.aspx.cs" Inherits="Homework_week2_homework3" %>
<%@ Register  src="~/Homework/week2/TriangleAreaCalculator.ascx" TagPrefix="uc" TagName="TriangleAreaCalculator"%>
<%--
    Name: Zachary Moore
    Class: CPDM 152-400
    Date: 1/23/2019
    Abstract: Demonstrates a user control.  
--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="../../Styles/homework3.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <uc:TriangleAreaCalculator  runat="server"/>
</asp:Content>

