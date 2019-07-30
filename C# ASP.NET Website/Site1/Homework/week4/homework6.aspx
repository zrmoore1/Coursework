<%@ Page Title="Homework 6" Language="C#" MasterPageFile="../../MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="homework6.aspx.cs" Inherits="Homework_week4_homework6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- 
        Name: Zachary Moore
        Class: CPDM 152-400
        Date: 2/8/2019
        Abstract: A page demonstrating data binding.
    -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <asp:SqlDataSource ID="sdsEmployees" runat="server" ConnectionString="<%$ ConnectionStrings:strNorthWindConnectionString %>" 
        SelectCommand="SELECT EmployeeID, (LastName + ', ' + FirstName) AS Name FROM Employees WHERE (HireDate > @HireDate) ORDER BY Name">
            <SelectParameters>
                <asp:Parameter DefaultValue="1/1/1993" Name="HireDate" Type="DateTime" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsSeafood" runat="server" ConnectionString="<%$ ConnectionStrings:strNorthWindConnectionString %>"
        SelectCommand="SELECT ProductID, ProductName FROM Products WHERE (CategoryID='8') ORDER BY ProductName"></asp:SqlDataSource>
    <table style="background-color: hsl(0, 0%, 80%); padding: 10px; border: 1px solid black;" >
        <tr><td><h2>Homework 6</h2></td></tr>
        <tr>
        <td><label for="ddlEmployees">Employees hired after 1/1/1993:</label></td>
        <td><asp:DropDownList ID="ddlEmployees" runat="server" DataSourceID="sdsEmployees" DataTextField="Name" DataValueField="EmployeeID">
        </asp:DropDownList></td>
        </tr>
        <tr>
        <td><label for="ddlSeafood">Seafood Products:</label></td>
        <td><asp:DropDownList ID="ddlSeafood" runat="server" DataSourceID="sdsSeafood" DataTextField="ProductName" DataValueField="ProductID">
        </asp:DropDownList></td>
        </tr>
    </table>
</asp:Content>

