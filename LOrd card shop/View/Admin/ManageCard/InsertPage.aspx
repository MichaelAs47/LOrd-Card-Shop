<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarAdmin.Master" AutoEventWireup="true" CodeBehind="InsertPage.aspx.cs" Inherits="LOrd_card_shop.View.Admin.ManageCard.InsertPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Insert Page</h2>
    <label>Card Name</label>
    <asp:TextBox ID="CardNameTbx" runat="server"></asp:TextBox>
    <br />
    <label>Card Price</label>
    <asp:TextBox ID="CardPriceTbx" runat="server"></asp:TextBox>
    <br />
    <label>Card Description</label>
    <asp:TextBox ID="CardDescTbx" runat="server"></asp:TextBox>
    <br />
    <label>Card Type</label>
    <asp:DropDownList ID="CardTypeDropDown" runat="server"></asp:DropDownList>
    <br />
    <asp:CheckBox ID="isFoil" runat="server" Text="Foil"/>
    <br />
    <asp:Button ID="InsertBtn" runat="server" Text="Insert" Onclick="InsertBtn_Click"/>
    <asp:Label ID="ErrorLbl" runat="server" Text=""></asp:Label>
</asp:Content>
