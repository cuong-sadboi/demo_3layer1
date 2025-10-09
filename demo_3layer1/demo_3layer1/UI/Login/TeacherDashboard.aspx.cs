using System;
using System.Web.UI;

namespace demo_3layer1
{
    public partial class TeacherDashboard : System.Web.UI.Page
    {
       
        protected void btnSubjects_Click(object sender, EventArgs e)
        {
            Response.Redirect("Subjects.aspx"); // Tạo trang này sau
        }

        protected void btnGrades_Click(object sender, EventArgs e)
        {
            Response.Redirect("Grades.aspx"); // Tạo trang này sau
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
