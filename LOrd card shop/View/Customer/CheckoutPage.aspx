<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarCustomer.Master" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="LOrd_card_shop.View.Customer.CheckoutPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Review Your Order</h2>

    <asp:GridView ID="CheckoutGridView" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="CardName" HeaderText="Name" />
            <asp:BoundField DataField="CardPrice" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="CardDescription" HeaderText="Description" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="GrandTotalLabel" runat="server" Font-Bold="true"></asp:Label><br />
    <br />

    <asp:Button ID="ConfirmCheckoutBtn" runat="server" Text="Confirm Checkout" OnClick="ConfirmCheckoutBtn_Click" />

    <asp:Button ID="CancelCheckoutBtn" runat="server" Text="Cancel Checkout" OnClick="CancelCheckoutBtn_Click" />
</asp:Content>
