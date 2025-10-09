using System;
using System.Web.UI;

namespace demo_3layer1
{
    public partial class StudentDashboard : System.Web.UI.Page
    {

        protected void btnRegisterCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseRegistration.aspx"); // Tạo trang này sau
        }

        protected void btnViewGrades_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewGrades.aspx"); // Tạo trang này sau
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
