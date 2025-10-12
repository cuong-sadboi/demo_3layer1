using demo_3layer1.Business;
using System;
using System.Drawing;
using System.Web.UI.WebControls;

namespace demo_3layer1.UI.Subjects
{
    public partial class SubjectList : System.Web.UI.Page
    {
        private readonly SubjectBusiness _subjectBusiness = new SubjectBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            var role = Session["Role"] as string;
            if (string.IsNullOrEmpty(role) || (role != "Admin" && role != "Teacher"))
            {
                Response.Redirect("~/UI/Login/Login.aspx");
                return;
            }

            // Set text + quyền theo vai trò
            btnBackAdmin.Text = role == "Teacher" ? "⬅️ Quay lại trang Giảng Viên" : "⬅️ Quay lại trang Admin";
            btnAdd.Visible = (role == "Admin"); // Teacher không được thêm/xóa

            if (!IsPostBack)
                LoadSubjects();
        }

        private void LoadSubjects()
        {
            gvSubjects.DataSource = _subjectBusiness.GetAllSubjects();
            gvSubjects.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubjectAdd.aspx");
        }

        protected void btnBackAdmin_Click(object sender, EventArgs e)
        {
            var role = Session["Role"] as string;
            Response.Redirect(role == "Teacher"
                ? "~/UI/Login/TeacherDashboard.aspx"
                : "~/UI/Login/AdminDashboard.aspx");
        }

        // Ẩn nút Xóa khi là Teacher
        protected void gvSubjects_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var role = Session["Role"] as string;
                if (role == "Teacher")
                {
                    var btnDelete = e.Row.FindControl("btnDelete") as Button;
                    if (btnDelete != null) btnDelete.Visible = false;
                }
            }
        }

        protected void gvSubjects_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Tránh crash nếu CommandArgument rỗng
            if (e.CommandArgument == null) return;

            if (!int.TryParse(e.CommandArgument.ToString(), out int id))
                return;

            if (e.CommandName == "EditSubject")
            {
                Response.Redirect("SubjectEdit.aspx?id=" + id);
                return;
            }

            if (e.CommandName == "DeleteSubject")
            {
                try
                {
                    var msg = _subjectBusiness.DeleteSubject(id); // Business đã try/catch InvalidOperationException
                    bool ok = msg.IndexOf("thành công", StringComparison.OrdinalIgnoreCase) >= 0;

                    lblMessage.Visible = true;
                    lblMessage.Text = (ok ? "✅ " : "❌ ") + msg;
                    lblMessage.ForeColor = ok ? Color.Green : Color.Red;

                    LoadSubjects(); // refresh lưới
                }
                catch (Exception ex)
                {
                    // Phòng trường hợp lỗi khác chưa được Business xử lý
                    lblMessage.Visible = true;
                    lblMessage.Text = "❌ Lỗi: " + ex.Message;
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }
    }
}
