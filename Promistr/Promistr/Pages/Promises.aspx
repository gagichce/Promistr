<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mainwithheader.Master" AutoEventWireup="true" CodeBehind="Promises.aspx.cs" Inherits="Promistr.Pages.Promises" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
                .special-table {
            background-color: white;
            border-radius: 5px;
            box-shadow: 0 0 5px rgba(0, 0, 0, 0.12);
        }

        .image-cell {
            border-radius: 5px;
            box-shadow: 0 0 5px rgba(0, 0, 0, 0.12);
        }

        th {
            text-align: center !important;
        }

        td {
            vertical-align: middle !important;
        }

        .dropdown-label {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="jumbotron">

            <form id="PromiseView" runat="server">
                <div class="row">
                    <div class="col-md-3">
                        <p class="dropdown-label">
                            Filter by Category:
                        </p>
                    </div>
                    <div class="col-md-4">
                        <asp:DropDownList ID="catDropDown" runat="server" CssClass="form-control" OnSelectedIndexChanged="catDropDown_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="0">All Categories</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>
                <br />
                <div class="row">
                    <asp:Table ID="promiseTable" runat="server" CssClass="table table-hover special-table">
                        <asp:TableHeaderRow ID="specialReaderRow" HorizontalAlign="Center" Font-Size="Large">
                            <asp:TableHeaderCell ID="specialImageCollumn">Promise</asp:TableHeaderCell>
                            <asp:TableHeaderCell ID="specialNameCollumn">Source</asp:TableHeaderCell>
                            <asp:TableHeaderCell ID="specialOptionsCollumn" ColumnSpan="2">Actions</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
