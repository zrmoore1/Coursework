<%@ Page Title="Homework 9" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="homework9.aspx.cs" Inherits="Homework_week9_homework9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--
        Name: Zachary Moore
        Class: CPDM 152-400 
        Date: 3/8/2019
        Abstract: A basic CRUD page that uses a gridview to display, edit and delete
            products and a formview to insert a new product.
        -->
    <link rel="stylesheet" type="text/css" href="../../Styles/homework9.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <asp:GridView ID="grdProducts" runat="server" CssClass="gridview" AutoGenerateColumns="False" 
        DataKeyNames="ProductID" DataSourceID="edsProducts" AllowPaging="True" PageSize="15" 
        AllowSorting="True">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" SortExpression="ProductID"/>
            <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
            <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" SortExpression="SupplierID" />
            <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" SortExpression="CategoryID" />
            <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" SortExpression="QuantityPerUnit" />
            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
            <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" SortExpression="UnitsInStock" />
            <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" SortExpression="UnitsOnOrder" />
            <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" SortExpression="ReorderLevel" />
            <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued" />
        </Columns>
    </asp:GridView>
    <asp:FormView ID="fmvNewProduct" runat="server" DataSourceID="edsProducts" DataKeyNames="ProductID" 
        OnItemInserted="fmvNewProduct_ItemInserted">
        <ItemTemplate>
            <asp:Button ID="btnNewProduct" runat="server" Text="New Product" CommandName="New" OnClick="btnNewProduct_Click"/>
        </ItemTemplate>
        <InsertItemTemplate>
            <table class="formview">
                <tr>
                    <th colspan="2">Insert New Product</th>
                </tr>
                <tr>
                    <td><label>Product Name:</label></td>
                    <td>
                        <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><label>Supplier:</label></td>
                    <td>
                        <asp:DropDownList ID="ddlSupplier" runat="server" DataSourceID="edsSuppliers" DataTextField="CompanyName" DataValueField="SupplierID" 
                            SelectedValue='<%# Bind("SupplierID") %>'>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><label>Category:</label></td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="edsCategories" DataTextField="CategoryName" DataValueField="CategoryID"
                            SelectedValue='<%# Bind("CategoryID") %>'>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><label>Quantity per Unit:</label></td>
                    <td><asp:TextBox ID="txtQuantity" runat="server" Text='<%# Bind("QuantityPerUnit") %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label>Unit Price:</label></td>
                    <td><asp:TextBox ID="txtUnitPrice" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label>Units In Stock:</label></td>
                    <td><asp:TextBox ID="txtUnitsInStock" runat="server" Text='<%# Bind("UnitsInStock") %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label>Units On Order:</label></td>
                    <td><asp:TextBox ID="txtUnitsOnOrder" runat="server" Text='<%# Bind("UnitsOnOrder") %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label>Reorder Level:</label></td>
                    <td><asp:TextBox ID="txtReorderLevel" runat="server" Text='<%# Bind("ReorderLevel") %>'></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnInsert" Text="Insert" runat="server" CommandName="Insert" OnClick="btnInsert_Click" CausesValidation="true"/></td>
                    <td><asp:Button ID="btnCancel" Text="Cancel" runat="server" CommandName="Cancel" OnClick="btnCancel_Click"/></td>
                </tr>
            </table>
        </InsertItemTemplate>
    </asp:FormView>
    <asp:EntityDataSource ID="edsProducts" runat="server" ConnectionString="name=NorthwindEntities" 
        DefaultContainerName="NorthwindEntities" EnableDelete="True" EnableFlattening="False" 
        EnableInsert="True" EnableUpdate="True" EntitySetName="Products">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="edsSuppliers" runat="server" ConnectionString="name=NorthwindEntities" 
        DefaultContainerName="NorthwindEntities" EnableFlattening="False" EntitySetName="Suppliers" 
        Select="it.[CompanyName], it.[SupplierID]"></asp:EntityDataSource>
    <asp:EntityDataSource ID="edsCategories" runat="server" ConnectionString="name=NorthwindEntities" 
        DefaultContainerName="NorthwindEntities" EnableFlattening="False" EntitySetName="Categories" 
        Select="it.[CategoryName], it.[CategoryID]"></asp:EntityDataSource>
</asp:Content>

