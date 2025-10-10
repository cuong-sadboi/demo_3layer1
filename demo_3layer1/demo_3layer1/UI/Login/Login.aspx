<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="demo_3layer1.UI.Loginn.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập hệ thống</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        body {
            background-color: #f4f6f9;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .login-box {
            background: white;
            border-radius: 10px;
            box-shadow: 0 5px 20px rgba(0, 0, 0, 0.15);
            width: 360px;
            overflow: hidden;
        }

        .login-header {
            background-color: #007bff;
            color: white;
            text-align: center;
            padding: 15px;
            font-size: 20px;
            font-weight: bold;
        }

        .login-body {
            padding: 25px;
        }

        .form-control {
            border-radius: 8px;
        }

        .btn-login {
            background-color: #007bff;
            color: white;
            font-weight: 600;
            border-radius: 8px;
            width: 100%;
        }

        .btn-login:hover {
            background-color: #0056b3;
        }

        .role-label {
            text-align: center;
            font-weight: 600;
            color: #17a2b8;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
   <form id="form1" runat="server">
    <div class="login-box">
        <div class="login-header">
            Đăng nhập hệ thống
        </div>

        <div class="login-body">    
            <div class="mb-3">
                <label class="form-label">Tên đăng nhập</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"
                             Placeholder="Nhập tên đăng nhập"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server"
                    ControlToValidate="txtUsername"
                    ErrorMessage="Tên đăng nhập không được để trống!"
                    ForeColor="Red" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <label class="form-label">Mật khẩu</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control"
                             TextMode="Password" Placeholder="Nhập mật khẩu"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                    ControlToValidate="txtPassword"
                    ErrorMessage="Mật khẩu không được để trống!"
                    ForeColor="Red" Display="Dynamic" />
            </div>

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"
                       CssClass="d-block text-center mb-2"></asp:Label>

            <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập"
                        CssClass="btn btn-login" OnClick="btnLogin_Click" />
        </div>
    </div>
</form>

</html>
