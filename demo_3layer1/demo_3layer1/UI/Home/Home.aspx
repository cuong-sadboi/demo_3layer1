<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="demo_3layer1.Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hệ thống Quản lý Sinh viên</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }
        .banner {
            position: relative;
            text-align: center;
            color: white;
        }
        .banner img {
            width: 100%;
            height: 400px;
            object-fit: cover;
          
        }
        .banner-text {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
        }
        .role-card {
            border-radius: 15px;
            box-shadow: 0 4px 10px rgba(0,0,0,0.1);
            transition: transform 0.2s;
        }
        .role-card:hover {
            transform: scale(1.05);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
    <!-- Hero Banner -->
    <div class="banner rounded shadow overflow-hidden">
        <img src="img/banner.jpg" alt="Banner" class="w-100 rounded" />
        <div class="banner-text">
            <h1 class="fw-bold display-6 bg-dark bg-opacity-50 p-3 rounded">
                🎓 Hệ thống Quản lý Sinh viên
            </h1>
            <p class="lead bg-dark bg-opacity-50 p-2 rounded">
                Quản lý sinh viên - môn học - điểm số hiệu quả
            </p>
            <a href="../Login/Login.aspx" class="btn btn-primary btn-lg mt-3">Đăng nhập ngay</a>
        </div>
    </div>
</div>



        <div class="container text-center mt-5">
            <h3 class="fw-bold">Chọn vai trò của bạn</h3>
            <p class="text-muted mb-4">Hệ thống hỗ trợ quản lý theo từng loại tài khoản</p>

            <div class="row justify-content-center">
                <div class="col-md-3 mb-3">
                    <div class="card role-card p-3">
                        <h5>👨‍💼 Admin</h5>
                        <p>Quản lý sinh viên, môn học, và điểm toàn hệ thống</p>
                        <asp:Button ID="btnAdmin" runat="server" Text="Vào hệ thống" CssClass="btn btn-primary" OnClick="btnAdmin_Click" />
                    </div>
                </div>
                <div class="col-md-3 mb-3">
                    <div class="card role-card p-3">
                        <h5>👨‍🏫 Giáo viên</h5>
                        <p>Quản lý môn học phụ trách và cập nhật điểm số</p>
                        <asp:Button ID="btnTeacher" runat="server" Text="Vào hệ thống" CssClass="btn btn-success" OnClick="btnTeacher_Click" />
                    </div>
                </div>
                <div class="col-md-3 mb-3">
                    <div class="card role-card p-3">
                        <h5>🎓 Sinh viên</h5>
                        <p>Đăng ký môn học, theo dõi kết quả và điểm số</p>
                        <asp:Button ID="btnStudent" runat="server" Text="Vào hệ thống" CssClass="btn btn-warning" OnClick="btnStudent_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
