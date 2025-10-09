using demo_3layer1.Business;
using demo_3layer1.Models;
using System;
using System.Web.Services.Description;

namespace demo_3layer1.UI.Students
{
    public partial class StudentAdd : System.Web.UI.Page
    {
        private readonly StudentBusiness _bus = new StudentBusiness();

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            var s = new Student
            {
                Name = txtName.Text.Trim(),
                ClassName = txtClass.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };
                string message = _bus.AddStudent(s);
                // Hiển thị thông báo từ Business
                if (message.Contains("thành công"))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "✅ " + message;

                    // Xóa form sau khi thêm
                    txtName.Text = txtClass.Text = txtEmail.Text ="";

                    // Sau 1s quay lại danh sách
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
