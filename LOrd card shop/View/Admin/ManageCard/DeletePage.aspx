<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarAdmin.Master" AutoEventWireup="true" CodeBehind="DeletePage.aspx.cs" Inherits="LOrd_card_shop.View.Admin.ManageCard.DeletePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Delete Card Page</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Card Id" DataField="CardId" />
            <asp:BoundField HeaderText="Card Name" DataField="CardName" />
            <asp:BoundField HeaderText="Card Price" DataField="CardPrice" />
            <asp:BoundField HeaderText="Card Description" DataField="CardDesc" />
            <asp:BoundField HeaderText="Card Type" DataField="CardType" />
            <asp:BoundField HeaderText="Foil" DataField="isFoil" />
        </Columns>
    </asp:GridView>

    <br />
    <asp:Label ID="DelLbl" runat="server" Text="Delete CardID"></asp:Label>
    <asp:TextBox ID="DeleteTbx" runat="server"></asp:TextBox>
    <asp:Button ID="DeleteBtn" runat="server" Text="Delete" Onclick="DeleteBtn_Click"/>
    <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>

</asp:Content>
