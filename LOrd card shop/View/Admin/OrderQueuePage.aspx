<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/NavBarAdmin.Master" AutoEventWireup="true" CodeBehind="OrderQueuePage.aspx.cs" Inherits="LOrd_card_shop.View.Admin.OrderQueuePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .side-by-side-container {
            display: flex;
            gap: 32px;
        }

            .side-by-side-container > div {
                flex: 1 1 0;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Order Queue</h2>
    <div class="side-by-side-container">
        <div>
            <h3>Unhandled Table</h3>
            <asp:GridView ID="GridView1_Unhandled" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_Unhandled_RowCommand" DataKeyNames="TransactionID">
                <Columns>
                    <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" />
                    <asp:BoundField HeaderText="Transaction Date" DataField="TransactionDate" />
                    <asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />
                    <asp:BoundField HeaderText="Status" DataField="Status" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnHandle" runat="server" Text="Mark as Handled"
                                CommandName="MarkHandled"
                                CommandArgument="<%# Container.DataItemIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div>
            <h3>Handled Table</h3>
            <asp:GridView ID="GridView2_Handle" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView2_Handle_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID" />
                    <asp:BoundField HeaderText="Transaction Date" DataField="TransactionDate" />
                    <asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />
                    <asp:BoundField HeaderText="Status" DataField="Status" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
