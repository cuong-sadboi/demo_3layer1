using System;
using demo_3layer1.Business;
using demo_3layer1.Models;

namespace demo_3layer1
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly UserBusiness _userBusiness = new UserBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // ✅ Xóa session cũ nếu không đến từ Home
                if (Session["CameFromHome"] == null)
                    Session.Clear();

                // ✅ Nếu có vai trò được chọn từ Home.aspx
              

                // ✅ Đảm bảo có tài khoản mặc định
                _userBusiness.SeedDefaultUsers();

                // Xóa flag để không ảnh hưởng lần sau
                Session["CameFromHome"] = null;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!";
                return;
            }

            User user = _userBusiness.Login(username, password);

            if (user != null)
            {
                // ✅ Lưu thông tin đăng nhập vào session
                Session["Username"] = user.Username;
                Session["Role"] = user.Role;
                lblMessage.Text = "Role: " + user.Role;
                // ✅ Chuyển hướng sau đăng nhập
                switch (user.Role)
                {
                    case "Admin":
                        Response.Redirect("AdminDashboard.aspx");
                        break;
                    case "Teacher":
                        Response.Redirect("TeacherDashboard.aspx");
                        break;
                    case "Student":
                        Response.Redirect("StudentDashboard.aspx");
                        break;
                    default:
                        lblMessage.Text = "Vai trò không hợp lệ.";
                        break;
                }
            }
            else
            {
                lblMessage.Text = "Sai tên đăng nhập hoặc mật khẩu!";
            }
        }
    }
}
