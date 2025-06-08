<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarCustomer.Master" AutoEventWireup="true" CodeBehind="HistoryPage.aspx.cs" Inherits="LOrd_card_shop.View.Customer.HistoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Your Purchase History</h2>

    <asp:GridView ID="HistoryGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="HistoryGridView_RowCommand">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="ViewDetailsBtn" runat="server" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Eval("TransactionID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
