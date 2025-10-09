using demo_3layer1.Business;
using System;
using System.Globalization;
using System.Web.UI.WebControls;

namespace demo_3layer1.Grades
{
    public partial class GradeList : System.Web.UI.Page
    {
        private readonly GradeBusiness _gradeBus = new GradeBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) LoadGrades();
        }

        private void LoadGrades()
        {
            gvGrades.DataSource = _gradeBus.GetAllGrades();
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
            Response.Redirect("~/UI/Login/AdminDashboard.aspx");
        }
    }
}
