using demo_3layer1.Business;
using System;
using System.Globalization;
using System.Web.UI.WebControls;

namespace demo_3layer1.UI.Grades
{
    public partial class GradeList : System.Web.UI.Page
    {
        private readonly GradeBusiness _gradeBus = new GradeBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            var role = Session["Role"] as string;
            if (string.IsNullOrEmpty(role))
            {
                Response.Redirect("~/UI/Login/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                if (role.Equals("Student", StringComparison.OrdinalIgnoreCase))
                {
                    // Student: chỉ xem điểm của mình
                    LoadGradesForStudent();
                    // Ẩn nút thêm điểm và nút quay lại cho gọn (nếu muốn)
                    btnAddGrade.Visible = false;
                    btnBack.Text = "⬅️ Quay lại trang Sinh viên";
                }
                else if (role == "Admin" || role == "Teacher")
                {
                    // Admin/Teacher: xem toàn bộ
                    btnBack.Text = role == "Teacher" ? "⬅️ Quay lại trang Giảng Viên" : "⬅️ Quay lại trang Admin";
                    LoadGrades();
                }
                else
                {
                    Response.Redirect("~/UI/Login/Login.aspx");
                }
            }
        }

        private void LoadGrades()
        {
            gvGrades.DataSource = _gradeBus.GetAllGrades();
            gvGrades.DataBind();
        }

        private void LoadGradesForStudent()
        {
            if (Session["StudentId"] == null)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Tài khoản sinh viên chưa liên kết với hồ sơ. Liên hệ quản trị viên.";
                gvGrades.DataSource = new System.Collections.Generic.List<object>();
                gvGrades.DataBind();
                return;
            }

            int studentId = Convert.ToInt32(Session["StudentId"]);

            // (tuỳ chọn) hiển thị tên sinh viên trên đầu trang — cần có StudentBusiness
            var stuBiz = new StudentBusiness();
            var stu = stuBiz.GetStudentById(studentId);
            
            gvGrades.DataSource = _gradeBus.GetGradesOfStudent(studentId); // cần method này ở GradeBusiness
            gvGrades.DataBind();
        }


        protected void gvGrades_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvGrades.EditIndex = e.NewEditIndex;
            LoadGrades();
        }

        protected void gvGrades_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int studentId = (int)gvGrades.DataKeys[e.RowIndex].Values["StudentId"];
                int subjectId = (int)gvGrades.DataKeys[e.RowIndex].Values["SubjectId"];

                // Lấy giá trị từ TextBox
                TextBox txtScore = (TextBox)gvGrades.Rows[e.RowIndex].Cells[2].Controls[0];
                string scoreText = txtScore.Text.Trim();

                // Chuẩn hóa dấu thập phân: cho phép nhập 7.5 hoặc 7,5
                scoreText = scoreText.Replace(',', '.');

                double score = double.Parse(scoreText, CultureInfo.InvariantCulture);

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = _gradeBus.SaveGrade(studentId, subjectId, score);

                gvGrades.EditIndex = -1;
                LoadGrades();
            }
            catch (FormatException)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "❌ Điểm không hợp lệ. Vui lòng nhập số từ 0 đến 10 (vd: 7,5 hoặc 7.5).";
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "❌ Lỗi: " + ex.Message;
            }
        }

        protected void gvGrades_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int studentId = (int)gvGrades.DataKeys[e.RowIndex].Values["StudentId"];
                int subjectId = (int)gvGrades.DataKeys[e.RowIndex].Values["SubjectId"];

                _gradeBus.DeleteGrade(studentId, subjectId);

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "✅ Xóa điểm thành công!";
                LoadGrades();
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "❌ Lỗi: " + ex.Message;
            }
        }

        protected void btnAddGrade_Click(object sender, EventArgs e)
        {
            Response.Redirect("GradeAdd.aspx");
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            var role = Session["Role"] as string;
            if (role == "Teacher")
            {
                Response.Redirect("~/UI/Login/TeacherDashboard.aspx");
            }
            else
            {
                Response.Redirect("~/UI/Login/AdminDashboard.aspx");
            }
        }
    }
}
