using demo_3layer1.DataAccess;
using demo_3layer1.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace demo_3layer1.UI.Students
{
    public partial class CourseRegistration : System.Web.UI.Page
    {
        private readonly SubjectDataAccess _subjectData = new SubjectDataAccess();
        private readonly AppDbContext _context = new AppDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            var role = Session["Role"] as string;
            if (string.IsNullOrEmpty(role) || role != "Student")
            {
                Response.Redirect("~/UI/Login/Login.aspx");
                return;
            }
            if (!IsPostBack)
            {
                BindSubjects();
                BindRegistrations();
            }
        }

        private void BindSubjects()
        {
            var subjects = _subjectData.GetAllSubjects();
            ddlSubjects.DataSource = subjects;
            ddlSubjects.DataTextField = "Name";
            ddlSubjects.DataValueField = "Id";
            ddlSubjects.DataBind();
        }

        private int GetCurrentStudentId()
        {
            // In a real app, map username->studentId. For now, assume username matches student Name or seed a mapping.
            // Placeholder: not implemented mapping; require manual selection in real scenario.
            // To keep demo working, we will store a fake student id if not present.
            if (Session["StudentId"] == null)
            {
                var firstStudent = _context.Students.FirstOrDefault();
                if (firstStudent != null)
                {
                    Session["StudentId"] = firstStudent.Id;
                }
            }
            return Session["StudentId"] is int id ? id : 0;
        }

        private void BindRegistrations()
        {
            int studentId = GetCurrentStudentId();
            var regs = _context.CourseRegistrations
                .Where(r => r.StudentId == studentId)
                .Select(r => new { r.Id, r.Semester, Subject = r.Subject })
                .ToList();
            gvRegistrations.DataSource = regs;
            gvRegistrations.DataBind();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            int studentId = GetCurrentStudentId();
            if (studentId == 0)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "Không xác định được sinh viên hiện tại.";
                return;
            }

            int subjectId = int.Parse(ddlSubjects.SelectedValue);
            string semester = txtSemester.Text.Trim();
            if (string.IsNullOrWhiteSpace(semester)) semester = DateTime.Now.ToString("yyyy");

            bool exists = _context.CourseRegistrations.Any(r => r.StudentId == studentId && r.SubjectId == subjectId && r.Semester == semester);
            if (exists)
            {
                lblMessage.CssClass = "text-warning";
                lblMessage.Text = "Môn học đã được đăng ký cho học kỳ này.";
                return;
            }

            _context.CourseRegistrations.Add(new demo_3layer1.Models.CourseRegistration
            {
                StudentId = studentId,
                SubjectId = subjectId,
                Semester = semester
            });
            _context.SaveChanges();

            lblMessage.CssClass = "text-success";
            lblMessage.Text = "Đăng ký thành công.";
            BindRegistrations();
        }

        protected void gvRegistrations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRegistration")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                var existing = _context.CourseRegistrations.Find(id);
                if (existing != null)
                {
                    _context.CourseRegistrations.Remove(existing);
                    _context.SaveChanges();
                    BindRegistrations();
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Login/StudentDashboard.aspx");
        }
    }
}
