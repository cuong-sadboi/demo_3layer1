<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherDashboard.aspx.cs" Inherits="demo_3layer1.TeacherDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trang Giảng viên</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container text-center mt-5">
            <h2 class="mb-3">
                <span style="font-size: 40px;">👩‍🏫</span> Chào mừng Giảng viên
            </h2>
            <p class="text-muted">Bạn có thể quản lý lớp học tại đây</p>

            <div class="row justify-content-center mt-4 g-4">
                <div class="col-md-3">
                    <div class="card shadow-sm p-3">
                        <h4>Môn học</h4>
                        <p>Quản lý môn học bạn phụ trách</p>
                        <asp:Button ID="btnSubjects" runat="server" CssClass="btn btn-success" Text="Quản lý môn học" OnClick="btnSubjects_Click" />
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card shadow-sm p-3">
                        <h4>Điểm số</h4>
                        <p>Cập nhật điểm sinh viên</p>
                        <asp:Button ID="btnGrades" runat="server" CssClass="btn btn-warning" Text="Quản lý điểm" OnClick="btnGrades_Click" />
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card shadow-sm p-3">
                        <h4>Đăng xuất</h4>
                        <p>Thoát khỏi hệ thống</p>
                        <asp:Button ID="btnLogout" runat="server" CssClass="btn btn-danger" Text="Đăng xuất" OnClick="btnLogout_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
