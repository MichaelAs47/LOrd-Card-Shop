<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarCustomer.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="LOrd_card_shop.View.Customer.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Your Cart</h2>
    <asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="CartGridView_RowCommand">
        <Columns>
            <asp:BoundField DataField="CardName" HeaderText="Name" />
            <asp:BoundField DataField="CardPrice" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="CardDescription" HeaderText="Description" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="BtnAdd" runat="server" Text="+" CommandName="Increase" CommandArgument='<%# Eval("CardID") %>' />
                    <asp:Button ID="BtnSubtract" runat="server" Text="–" CommandName="Decrease" CommandArgument='<%# Eval("CardID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Button ID="CheckoutBtn" runat="server" Text="Proceed to Checkout" OnClick="CheckoutBtn_Click" />
    <asp:Button ID="ClearCartBtn" runat="server" Text="Clear Cart" OnClick="ClearCartBtn_Click" />
</asp:Content>
