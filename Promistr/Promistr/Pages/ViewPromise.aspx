<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/mainwithheader.Master" AutoEventWireup="true" CodeBehind="ViewPromise.aspx.cs" Inherits="Promistr.Pages.ViewPromise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        p {
            font-size: medium !important;
        }

        .description {
            font-weight: bold;
        }

        .lighter-text {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron">
            <h3>
                <asp:Literal ID="promiseTitle" runat="server"></asp:Literal>
                <span class="lighter-text">-
                    <asp:Literal ID="promiseStatus" runat="server"></asp:Literal></span></h3>
            <p class="description">
                <asp:Literal ID="promiseDescription" runat="server"></asp:Literal>
            </p>
            <asp:HyperLink ID="promiseSource" Target="_blank" runat="server">
                Source
            </asp:HyperLink>
            <p>
                No comments here yet.
            </p>
        </div>
    </div>
</asp:Content>
