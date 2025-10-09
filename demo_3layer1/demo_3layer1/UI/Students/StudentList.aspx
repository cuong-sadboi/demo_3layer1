<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="demo_3layer1.Students.StudentList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý sinh viên</title>
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
        .search-bar {
            box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="text-center mb-4 text-primary fw-bold">📚 Quản lý Sinh viên</h2>
            <!-- Thanh tìm kiếm -->
            <div class="row mb-4">
                <div class="col-md-6">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control search-bar" Placeholder="🔍 Nhập tên sinh viên hoặc lớp học..."></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" CssClass="btn btn-primary w-100 fw-semibold" OnClick="btnSearch_Click" />
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnAdd" runat="server" Text="➕ Thêm sinh viên" CssClass="btn btn-success w-100 fw-semibold" OnClick="btnAdd_Click" />
                </div>
            </div>
            <!-- Bảng danh sách sinh viên -->
            <asp:GridView ID="gvStudents" runat="server" CssClass="table table-bordered table-hover text-center"
                AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="gvStudents_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />
                    <asp:BoundField DataField="Name" HeaderText="Họ tên" />
                    <asp:BoundField DataField="ClassName" HeaderText="Lớp học" />
                    <asp:BoundField DataField="Email" HeaderText="Email" /> 
                    <%-- Cột thao tác --%>
<asp:TemplateField HeaderText="Thao tác">
    <ItemTemplate>
        <asp:Button ID="btnEdit" runat="server" Text="✏️ Sửa" 
            CssClass="btn btn-warning btn-action me-2"
            CommandName="EditStudent" CommandArgument='<%# Eval("Id") %>' />

        <asp:Button ID="btnDelete" runat="server" Text="🗑️ Xóa" 
            CssClass="btn btn-danger btn-action"
            CommandName="DeleteStudent" CommandArgument='<%# Eval("Id") %>' 
            OnClientClick="return confirm('Bạn có chắc chắn muốn xóa sinh viên này không?');" />
    </ItemTemplate>
</asp:TemplateField>
                </Columns>
            </asp:GridView>
            <!-- Nút quay lại -->
            <div class="text-center mt-4">
                <asp:Button ID="btnBack" runat="server" Text="⬅️ Quay lại trang Admin" CssClass="btn btn-secondary fw-semibold px-4" OnClick="btnBack_Click" />
            </div>
        </div>
    </form>
</body>
</html>
