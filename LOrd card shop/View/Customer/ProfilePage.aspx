<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarCustomer.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="LOrd_card_shop.View.Customer.ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Profile Page</h2>
    <div>
        <asp:Label ID="ErrorMessageLbl" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="UsernameTxt" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="EmailLbl" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="EmailTxt" runat="server"></asp:TextBox>
        <br />
        <asp:DropDownList ID="GenderDropDown" runat="server">
            <asp:ListItem Text="--Select Gender--"></asp:ListItem>
            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="OldPassLbl" runat="server" Text="Old Password"></asp:Label>
        <asp:TextBox ID="OldPasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="NewPassLbl" runat="server" Text="New Password"></asp:Label>
        <asp:TextBox ID="NewPasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="ConfPassLbl" runat="server" Text="Confirm Password"></asp:Label>
        <asp:TextBox ID="ConfirmPasswordTxt" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Update Profile" OnClick="Button1_Click" />
    </div>
</asp:Content>
