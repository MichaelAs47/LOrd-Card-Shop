<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarAdmin.Master" AutoEventWireup="true" CodeBehind="ViewTransactionHistoryPage.aspx.cs" Inherits="LOrd_card_shop.View.Admin.ViewTransactionPage" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Customer History Page</h2>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" />
            <asp:BoundField HeaderText="Transaction Date" DataField="TransactionDate" />
            <asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />
            <asp:BoundField HeaderText="Status" DataField="Status" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="btnViewCard" runat="server"
                        Text="View Card"
                        CommandName="ViewCard"
                        CommandArgument='<%# Eval("TransactionID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
