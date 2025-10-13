<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubjectList.aspx.cs" Inherits="demo_3layer1.UI.Subjects.SubjectList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý Môn Học</title>
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
            <h2 class="text-center mb-4 text-primary fw-bold">📚 Quản lý Môn Học</h2>
            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            <div class="row mb-4">
                <div class="col-md-3">
                    <asp:Button ID="btnAdd" runat="server" Text="➕ Thêm môn học" CssClass="btn btn-success w-100 fw-semibold" OnClick="btnAdd_Click" />
                </div>
         </div>
            <!-- Bảng danh sách sinh viên -->
            <asp:GridView ID="gvSubjects" runat="server" CssClass="table table-bordered table-hover text-center"
                AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="gvSubjects_RowCommand" OnRowDataBound="gvSubjects_RowDataBound">
                <Columns>
                   <asp:BoundField DataField="Id" HeaderText="Mã môn" />
                    <asp:BoundField DataField="Name" HeaderText="Tên môn học" />
                    <asp:BoundField DataField="Credit" HeaderText="Số tín chỉ" />
                    <%-- Cột thao tác --%>
<asp:TemplateField HeaderText="Thao tác">
    <ItemTemplate>
        <asp:Button ID="btnEdit" runat="server" Text="✏️ Sửa" 
            CssClass="btn btn-warning btn-action me-2"
            CommandName="EditSubject" CommandArgument='<%# Eval("Id") %>' />

        <asp:Button ID="btnDelete" runat="server" Text="🗑️ Xóa" 
            CssClass="btn btn-danger btn-action"
            CommandName="DeleteSubject" CommandArgument='<%# Eval("Id") %>' 
            OnClientClick="return confirm('Bạn có chắc chắn muốn xóa môn học này không?');" />
    </ItemTemplate>
</asp:TemplateField>
                </Columns>
            </asp:GridView>

            <!-- Nút quay lại -->
            <div class="text-center mt-4">
                <asp:Button ID="btnBackAdmin" runat="server" Text="⬅️ Quay lại trang Admin" CssClass="btn btn-secondary fw-semibold px-4" OnClick="btnBackAdmin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
