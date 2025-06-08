<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarGuest.Master" AutoEventWireup="true" CodeBehind="RegisterPage1.aspx.cs" Inherits="LOrd_card_shop.View.Guest.RegisterPage1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #11e4fe96;
        }

        .register-container {
            width: 350px;
            margin: 100px auto;
            padding: 30px;
            border-radius: 15px;
            background-color: #f7f7f7;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
            font-family: Arial, sans-serif;
        }

            .register-container h3 {
                text-align: center;
            }

            .register-container label,
            .register-container input[type="text"],
            .register-container input[type="password"],
            .register-container .aspNet-Button {
                display: block;
                width: 100%;
                margin-bottom: 15px;
            }

            .register-container input[type="checkbox"] {
                margin-right: 5px;
            }

        .aspNet-Button {
            padding: 10px;
            border: none;
            background-color: #007BFF;
            color: white;
            border-radius: 5px;
            cursor: pointer;
        }

            .aspNet-Button:hover {
                background-color: #0056b3;
            }

        .tall-textbox {
            height: 30px;
            font-size: 1.1em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="register-container">
        <h3>Register</h3>
        <br />
        <div>
            <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UserNameTbx" runat="server" CssClass="tall-textbox"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="EmailLbl" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailTbx" runat="server" CssClass="tall-textbox"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="PassLbl" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTbx" runat="server" TextMode="Password" EnableViewState="true" CssClass="tall-textbox"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="GenderLbl" runat="server" Text="Gender"></asp:Label>
            <asp:DropDownList ID="GenderDropDown" runat="server"></asp:DropDownList>
        </div>
        <br />
        <div>
            <asp:Label ID="DOB" runat="server" Text="Date of Birth"></asp:Label>
            <asp:TextBox ID="DOB_date" runat="server" TextMode="Date" CssClass="tall-textbox"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="ConfirmPasswordLbl" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="ConfirmPasswordTbx" runat="server" TextMode="Password" EnableViewState="true" CssClass="tall-textbox"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="RoleLbl" runat="server" Text="Role"></asp:Label>
            <asp:DropDownList ID="RoleDropDown" runat="server"></asp:DropDownList>
        </div>
        <br />
        <div>
            <p>Do you want to go to Login Page ?</p>
            <a href="LoginPage.aspx">Login</a>
        </div>
        <br />
        <asp:Button ID="RegistBtn" runat="server" Text="Register" OnClick="RegistBtn_Click" CssClass="aspNet-Button" />
        <br />
        <asp:Label ID="ErrorLbl" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
