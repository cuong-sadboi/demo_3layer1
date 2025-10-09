using System;
using System.Web.UI;

namespace demo_3layer1
{
    public partial class TeacherDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var role = Session["Role"] as string;
            if (string.IsNullOrEmpty(role) || (role != "Teacher" && role != "Admin"))
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void btnSubjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Subjects/SubjectList.aspx");
        }

        protected void btnGrades_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Grades/GradeList.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
