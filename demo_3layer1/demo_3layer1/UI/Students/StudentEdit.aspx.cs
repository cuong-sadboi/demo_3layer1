using System;
using demo_3layer1.Business;
using demo_3layer1.Models;

namespace demo_3layer1.UI.Students
{
    public partial class StudentEdit : System.Web.UI.Page
    {
        private readonly StudentBusiness _bus = new StudentBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.QueryString["id"], out int id))
                {
                    var s = _bus.GetStudentById(id);
                    if (s != null)
                    {
                        hfId.Value = s.Id.ToString();
                        txtName.Text = s.Name;
                        txtClass.Text = s.ClassName;
                        txtEmail.Text = s.Email;
                    }
                    else
                    {
                        lblMessage.Text = "Không tìm thấy sinh viên!";
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           
                var s = new Student
                {
                    Id = int.Parse(hfId.Value),
                    Name = txtName.Text.Trim(),
                    ClassName = txtClass.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                string message = _bus.UpdateStudent(s);

                // Xử lý phản hồi từ Business
                if (message.Contains("thành công"))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "✅ " + message;
                    // Quay lại trang danh sách sau 1s
                    Response.AddHeader("REFRESH", "1;URL=StudentList.aspx");
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "⚠️ " + message;
                }
           
}

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentList.aspx");
        }
    }
}
