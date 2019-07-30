<%@ Page Title="Homework 8" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="homework8.aspx.cs" Inherits="Homework_week6_homework8" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--
        Name: Zachary Moore
        Class: CPDM 152-400
        Date: 2/14/2019
        Abstract: Demonstrates the use of LINQ to display the ID and Description
                  from the Northern Region of the Territory table from the
                  Northwind dataset.  
        -->
    <link rel="stylesheet" href="../../Styles/homework8.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <asp:GridView runat="server" ID="grdNorthTerritories" Caption="Territories in the Northern Region" CssClass="gridview-territories"></asp:GridView>
</asp:Content>

