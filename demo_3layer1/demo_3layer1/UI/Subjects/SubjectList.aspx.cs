using demo_3layer1.Business;
using System;
using System.Web.UI.WebControls;

namespace demo_3layer1.UI
{
    public partial class SubjectList : System.Web.UI.Page
    {
        private readonly SubjectBusiness _subjectBusiness = new SubjectBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
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
            Response.Redirect("~/UI/Login/AdminDashboard.aspx");
        }

        protected void gvSubjects_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditSubject")
            {
                Response.Redirect("SubjectEdit.aspx?id=" + id);
            }
            else if (e.CommandName == "DeleteSubject")
            {
                _subjectBusiness.DeleteSubject(id);
                LoadSubjects();
            }
        }
    }
}
