<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeList.aspx.cs" Inherits="demo_3layer1.UI.Grades.GradeList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>📊 Quản lý điểm sinh viên</title>
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

    <script>
        function hideMessage() {
            var lbl = document.getElementById('<%= lblMessage.ClientID %>');
            if (lbl) setTimeout(function () { lbl.innerHTML = ''; }, 2000);
        }
    </script>
</head>

<body onload="hideMessage()">
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="text-center mb-4 text-primary fw-bold">📊 Quản lý điểm sinh viên</h2>

            <!-- 🟢 Label hiển thị tên sinh viên -->
            <asp:Label ID="lblStudentName" runat="server"
                       CssClass="fw-bold fs-5 text-primary d-block mb-3 text-center"></asp:Label>

            <!-- Nút thêm điểm (ẩn khi là sinh viên) -->
            <div class="row mb-3">
                <div class="col-md-3">
                    <asp:Button ID="btnAddGrade" runat="server" Text="➕ Nhập điểm mới"
                        CssClass="btn btn-success w-100 fw-semibold"
                        OnClick="btnAddGrade_Click" />
                </div>
            </div>

            <!-- Thông báo -->
            <asp:Label ID="lblMessage" runat="server"
                       CssClass="text-center d-block mb-3 fw-semibold text-success"></asp:Label>

            <!-- Bảng danh sách điểm -->
            <asp:GridView ID="gvGrades" runat="server"
                CssClass="table table-bordered table-hover text-center"
                AutoGenerateColumns="False"
                DataKeyNames="StudentId,SubjectId"
                OnRowEditing="gvGrades_RowEditing"
                OnRowUpdating="gvGrades_RowUpdating"
                OnRowDeleting="gvGrades_RowDeleting"
                EmptyDataText="Chưa có điểm sinh viên nào.">
                <Columns>
                    <asp:BoundField DataField="Student.Name" HeaderText="Sinh viên" ReadOnly="true" />
                    <asp:BoundField DataField="Subject.Name" HeaderText="Môn học" ReadOnly="true" />
                    <asp:BoundField DataField="Score" HeaderText="Điểm" />

                    <asp:TemplateField HeaderText="Thao tác">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="✏️ Sửa"
                                CssClass="btn btn-warning btn-action me-2"
                                CommandName="Edit" CommandArgument='<%# Container.DisplayIndex %>' />

                            <asp:Button ID="btnDelete" runat="server" Text="🗑️ Xóa"
                                CssClass="btn btn-danger btn-action"
                                CommandName="Delete" CommandArgument='<%# Container.DisplayIndex %>'
                                OnClientClick="return confirm('Bạn có chắc chắn muốn xóa điểm này không?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <!-- Nút quay lại -->
            <div class="text-center mt-4">
                <asp:Button ID="btnBack" runat="server"
                    Text="⬅️ Quay lại trang Admin"
                    CssClass="btn btn-secondary fw-semibold px-4"
                    OnClick="btnBack_Click" />
            </div>
        </div>
    </form>
</body>
</html>
