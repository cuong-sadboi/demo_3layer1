using demo_3layer1.Business;
using demo_3layer1.DataAccess;
using System;
using System.Linq;
using demo_3layer1.Models;
using System.Globalization;
using System.Web.UI.WebControls;


namespace demo_3layer1.UI.Grades
{
    public partial class GradeAdd : System.Web.UI.Page
    {
        private readonly GradeBusiness _gradeBus = new GradeBusiness();
        private readonly StudentDataAccess _studentData = new StudentDataAccess();
        private readonly SubjectDataAccess _subjectData = new SubjectDataAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            var role = Session["Role"] as string;
            if (string.IsNullOrEmpty(role) || (role != "Admin" && role != "Teacher"))
            {
                Response.Redirect("~/UI/Login/Login.aspx");
                return;
            }
            if (!IsPostBack)
            {
                ddlStudent.DataSource = _studentData.GetAllStudents();
                ddlStudent.DataTextField = "Name";
                ddlStudent.DataValueField = "Id";
                ddlStudent.DataBind();

                ddlSubject.DataSource = _subjectData.GetAllSubjects();
                ddlSubject.DataTextField = "Name";
                ddlSubject.DataValueField = "Id";
                ddlSubject.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int studentId = int.Parse(ddlStudent.SelectedValue);
                int subjectId = int.Parse(ddlSubject.SelectedValue);

                // Chuẩn hóa dấu thập phân
                string scoreText = txtScore.Text.Trim();
                scoreText = scoreText.Replace(',', '.'); // cho phép 7,5 hoặc 7.5

                double score = double.Parse(scoreText, CultureInfo.InvariantCulture);

                string message = _gradeBus.SaveGrade(studentId, subjectId, score);

                if (message.Contains("thành công"))
                {
                    Response.Redirect("GradeList.aspx"); // quay về bảng điểm
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = message;
                }
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("GradeList.aspx");
        }
    }
}
