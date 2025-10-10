using demo_3layer1.Business;
using demo_3layer1.DataAccess;
using demo_3layer1.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;



namespace demo_3layer1.UI.Students
{
    public partial class StudentList : System.Web.UI.Page
    {
        private StudentBusiness _bus = new StudentBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            var role = Session["Role"] as string;
            if (string.IsNullOrEmpty(role) || role != "Admin")
            {
                Response.Redirect("~/UI/Login/Login.aspx");
                return;
            }
            if (!IsPostBack)
            {
                LoadStudents();
            }
        }

        private void LoadStudents(string keyword = "")
        {
            var list = _bus.GetAllStudents();

            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                list = list.Where(s => s.Name.ToLower().Contains(keyword) ||
                                       s.ClassName.ToLower().Contains(keyword)).ToList();
            }

            gvStudents.DataSource = list;
            gvStudents.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStudents(txtSearch.Text.Trim());
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentAdd.aspx");
        }

        protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditStudent")
            {
                Response.Redirect("StudentEdit.aspx?id=" + id);
            }
            else if (e.CommandName == "DeleteStudent")
            {
                _bus.DeleteStudent(id);
                LoadStudents();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Login/AdminDashboard.aspx");
        }
    }
}
