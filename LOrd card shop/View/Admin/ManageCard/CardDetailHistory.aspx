<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarAdmin.Master" AutoEventWireup="true" CodeBehind="CardDetailHistory.aspx.cs" Inherits="LOrd_card_shop.View.Admin.ManageCard.CardDetailHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Transaction Card Detail</h2>
    <asp:Label ID="lblName" runat="server" Font-Bold="true" /><br />
    <asp:GridView ID="gvCardDetails" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="Card ID" DataField="CardID" />
            <asp:BoundField HeaderText="Card Name" DataField="CardName" />
            <asp:BoundField HeaderText="Card Price" DataField="CardPrice" DataFormatString="{0:C}" />
            <asp:BoundField HeaderText="Card Type" DataField="CardType" />
            <asp:BoundField HeaderText="Description" DataField="CardDesc" />
            <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
            <asp:BoundField HeaderText="Foil?" DataField="isFoil" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
</asp:Content>
