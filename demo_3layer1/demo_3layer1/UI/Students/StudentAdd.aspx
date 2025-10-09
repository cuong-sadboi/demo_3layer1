<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentAdd.aspx.cs" Inherits="demo_3layer1.UI.Students.StudentAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm sinh viên mới</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server" class="container mt-5" style="max-width:600px;">
        <h3 class="text-center mb-4">➕ Thêm sinh viên mới</h3>

        <div class="mb-3">
            <label class="form-label">Tên sinh viên</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label class="form-label">Lớp học</label>
            <asp:TextBox ID="txtClass" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" CssClass="d-block text-center mb-2"></asp:Label>

        <div class="text-center">
            <asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="btn btn-success" OnClick="btnSave_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Quay lại" CssClass="btn btn-secondary ms-2" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
