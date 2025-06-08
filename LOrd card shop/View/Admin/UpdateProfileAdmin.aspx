<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarAdmin.Master" AutoEventWireup="true" CodeBehind="UpdateProfileAdmin.aspx.cs" Inherits="LOrd_card_shop.View.Admin.ManageCard.UpdateProfileAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Profile Page</h2>
    <div>
        <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
        <asp:TextBox ID="UserNameTbx" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="UserEmailTbx" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Gender"></asp:Label>
        <asp:DropDownList ID="GenderDropDown" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Date of Birth"></asp:Label>
        <asp:TextBox ID="DOBTbx" runat="server" TextMode="Date"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Role"></asp:Label>
        <asp:DropDownList ID="RoleDropDown" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Old Password"></asp:Label>
        <asp:TextBox ID="OldPassTbx" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="New Password"></asp:Label>
        <asp:TextBox ID="NewPassTbx" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Confirm New Password"></asp:Label>
        <asp:TextBox ID="ConfirmNewPassTbx" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="UpdateBtn" runat="server" Text="Update Profile" OnClick="UpdateBtn_Click" />
        <br />
        <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
