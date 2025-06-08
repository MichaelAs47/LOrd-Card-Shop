<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarAdmin.Master" AutoEventWireup="true" CodeBehind="ManageCardPage.aspx.cs" Inherits="LOrd_card_shop.View.Admin.ManageCardPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Manage Card</h2>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Card Id" DataField="CardID" />
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

    <asp:Button ID="Insert" runat="server" Text="Insert" onclick="Insert_Click"/>
    <asp:Button ID="Update" runat="server" Text="Update" onclick="Update_Click"/>
    <asp:Button ID="Delete" runat="server" Text="Delete" onclick="Delete_Click"/>
</asp:Content>
