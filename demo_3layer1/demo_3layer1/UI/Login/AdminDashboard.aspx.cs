using System;

namespace demo_3layer1
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null || Session["Role"]?.ToString() != "Admin")
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void btnStudents_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Students/StudentList.aspx");
        }   

        protected void btnSubjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Subjects/SubjectList.aspx");
        }

        protected void btnGrade_Click(object sender, EventArgs e)
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
