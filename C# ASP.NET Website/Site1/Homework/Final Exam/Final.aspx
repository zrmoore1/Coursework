<%@ Page Title="Final" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Final.aspx.cs" Inherits="Homework_Final_Exam_Final" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--
        Name: Zachary Moore
        Date:4/27/2019
        Class: CPDM 152-400
        Abstract: A CRUD contact list manager. 
   --> 
    <link rel="stylesheet" type="text/css" href="../../Styles/Final.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" Runat="Server">
    <div class="contentWrapper">
        <h2>Contacts</h2>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="udpNewContact" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DropDownList ID="ddlContacts" runat="server" OnSelectedIndexChanged="ddlContacts_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:Checkbox ID="chkShowInactive" Checked="false"  runat="server" Text="Show Inactive Contacts" OnCheckedChanged="chkShowInactive_CheckedChanged" AutoPostBack="true"/>
                <br />
                <asp:Panel ID="pnlAddEditContactInfo" runat="server" Visible="false">
                    <table>
                        <tr>
                            <td><label>First Name</label></td>
                            <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
                          </tr>
                        <tr>
                            <td><label>Last Name</label></td>
                            <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>Email Address</label></td>
                            <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>Phone Number</label></td>
                            <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><label>Active</label></td>
                            <td><asp:CheckBox ID="chkActive" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" UseSubmitBehavior="true" Text="Submit"/>
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />                                        
                            </td>
                        </tr>
                    </table>
                </asp:Panel><asp:Panel ID="pnlViewContact" runat="server" Visible="false">
                    <table>
                        <tr>
                            <td><label>First Name</label></td>
                            <td><asp:Label ID="lblFirstName" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>Last Name</label></td>
                            <td><asp:Label ID="lblLastName" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>Email Address</label></td>
                            <td><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>Phone Number</label></td>
                            <td><asp:Label ID="lblPhone" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td><label>Active</label></td>
                            <td><asp:Label ID="lblActive" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                            <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit"/>
                            <asp:Button ID="btnDelete" runat="server" OnClientClick="if(confirm('Are you sure you want to delete the record?')){}else{return false}" 
                                OnClick="btnDelete_Click" Text="Delete"/>                                       
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Button ID="btnNewContact" Text="Add New Contact" runat="server" OnClick="btnNewContact_Click" />
                <asp:BulletedList ID="lstErrors" CssClass="error" runat="server"></asp:BulletedList>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlContacts" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="btnNewContact" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnEdit" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="chkShowInactive" EventName="CheckedChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>

