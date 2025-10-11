<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewGrades.aspx.cs" Inherits="demo_3layer1.UI.Students.ViewGrades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>📄 Kết quả học tập</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <style>
        .btn-action {
            padding: 5px 10px;
            border-radius: 6px;
            font-size: 14px;
            font-weight: 600;
        }
        .table th, .table td {
            vertical-align: middle !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="text-center mb-4 text-primary fw-bold">📄 Kết quả học tập</h2>
            <asp:Label ID="lblStudentName" runat="server"
           CssClass="fw-bold fs-5 text-primary d-block mb-3 text-center"></asp:Label>


        <asp:Label ID="lblMessage" runat="server" CssClass="text-center d-block mb-3 text-success fw-semibold"></asp:Label>

        <asp:GridView ID="gvGrades" runat="server" CssClass="table table-bordered table-hover text-center"
            AutoGenerateColumns="False" EmptyDataText="Chưa có điểm nào được ghi nhận.">
            <Columns>
                <asp:BoundField DataField="Subject.Name" HeaderText="Tên môn học" />
                <asp:BoundField DataField="Score" HeaderText="Điểm" />
            </Columns>
        </asp:GridView>

        <div class="text-center mt-4">
            <asp:Button ID="btnBack" runat="server" Text="⬅️ Quay lại trang Sinh viên" CssClass="btn btn-secondary fw-semibold px-4" OnClick="btnBack_Click" />
        </div>
    </div>
</form>

</body>
</html>
