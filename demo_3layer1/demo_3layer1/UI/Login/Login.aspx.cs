using System;
using System.Linq;
using demo_3layer1.Business;
using demo_3layer1.Models;

namespace demo_3layer1.UI.Loginn
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

            var user = _userBusiness.Login(username, password);
            if (user == null)
            {
                lblMessage.Text = "Sai tên đăng nhập hoặc mật khẩu!";
                return;
            }

            // ✅ Lưu thông tin đăng nhập vào session
            Session["Username"] = user.Username;
            Session["Role"] = user.Role;
            Session["UserId"] = user.Id;
            
            // QUAN TRỌNG: nhớ lưu luôn UserId

            // ✅ Nếu là sinh viên → tìm đúng Student theo UserId
            if (string.Equals(user.Role, "Student", StringComparison.OrdinalIgnoreCase))
            {
                var stu = new StudentBusiness().GetByUserId(user.Id); // cần hàm này
                
                if (stu != null)
                {
                    Session["StudentId"] = stu.Id;
                    Session["StudentName"] = stu.Name;
                }
                else
                {
                    // Chưa liên kết → thông báo nhẹ, vẫn cho vào dashboard
                    // (tuỳ ý bạn: có thể chuyển hướng sang trang yêu cầu liên kết)
                    lblMessage.Text = "Tài khoản chưa liên kết hồ sơ sinh viên.";
                }
            }

            // ✅ Điều hướng theo role
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
    }
}
