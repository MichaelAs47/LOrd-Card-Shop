<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarCustomer.Master" AutoEventWireup="true" CodeBehind="CardDetail.aspx.cs" Inherits="LOrd_card_shop.View.Customer.CardDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Card Detail</h2>
    <div>
        <asp:Label ID="lblName" runat="server" Font-Bold="true" /><br />
        <asp:Label ID="lblPrice" runat="server" /><br />
        <asp:Label ID="lblType" runat="server" /><br />
        <asp:Label ID="lblDesc" runat="server" /><br />

        <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
    </div>
</asp:Content>
