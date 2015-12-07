<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeAccount.aspx.cs" Inherits="Promistr.Pages.MakeAccount" %>

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
            max-width: 400px;
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
            <h2 class="form-signin-heading">Create Promistr Account</h2>

            <asp:TextBox ID="email" runat="server" TextMode="SingleLine" class="form-control username" placeholder="Email"></asp:TextBox>

            <asp:TextBox ID="passWord" runat="server" TextMode="Password" class="form-control password" placeholder="Password"></asp:TextBox>

            <asp:Button ID="makeAccount" runat="server" OnClick="makeAccount_OnClick" Text="Create Account" class="btn btn-lg btn-danger btn-block" />

            <asp:Label ID="lblError" runat="server" ForeColor="#FF3300"></asp:Label>

            <div id="errorAlert" class="alert alert-danger hidden" role="alert" runat="server">Oh Snap!</div>
        </form>
    </div>
</body>
</html>
