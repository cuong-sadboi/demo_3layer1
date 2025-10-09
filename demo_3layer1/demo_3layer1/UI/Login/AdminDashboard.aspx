<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="demo_3layer1.AdminDashboard" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Quản lý hệ thống</title>
    <style>
        body { font-family: Arial; background: #fafafa; text-align: center; }
        .card-container { display: flex; justify-content: center; gap: 20px; margin-top: 80px; }
        .card { background: white; border-radius: 10px; box-shadow: 0 2px 8px rgba(0,0,0,0.1); width: 200px; padding: 20px; }
        .btn { border: none; padding: 10px; border-radius: 6px; color: white; cursor: pointer; width: 100%; }
        .btn-blue { background: #007bff; }
        .btn-green { background: #28a745; }
        .btn-yellow { background: #ffc107; color: black; }
        .btn-red { background: #dc3545; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>🎉 Chào mừng ADMIN</h2>
        <p>Bạn có thể quản lý hệ thống tại đây</p>

        <div class="card-container">
            <div class="card">
                <h3>Sinh viên</h3>
                <p>Quản lý thông tin sinh viên</p>
                <asp:Button ID="btnStudents" runat="server" CssClass="btn btn-blue" Text="Quản lý sinh viên" OnClick="btnStudents_Click" />
            </div>

            <div class="card">
                <h3>Môn học</h3>
                <p>Quản lý danh sách môn học</p>
                <asp:Button ID="btnSubjects" runat="server" CssClass="btn btn-green" Text="Quản lý môn học" OnClick="btnSubjects_Click" />
            </div>

            <div class="card">
                <h3>Điểm số</h3>
                <p>Xem và quản lý điểm</p>
                <asp:Button ID="btnScores" runat="server" CssClass="btn btn-yellow" Text="Xem điểm" OnClick="btnGrade_Click" />
            </div>

            <div class="card">
                <h3>Đăng xuất</h3>
                <p>Thoát khỏi hệ thống</p>
                <asp:Button ID="btnLogout" runat="server" CssClass="btn btn-red" Text="Đăng xuất" OnClick="btnLogout_Click" />
            </div>
        </div>
    </form>
</body>
</html>
