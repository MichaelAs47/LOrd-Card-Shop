<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarCustomer.Master" AutoEventWireup="true" CodeBehind="OrderCardPage.aspx.cs" Inherits="LOrd_card_shop.View.Customer.OrderCardPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Order Card</h2>
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="CardID" HeaderText="Card Id" SortExpression="CardId" />
                <asp:BoundField DataField="CardName" HeaderText="Card Name" SortExpression="CardName" />
                <asp:BoundField DataField="CardPrice" HeaderText="Card Price" SortExpression="CardPrice" />
                <asp:TemplateField HeaderText="Detail">
                    <ItemTemplate>
                        <asp:Button ID="DetailBtn" runat="server" Text="Detail Card" UseSubmitBehavior="false" CommandName="Detail" CommandArgument='<%# Eval("CardID") %>' />
                        <asp:Button ID="AddToCart" runat="server" Text="Add To Cart" UseSubmitBehavior="false" CommandName="AddToCart" CommandArgument='<%# Eval("CardID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
