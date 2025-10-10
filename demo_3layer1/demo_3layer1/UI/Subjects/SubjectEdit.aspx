<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubjectEdit.aspx.cs" Inherits="demo_3layer1.UI.Subjects.SubjectEdit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sửa thông tin môn học</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server" class="container mt-5" style="max-width:600px;">
        <h3 class="text-center mb-4">✏️ Sửa thông tin môn học</h3>

        <asp:HiddenField ID="hfId" runat="server" />

          <div class="mb-3">
                <label for="txtName" class="form-label">Tên môn học</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtCredit" class="form-label">Số tín chỉ</label>
                <asp:TextBox ID="txtCredit" runat="server" CssClass="form-control" TextMode="Number" />
            </div>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-center d-block mb-3"></asp:Label>

        <div class="text-center">
            <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Quay lại" CssClass="btn btn-secondary ms-2" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
