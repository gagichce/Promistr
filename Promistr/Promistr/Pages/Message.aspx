<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="Promistr.Pages.Message" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <style type="text/css">
        body {
            padding-top: 40px;
            padding-bottom: 40px;
            background-color: #eee;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>
                <asp:Literal ID="MessageLiteral" runat="server"></asp:Literal>
            </h3>
            <a class="btn btn-lg btn-danger" role="button" href="Home.aspx">Home »</a>
        </div>
    </form>
</body>
</html>
