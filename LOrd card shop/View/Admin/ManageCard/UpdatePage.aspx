<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarAdmin.Master" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="LOrd_card_shop.View.Admin.ManageCard.UpdatePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Card Page</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Card Id" DataField="CardId" />
            <asp:BoundField HeaderText="Card Name" DataField="CardName" />
            <asp:BoundField HeaderText="Card Price" DataField="CardPrice" />
            <asp:BoundField HeaderText="Card Description" DataField="CardDesc" />
            <asp:BoundField HeaderText="Card Type" DataField="CardType" />
            <asp:TemplateField HeaderText="Is Foil">
                <ItemTemplate>
                    <%# 
            Eval("isFoil") != null && ((byte[])Eval("isFoil")).Length > 0 && ((byte[])Eval("isFoil"))[0] == 0x01 
                ? "True" 
                : "False" 
                    %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="CardID" runat="server" Text="Card ID"></asp:Label>
    <asp:TextBox ID="CardIDTbx" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="CardName" runat="server" Text="Card Name"></asp:Label>
    <asp:TextBox ID="CardNameTbx" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="CardPrice" runat="server" Text="Card Price"></asp:Label>
    <asp:TextBox ID="CardPriceTbx" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="CardDesc" runat="server" Text="Card Desc"></asp:Label>
    <asp:TextBox ID="CardDescTbx" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="CardType" runat="server" Text="Card Type"></asp:Label>
    <asp:DropDownList ID="CardTypeDropDown" runat="server"></asp:DropDownList>
    <br />
    <asp:Label ID="IsFoil" runat="server" Text="Foil"></asp:Label>
    <asp:CheckBox ID="FoilBox" runat="server" />
    <br />
    <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
    <br />
    <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
</asp:Content>
