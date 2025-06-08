<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarGuest.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="LOrd_card_shop.View.Guest.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #f94040;
        }

        .login-container {
            width: 350px;
            margin: 100px auto;
            padding: 30px;
            border-radius: 15px;
            background-color: #f7f7f7;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
            font-family: Arial, sans-serif;
        }

            .login-container h3 {
                text-align: center;
            }

            .login-container label,
            .login-container input[type="text"],
            .login-container input[type="password"],
            .login-container .aspNet-Button {
                display: block;
                width: 100%;
                margin-bottom: 15px;
            }

            .login-container input[type="checkbox"] {
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
    <div class="login-container">
        <h3>Login</h3>
        <br />
        <asp:Label ID="UsernameLbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="UserNameTbx" runat="server" CssClass="tall-textbox"></asp:TextBox>
        <br />
        <asp:Label ID="PassLbl" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="PasswordTbx" runat="server" TextMode="Password" CssClass="tall-textbox"></asp:TextBox>
        <br />
        <div>
            <p>Do you want to go to Register Page ?</p>
            <a href="RegisterPage1.aspx">Register</a>
        </div>
        <br />
        <div style="margin-bottom: 15px;">
            <label style="display: flex; align-items: center; gap: 5px;">
                <asp:CheckBox ID="RememberMeCheck" runat="server" Text="" />
                <span>Remember Me</span>
            </label>
        </div>

        <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" CssClass="aspNet-Button" />
    </div>
</asp:Content>
