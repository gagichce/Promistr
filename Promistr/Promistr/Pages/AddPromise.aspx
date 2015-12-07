<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPromise.aspx.cs" Inherits="Promistr.Pages.AddPromise" %>

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

        .form-signin {
            max-width: 600px;
            padding: 15px;
            margin: 0 auto;
        }

            .form-signin .form-signin-heading,
            .form-signin .checkbox {
                margin-bottom: 10px;
            }

            .form-signin .checkbox {
                font-weight: normal;
            }

            .form-signin .form-control {
                position: relative;
                height: auto;
                -webkit-box-sizing: border-box;
                -moz-box-sizing: border-box;
                box-sizing: border-box;
                padding: 10px;
                font-size: 16px;
            }

                .form-signin .form-control:focus {
                    z-index: 2;
                }

            .form-signin .username {
                max-width: 1000px;
                margin-bottom: -1px;
                border-bottom-right-radius: 0;
                border-bottom-left-radius: 0;
            }

            .form-signin .password {
                max-width: 1000px;
                margin-bottom: 10px;
                border-top-left-radius: 0;
                border-top-right-radius: 0;
            }

        .alert {
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <div class="container">
        <form id="form1" class="form-signin" runat="server">
            <h2 class="form-signin-heading">Add New Promise</h2>

            <asp:TextBox ID="name" runat="server" TextMode="SingleLine" class="form-control username" placeholder="Title"></asp:TextBox>
            <asp:TextBox ID="description" runat="server" TextMode="SingleLine" class="form-control username" placeholder="Description"></asp:TextBox>
            <asp:TextBox ID="source" runat="server" TextMode="SingleLine" class="form-control password" placeholder="Source"></asp:TextBox>

            <%--<asp:TextBox ID="passWord" runat="server" TextMode="Password" class="form-control password" placeholder="Password"></asp:TextBox>--%>

            <asp:DropDownList ID="catDropDown" runat="server" CssClass="form-control password" AutoPostBack="True">
                <asp:ListItem Value="0">Select Category</asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="addPromiseButton" runat="server" OnClick="addPromiseButton_OnClick" Text="Add Promise" class="btn btn-lg btn-primary btn-block" />
            <asp:Button ID="cancelButton" runat="server" PostBackUrl="Home.aspx" Text="Cancel" class="btn btn-lg btn-danger btn-block" />

            <asp:Label ID="lblError" runat="server" ForeColor="#FF3300"></asp:Label>

            <div id="errorAlert" class="alert alert-danger hidden" role="alert" runat="server">Oh Snap!</div>
        </form>
    </div>
</body>
</html>
