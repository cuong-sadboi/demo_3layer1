<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDashboard.aspx.cs" Inherits="demo_3layer1.StudentDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trang Sinh viên</title>
    <meta charset="utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }

        .dashboard-card {
            transition: all 0.2s ease-in-out;
            border-radius: 12px;
        }

        .dashboard-card:hover {
            transform: translateY(-5px);
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        }

        h2 span {
            font-size: 48px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container text-center mt-5">
            <h2 class="mb-3">
                <span>🎓</span> Chào mừng Sinh viên
            </h2>
            <p class="text-muted mb-4">Bạn có thể thực hiện các chức năng sau</p>

            <div class="row justify-content-center g-4">
                <!-- Đăng ký môn -->
                <div class="col-md-3">
                    <div class="card dashboard-card shadow-sm p-4">
                        <h4>Đăng ký môn học</h4>
                        <p>Chọn môn học cho kỳ học</p>
                        <asp:Button ID="btnRegisterCourse" runat="server"
                            CssClass="btn btn-primary w-100"
                            Text="Đăng ký môn"
                            OnClick="btnRegisterCourse_Click" />
                    </div>
                </div>

                <!-- Xem điểm -->
                <div class="col-md-3">
                    <div class="card dashboard-card shadow-sm p-4">
                        <h4>Xem điểm</h4>
                        <p>Theo dõi kết quả học tập</p>
                        <asp:Button ID="btnViewGrades" runat="server"
                            CssClass="btn btn-warning w-100"
                            Text="Xem điểm"
                            OnClick="btnViewGrades_Click" />
                    </div>
                </div>

                <!-- Đăng xuất -->
                <div class="col-md-3">
                    <div class="card dashboard-card shadow-sm p-4">
                        <h4>Đăng xuất</h4>
                        <p>Thoát khỏi hệ thống</p>
                        <asp:Button ID="btnLogout" runat="server"
                            CssClass="btn btn-danger w-100"
                            Text="Đăng xuất"
                            OnClick="btnLogout_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
