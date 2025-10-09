<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseRegistration.aspx.cs" Inherits="demo_3layer1.UI.Students.CourseRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>📖 Đăng ký Môn Học</title>
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
        .title-icon {
            font-size: 1.8rem;
            margin-right: 8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="text-center mb-4 text-primary fw-bold">
                <span class="title-icon">📖</span>Đăng ký Môn Học
            </h2>


        <asp:Label ID="lblMessage" runat="server" CssClass="d-block text-center fw-semibold mb-3 text-success"></asp:Label>

        <div class="row mb-4">
            <div class="col-md-5">
                <asp:DropDownList ID="ddlSubjects" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                    <asp:ListItem Text="-- Chọn môn học --" Value="" />
                </asp:DropDownList>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtSemester" runat="server" CssClass="form-control" placeholder="Học kỳ (vd: 2025A)"></asp:TextBox>
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnRegister" runat="server" Text="➕ Đăng ký" CssClass="btn btn-success w-100 fw-semibold" OnClick="btnRegister_Click" />
            </div>
        </div>

        <h4 class="text-primary fw-bold mb-3">📚 Danh sách môn đã đăng ký</h4>
        <asp:GridView ID="gvRegistrations" runat="server" CssClass="table table-bordered table-hover text-center"
            AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="gvRegistrations_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Mã" />
                <asp:BoundField DataField="Subject.Name" HeaderText="Tên môn học" />
                <asp:BoundField DataField="Semester" HeaderText="Học kỳ" />
                <asp:TemplateField HeaderText="Thao tác">
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="🗑️ Hủy" 
                            CssClass="btn btn-danger btn-action"
                            CommandName="DeleteRegistration" CommandArgument='<%# Eval("Id") %>'
                            OnClientClick="return confirm('Bạn có chắc chắn muốn hủy đăng ký môn học này không?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="text-center mt-4">
            <asp:Button ID="btnBack" runat="server" Text="⬅️ Quay lại trang Sinh viên" CssClass="btn btn-secondary fw-semibold px-4" OnClick="btnBack_Click" />
        </div>
    </div>
</form>


</body>
</html>
