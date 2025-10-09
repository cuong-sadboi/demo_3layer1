<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeAdd.aspx.cs" Inherits="demo_3layer1.Grades.GradeAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nhập điểm sinh viên</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script>
        function hideMessage() {
            var lbl = document.getElementById('<%= lblMessage.ClientID %>');
            if (lbl) setTimeout(function () { lbl.innerHTML = ''; }, 1000);
        }
    </script>
</head>
<body onload="hideMessage()">
    <form id="form1" runat="server">
        <div class="container mt-4 col-md-6">
            <h2 class="text-center mb-4 text-primary fw-bold">📝 Nhập điểm sinh viên</h2>

            <asp:Label ID="lblMessage" runat="server" CssClass="text-center d-block mb-3"></asp:Label>

            <div class="mb-3">
                <label class="form-label">Sinh viên</label>
                <asp:DropDownList ID="ddlStudent" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label class="form-label">Môn học</label>
                <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label class="form-label">Điểm</label>
                <asp:TextBox ID="txtScore" runat="server" CssClass="form-control" Placeholder="0-10"></asp:TextBox>
            </div>

            <div class="d-flex justify-content-between">
                <asp:Button ID="btnSave" runat="server" Text="💾 Lưu điểm" CssClass="btn btn-success" OnClick="btnSave_Click" />
                <asp:Button ID="btnBack" runat="server" Text="⬅️ Quay lại" CssClass="btn btn-secondary" OnClick="btnBack_Click" />
            </div>
        </div>
    </form>
</body>
</html>
