<%@ Page Title="Homework 7" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="homework7.aspx.cs" Inherits="Homework_week5_homework7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--
        Name: Zachary Moore
        Class: CPDM 152-400
        Date: 2/10/2019
        Abstract: A formview to perform basic CRUD operations on the Regions table of Northwind dataset.
        -->
    <link href="../../Styles/homework7.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="cphContent2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <asp:FormView ID="fmvRegions" runat="server" DataKeyNames="RegionID" DataSourceID="sdsNorthwindRegions" AllowPaging="True" RenderOuterTable="False" 
        OnItemDeleted="fmvRegions_ItemDeleted" OnItemInserted="fmvRegions_ItemInserted" OnItemUpdated="fmvRegions_ItemUpdated">
        <EditItemTemplate>
            <table class="formview">
                <tr>
                    <th colspan="2">Edit Region</th>
                </tr>
                <tr>
                    <td><label>ID:</label></td>
                    <td><asp:Label ID="lblRegionID" runat="server" Text='<%# Eval("RegionID") %>' /></td>
                </tr>
                <tr>
                    <td><label>Description:</label></td>
                    <td><asp:TextBox ID="txtRegionDescription" runat="server" Text='<%# Bind("RegionDescription") %>' /></td>
                </tr>
                <tr>
                    <td colspan="2"> 
                        <asp:Button ID="btnUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                        <asp:Button ID="btnCancelUpdate" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </td>
                </tr>
                </table>
        </EditItemTemplate>
        <InsertItemTemplate>
            <table class="formview">
                <tr>
                    <th colspan="2">New Region</th>
                </tr>
                <tr>
                    <td><label>Description:</label></td>
                    <td><asp:TextBox ID="txtRegionDescription" runat="server" Text='<%# Bind("RegionDescription") %>' /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnInsert" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="btnCancelInsert" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </InsertItemTemplate>
        <ItemTemplate>
            <table class="formview">
                <th colspan="2">Region</th>
                <tr>
                    <td><label>ID:</label></td>
                    <td><asp:Label ID="lblRegionID" runat="server" Text='<%# Eval("RegionID") %>' /></td>
                </tr>
                <tr>
                    <td><label>Description:</label></td>
                    <td><asp:Label ID="lblRegionDescription" runat="server" Text='<%# Bind("RegionDescription") %>' /></td>
                </tr>
                    <tr>
                   <td colspan="2"> 
                    <asp:Button ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                    <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"
                        OnClientClick="return confirm('Delete this record?');" />
                    <asp:Button ID="btnNew" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                   </td>
                </tr>
                </table>
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="sdsNorthwindRegions" runat="server" ConnectionString="<%$ ConnectionStrings:strNorthWindConnectionString %>" 
        DeleteCommand="DELETE FROM [Region] WHERE [RegionID] = @RegionID" 
        InsertCommand="INSERT INTO [Region] ([RegionID], [RegionDescription]) SELECT coalesce(MAX([RegionID]), 0) + 1, @RegionDescription FROM [Region];" 
        SelectCommand="SELECT * FROM [Region]" 
        UpdateCommand="UPDATE [Region] SET [RegionDescription] = @RegionDescription WHERE [RegionID] = @RegionID">
        <DeleteParameters>
            <asp:Parameter Name="RegionID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="RegionDescription" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="RegionDescription" Type="String" />
            <asp:Parameter Name="RegionID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:Label id="lblErrorMessage" CssClass="error" runat="server"></asp:Label>
</asp:Content>

