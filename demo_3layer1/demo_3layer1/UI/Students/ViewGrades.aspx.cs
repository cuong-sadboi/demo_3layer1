using demo_3layer1.DataAccess;
using System;
using System.Linq;

namespace demo_3layer1.UI.Students
{
    public partial class ViewGrades : System.Web.UI.Page
    {
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
                BindGrades();
            }
        }

        private int GetCurrentStudentId()
        {
            if (Session["StudentId"] is int id) return id;
            var firstStudent = _context.Students.FirstOrDefault();
            if (firstStudent != null)
            {
                Session["StudentId"] = firstStudent.Id;
                return firstStudent.Id;
            }
            return 0;
        }

        private void BindGrades()
        {
            int studentId = GetCurrentStudentId();
            var items = _context.Grades
                .Where(g => g.StudentId == studentId)
                .Select(g => new { g.Score, Subject = g.Subject })
                .ToList();
            gvGrades.DataSource = items;
            gvGrades.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Login/StudentDashboard.aspx");
        }
    }
}
