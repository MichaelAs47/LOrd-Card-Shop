<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarCustomer.Master" AutoEventWireup="true" CodeBehind="TransactionDetailCustomerPage.aspx.cs" Inherits="LOrd_card_shop.View.Customer.TransactionDetailCustomerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Your Transaction Details</h2>

    <asp:Label ID="TransactionIdLabel" runat="server" Font-Bold="true" /><br />
    <br />

    <asp:GridView ID="TransactionDetailGridView" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="CardName" HeaderText="Card Name" />
            <asp:BoundField DataField="CardPrice" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
        </Columns>
    </asp:GridView>
</asp:Content>
