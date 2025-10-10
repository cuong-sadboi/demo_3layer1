<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubjectAdd.aspx.cs" Inherits="demo_3layer1.UI.Subjects.SubjectAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm môn học mới</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server" class="container mt-5" style="max-width:600px;">
        <h3 class="text-center mb-4">➕ Thêm môn học mới</h3>

         <div class="mb-3">
                <label for="txtName" class="form-label">Tên môn học</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Nhập tên môn học..." />
            </div>

            <div class="mb-3">
                <label for="txtCredit" class="form-label">Số tín chỉ</label>
                <asp:TextBox ID="txtCredit" runat="server" CssClass="form-control" TextMode="Number" Placeholder="Nhập số tín chỉ..." />
            </div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" CssClass="d-block text-center mb-2"></asp:Label>

        <div class="text-center">
            <asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="btn btn-success" OnClick="btnSave_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Quay lại" CssClass="btn btn-secondary ms-2" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>